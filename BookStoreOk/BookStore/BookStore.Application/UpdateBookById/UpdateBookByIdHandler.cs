using BookStore.Application.InsertBook;
using BookStore.Data.Abstractions;
using BookStore.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.UpdateBookById
{
    public class UpdateBookByIdHandler : IRequestHandler<UpdateBookByIdRequest, UpdateBookByIdResponse>
    {
        private readonly IBookRepository bookRepository;
        public UpdateBookByIdHandler(IBookRepository bookRepository)
        {
            this.bookRepository = bookRepository;
        }
        public async Task<UpdateBookByIdResponse> Handle(UpdateBookByIdRequest request, CancellationToken cancellationToken)
        {
            Book bookI = request.book;
            var book = await this.bookRepository.UpdateAsync(bookI, cancellationToken);
            return new UpdateBookByIdResponse { Updated = book };
        }
    }
}
