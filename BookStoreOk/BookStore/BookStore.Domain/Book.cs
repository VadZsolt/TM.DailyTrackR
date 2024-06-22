namespace BookStore.Domain
{
  public class Book
  {
    public string Id { get; set; } = string.Empty;

    public string Title { get; set; } = string.Empty;

    public string AuthorId { get; set; } = string.Empty;

    public string PublisherId { get; set; } = string.Empty;

    public DateTime YearOfPublication { get; set; } = new DateTime();

    public List<string> Genres { get; set; } = new List<string>();

    public Book(string title, string authorid, List<string> genres, DateTime year, string publisherid)
        {
            Title = title;
            AuthorId = authorid;
            PublisherId = publisherid;
            YearOfPublication = year;
            Genres = genres;

        }
        public Book(string id, string title, string authorid, List<string> genres, DateTime year, string publisherid)
        {
            Id= id;
            Title = title;
            AuthorId = authorid;
            PublisherId = publisherid;
            YearOfPublication = year;
            Genres = genres;

        }
        public Book()
        {
            
        }
    }
}
