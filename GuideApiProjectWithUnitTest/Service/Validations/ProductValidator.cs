using Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Validations
{
    public class ProductValidator: AbstractValidator<Product>
    {
        public ProductValidator()
        {
            RuleFor(x => x.Name).NotNull().NotEmpty().WithMessage("(PropertyName) is required");
            RuleFor(x => x.Price).InclusiveBetween(1, int.MaxValue).WithMessage("(PropertyName) must be greater than 0");
            RuleFor(x => x.CategoryId).InclusiveBetween(1, int.MaxValue).WithMessage("(PropertyName) must be greater than 0");
        }
    }
}
