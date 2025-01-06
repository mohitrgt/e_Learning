using AutoMapper;
using eLearning.Domain.Entity;
using eLearning.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearning.Application.Blogs.Commands.UpdateBlog
{
    public class UpdateBlogCommandHandler : IRequestHandler<UpdateBlogCommand, int>
    {
        private readonly IBlogRepository _blogRepository;

        public UpdateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
        }
        public async Task<int> Handle(UpdateBlogCommand request, CancellationToken cancellationToken)
        {
            var blog = new Blog()
            {
                Id = request.Id,
                Name = request.Name,
                Author = request.Author,
                Description = request.Description
            };

            return await _blogRepository.UpdateAsync(blog.Id,blog);
        }
    }
}
