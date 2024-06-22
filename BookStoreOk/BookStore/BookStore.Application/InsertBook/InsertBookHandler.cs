using BookStore.Data.Abstractions;
using BookStore.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.InsertBook
{
    public class InsertBookHandler : IRequestHandler<InsertBookRequest, InsertBookResponse>
    {
        private readonly IBookRepository bookRepository;
        public InsertBookHandler(IBookRepository bookRepository) 
        {
            this.bookRepository = bookRepository;
        }
        public async Task<InsertBookResponse> Handle(InsertBookRequest request, CancellationToken cancellationToken)
        {
            Book bookI = request.Book;
            var book = await this.bookRepository.InsertAsync(bookI, cancellationToken);
            return new InsertBookResponse { Inserted = book };
        }
    }
}
