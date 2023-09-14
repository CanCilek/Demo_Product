using System;
using EntityLayer.Concrete;
using FluentValidation;

namespace BusinessLayer.FluentValidation
{
	public class CustomerValidator : AbstractValidator<Customer>
	{
		public CustomerValidator()
		{
			RuleFor(x=> x.City).NotEmpty().WithMessage("Şehir Bilgisi Boş Geçilemez");
			RuleFor(x => x.Name).NotEmpty().WithMessage("İsim Değeri Boş Geçilemez");

		}
	}
}

