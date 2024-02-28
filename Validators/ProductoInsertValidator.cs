using FluentValidation;
using Proyecto_01.DTOs;

namespace Proyecto_01.Validators
{
    public class ProductoInsertValidator : AbstractValidator<ProductoInsertDto>
    {

        public ProductoInsertValidator() {

            RuleFor(x => x.Nombre).NotEmpty().WithMessage("El nombre es obligatorio");
            RuleFor(X => X.Nombre).Length(2,50).  WithMessage("El nombre debe tener entre 2-10 caracteres");
            RuleFor(x => x.IdCategoria).NotEmpty().WithMessage("El producto debe contener una categoria");
        
        }

    }
}
