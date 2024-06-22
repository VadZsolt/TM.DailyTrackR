using BookStore.Data.Abstractions;
using BookStore.Domain;
using MongoDB.Bson;
using MongoDB.Driver;

namespace BookStore.Repositories
{
  public class BookRepository : IBookRepository
  {
    private readonly IMongoCollection<Book> books;

    public BookRepository(IDatabase database)
    {
      books = database.GetCollection<IMongoCollection<Book>, Book>("Books");
    }

        public async Task<bool> DeleteAsync(string id, CancellationToken cancellationToken)
        {
            var filter = Builders<Book>.Filter.Eq(book => book.Id, id);
            await this.books.DeleteOneAsync(filter);
            return true;
        }

        public async Task<List<Book>> GetAllAsync(int count, CancellationToken cancellationToken)
        {
            var books = await this.books.Find(Builders<Book>.Filter.Empty).Limit(count).ToListAsync(cancellationToken);
            return books;
        }

        public async Task<Book> GetByIdAsync(string id, CancellationToken cancellationToken)
        {
            var filter = Builders<Book>.Filter.Eq(book => book.Id, id);
            var book = await this.books.Find(filter).FirstAsync(cancellationToken);
            return book;
        }

        public async Task<bool> InsertAsync(Book item, CancellationToken cancellationToken)
        {
            await this.books.InsertOneAsync(item, new InsertOneOptions(), cancellationToken);
            return true;
        }

        public async Task<bool> UpdateAsync(Book item, CancellationToken cancellationToken)
        {
            var filter = Builders<Book>.Filter.Eq(book => book.Id, item.Id);
            var newBook = Builders<Book>.Update.Set(book => book.Id, item.Id).Set(book => book.PublisherId, item.PublisherId)
                .Set(book => book.YearOfPublication, item.YearOfPublication).Set(book => book.Genres, item.Genres)
                .Set(book => book.AuthorId, item.AuthorId).Set(book => book.Title, item.Title);
            await this.books.UpdateOneAsync(filter, newBook, cancellationToken: cancellationToken);
            return true;
        }

    }
}
