﻿using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UdemyCarBook.Application.Features.Mediator.Commads.ReviewCommands;

namespace UdemyCarBook.Application.Validators.ReviewValidators
{
    public class CreateReviewValidators:AbstractValidator<CreateReviewCommand>
    {
        public CreateReviewValidators()
        {
            RuleFor(x => x.CustomerName).NotEmpty().WithMessage("Lütfen müşteri adını boş geçmeyiniz!");
            RuleFor(x => x.CustomerName).MinimumLength(5).WithMessage("Lütfen en az 5 karakter veri girişi yapınız");
            RuleFor(x => x.RaytingValue).NotEmpty().WithMessage("Lütfen puan değerini boş geçmeyiniz");
            RuleFor(x => x.Comment).NotEmpty().WithMessage("Lütfen yorum değerini boş geçmeyiniz");
            RuleFor(x => x.Comment).MinimumLength(50).WithMessage("Lütfen yorum kısmına en az 50 karakter veri girişi yapınız");
            RuleFor(x => x.Comment).MinimumLength(500).WithMessage("Lütfen yorum kısmına en fazla 500 karakter veri girişi yapınız");

            
        }
    }
}
