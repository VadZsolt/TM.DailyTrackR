using BookStore.Application.GetAllBooks;
using BookStore.Application.GetBookById;
using BookStore.Application.GetWeatherForecast;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BookStore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BooksController2 : ControllerBase
    {
        private readonly IMediator mediator;
        public BooksController2(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpGet(Name = "GetAllBooks")]
        public async Task<IActionResult> GetAll(int count, CancellationToken cancellationToken)
        {
            var response = await this.mediator.Send(new GetAllBooksRequest { count = count }, cancellationToken);
            return this.Ok(response);
        }
    }
}
