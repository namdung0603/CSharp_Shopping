using FluentValidation;
using Shopping.ApplicationService.DTO.Request.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shopping.ApplicationService.Validation {
    public class ProductRequestValidation : AbstractValidator<ProductRequest> {
        public ProductRequestValidation() {
            RuleFor(product => product.ProductName)
                .NotEmpty().WithMessage("Vui long nhap ten san pham!");
            RuleFor(product => product.Price)
                .NotEmpty().WithMessage("Vui long nhap gia cua san pham!")
                .WithMessage("Gia tri dua vao khong hop le!");
            RuleFor(product => product.Quantity)
                .NotEmpty().WithMessage("So luong khong duoc de trong!")
                .WithMessage("Gia tri nhap vao khong hop le!");
            RuleFor(product => product.Supplier)
                .NotEmpty().WithMessage("Nha cung cap khong duoc de trong!");
            RuleFor(product => product.Categories)
                .NotEmpty().WithMessage("San pham phai thuoc mot category");
        }

    }
}
