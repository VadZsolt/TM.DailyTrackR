using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.Application.InsertBook
{
    public class InsertBookValidator : AbstractValidator<InsertBookRequest>
    {
        public InsertBookValidator() 
        {
            this.RuleFor(request => request.Book).NotEmpty();
        }
    }
}
