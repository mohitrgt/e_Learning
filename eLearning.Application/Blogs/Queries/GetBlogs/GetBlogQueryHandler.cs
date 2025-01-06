using AutoMapper;
using eLearning.Domain.Repository;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearning.Application.Blogs.Queries.GetBlogs
{
    public class GetBlogQueryHandler : IRequestHandler<GetBlogQuery, List<BlogVm>>
    {
        private readonly IBlogRepository _blogRepository;
        private readonly IMapper _mapper;

        public GetBlogQueryHandler(IBlogRepository blogRepository,IMapper mapper)
        {
            _blogRepository = blogRepository;
            _mapper = mapper;
        }
        async Task<List<BlogVm>> IRequestHandler<GetBlogQuery, List<BlogVm>>.Handle(GetBlogQuery request, CancellationToken cancellationToken)
        {
            var blogs = await _blogRepository.GetAllAsync();
            //var blogList = blogs.Select(b => new BlogVm
            //{
            //    Author = b.Author,
            //    Name = b.Name,
            //    Description = b.Description,
            //    Id = b.Id
            //}).ToList();

            var blogList = _mapper.Map<List<BlogVm>>(blogs);

            return blogList;
        }
    }
}
