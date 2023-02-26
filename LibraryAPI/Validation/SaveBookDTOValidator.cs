using FluentValidation;
using LibraryApplication.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LibraryAPI.Validation
{
    public class SaveBookDTOValidator : AbstractValidator<SaveBookDTO>
    {
        public SaveBookDTOValidator()
        {
            RuleFor(x => x.Title).NotEmpty().MaximumLength(100);
            RuleFor(x => x.Cover).NotEmpty().Matches(@"^data:image\/[a-z]+;base64,").MaximumLength(100000);
            RuleFor(x => x.Content).NotEmpty().MaximumLength(1000000);
            RuleFor(x => x.Genre).NotEmpty().MaximumLength(50);
            RuleFor(x => x.Author).NotEmpty().MaximumLength(100);
        }
    }
}
