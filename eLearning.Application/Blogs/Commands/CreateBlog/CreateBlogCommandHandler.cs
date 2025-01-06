using AutoMapper;
using eLearning.Application.Blogs.Queries.GetBlogs;
using eLearning.Domain.Entity;
using eLearning.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearning.Application.Blogs.Commands.CreateBlog
{
    public class CreateBlogCommandHandler : IRequestHandler<CreateBlogCommand, BlogVm>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public CreateBlogCommandHandler(IBlogRepository blogRepository, IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
        public async Task<BlogVm> Handle(CreateBlogCommand request, CancellationToken cancellationToken)
        {
            var blogEntity = new Blog() { Name = request.Name, Author = request.Author, Description = request.Description };
            var result = await _blogRepository.CreateAsync(blogEntity);
            return _mapper.Map<BlogVm>(result);
        }
    }
}
