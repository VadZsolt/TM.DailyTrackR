using BookStore.Application.DeleteBookById;
using BookStore.Application.GetAllBooks;
using BookStore.Application.GetBookById;
using BookStore.Application.GetWeatherForecast;
using BookStore.Application.InsertBook;
using BookStore.Application.UpdateBookById;
using BookStore.Domain;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController : ControllerBase
    {
        private readonly IMediator mediator;
        public BooksController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet(Name = "GetBook/{id}")]
        public async Task<IActionResult> Get(string id, CancellationToken token)
        {
            var response = await this.mediator.Send(new GetBookByIdRequest { Id = id }, token);
            return this.Ok(response);
        }

        [HttpDelete(Name = "DeleteBook/{id}")]
        public async Task<IActionResult> Delete(string id, CancellationToken cancellationToken)
        {
            var response = await this.mediator.Send(new DeleteBookByIdRequest { Id = id }, cancellationToken);
            return this.Ok(response);
        }
        [HttpPost(Name ="InsertBook")]
        public async Task<IActionResult> Insert(string title, string authorid, string genres, DateTime yearofpublication, string publisherid, CancellationToken token)
        {
            string[] newGenre;
            List<string> resGenre;
            if (genres != null)
            {
                newGenre = genres.Split(',');
                resGenre = new List<string>(newGenre);
            }
            else
            {
                resGenre = new List<string>();
            }
            Book book = new Book(title,authorid,resGenre,yearofpublication,publisherid);
            var response = await this.mediator.Send(new InsertBookRequest { Book = book}, token);
            return this.Ok(response);
        }
        [HttpPut(Name = "UpdateBook/{id}")]
        public async Task<IActionResult> Update(string id, string? title, string? authorid, string? genres, DateTime? yearofpublication, string? publisherid, CancellationToken token)
        {
            var resp = await this.mediator.Send(new GetBookByIdRequest { Id = id }, token);
            Book oldBook;
            if(resp.Book != null)
            {
                oldBook = resp.Book;
            }
            else
            {
                throw new Exception("No book found with given id");
            }
            string[] newGenre;
            List<string> resGenre;
            if (genres != null) 
            {
                newGenre=genres.Split(',');
                resGenre = new List<string>(newGenre);
            }
            else
            {
                resGenre=new List<string>();
            }
           
            var newBook = new Book
            {
                Id = oldBook.Id,
                Title = string.IsNullOrEmpty(title) ? oldBook.Title : title,
                AuthorId = string.IsNullOrEmpty(authorid) ? oldBook.AuthorId : authorid,
                Genres = resGenre.Count() > 0 ? resGenre : oldBook.Genres,
                YearOfPublication = yearofpublication.HasValue ? yearofpublication.Value : oldBook.YearOfPublication,
                PublisherId = string.IsNullOrEmpty(publisherid) ? oldBook.PublisherId : publisherid
            };
            var response = await this.mediator.Send(new UpdateBookByIdRequest { book = newBook }, token);
            return this.Ok(response);

        }



        /*
         * GetAllAsync done?
         * InsertAsync done(no genre)
         * DeleteAsync doneee
         * UpdateAsync
         */
    }
}
