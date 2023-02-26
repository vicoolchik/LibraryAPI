using FluentValidation;
using LibraryApplication.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Validation
{
    public class ReviewDTOValidator : AbstractValidator<ReviewDTO>
    {
        public ReviewDTOValidator()
        {
            RuleFor(x => x.Message).NotEmpty().MaximumLength(1000);
            RuleFor(x => x.Reviewer).NotEmpty().MaximumLength(100);
        }
    }
}
