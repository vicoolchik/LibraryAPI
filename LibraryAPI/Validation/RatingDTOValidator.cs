using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Validation
{
    public class RatingDTOValidator : AbstractValidator<int>
    {
        public RatingDTOValidator()
        {
            RuleFor(x => x)
                .InclusiveBetween(1, 5).WithMessage("The rating score must be between 1 and 5.");
        }
    }
}
