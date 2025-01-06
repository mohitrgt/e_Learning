using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearning.Application.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandValidator : AbstractValidator<CreateBlogCommand>
    {
        public CreateBlogCommandValidator()
        {
            RuleFor(v => v.Name).NotEmpty()
                .WithMessage("Name is required.")
                .MaximumLength(30).WithMessage("Name must not exceed 30 cherecters.");

            RuleFor(v => v.Description).NotEmpty()
                .WithMessage("Description is required.");

            RuleFor(v => v.Author).NotEmpty()
                .WithMessage("Author is required.")
                .MaximumLength(30).WithMessage("Author must not exceed 30 cherecters.");
        }
    }
}
