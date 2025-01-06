using eLearning.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eLearning.Domain.Repository
{
    public interface IBlogRepository
    {
        Task<List<Blog>> GetAllAsync();
        Task<Blog> GetByIdAsync(int BlogId);
        Task<Blog> CreateAsync(Blog blog);
        Task<int> UpdateAsync(int Id, Blog blog);
        Task<int> DeleteAsync(int Id);
    }
}
