using FluentValidation;
using Top10LibrariesSampleProject.Model;

namespace Top10LibrariesSampleProject.Validator
{
    public class ProductValidator:AbstractValidator<AddUpdateProductDTO>
    {
        public ProductValidator()
        {
            RuleFor(product => product.ProductName).NotNull().WithMessage("Name cannot be null"); ;
            RuleFor(product => product.ProductCategory).NotNull().WithMessage("Category cannot be null"); ;
        }
    }
}
