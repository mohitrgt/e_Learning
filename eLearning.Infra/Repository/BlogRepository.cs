using eLearning.Application.Blogs.Queries.GetBlogs;
using eLearning.Domain.Entity;
using eLearning.Domain.Repository;
using eLearning.Infra.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearning.Infra.Repository
{
    public class BlogRepository : IBlogRepository
    {
        private readonly BlogDbContext _blogDbContext;

        public BlogRepository(BlogDbContext blogDbContext)
        {
            _blogDbContext = blogDbContext;
        }
        public async Task<Blog> CreateAsync(Blog blog)
        {
            await _blogDbContext.AddAsync(blog);
            await _blogDbContext.SaveChangesAsync();
            return blog;
        }

        public async Task<int> DeleteAsync(int Id)
        {
            return await _blogDbContext.Blogs.Where(model => model.Id == Id)
                .ExecuteDeleteAsync();
        }

        public async Task<List<Blog>> GetAllAsync()
        {
            return await _blogDbContext.Blogs.ToListAsync();
        }

        public async Task<Blog> GetByIdAsync(int Id)
        {
            return await _blogDbContext.Blogs.AsNoTracking().
                 FirstOrDefaultAsync(b => b.Id == Id);
        }

        public async Task<int> UpdateAsync(int Id, Blog blog)
        {
            return await _blogDbContext.Blogs.Where(model => model.Id == Id).ExecuteUpdateAsync(
                setters => setters
                .SetProperty(m => m.Name , blog.Name)
                .SetProperty(m => m.Author , blog.Author)
                .SetProperty(m => m.Description , blog.Description)
                );
        }
    }
}
