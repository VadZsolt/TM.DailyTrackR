using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.UpdateBookById
{
    public class UpdateBookByIdValidator : AbstractValidator<UpdateBookByIdResponse>
    {
        public UpdateBookByIdValidator() 
        {
            this.RuleFor(response => response.Updated).NotEmpty();
        }
    }
}
