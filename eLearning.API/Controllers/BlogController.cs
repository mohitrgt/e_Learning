using eLearning.Application.Blogs.Commands.CreateBlog;
using eLearning.Application.Blogs.Commands.DeleteBlog;
using eLearning.Application.Blogs.Commands.UpdateBlog;
using eLearning.Application.Blogs.Queries.GetBlogById;
using eLearning.Application.Blogs.Queries.GetBlogs;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace eLearning.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogController : ApiControllerBase
    {
        [HttpGet]
        [Route("GetAll")]
        public async Task<IActionResult> GetAllAsync()
        {
            try
            {
                var result = await Mediator.Send(new GetBlogQuery());
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request." + ex.Message);
            }
        }

        [HttpGet("GetById/{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            try
            {
                var result = await Mediator.Send(new GetBlogByIdQuery { BlogId = id });
                return result != null ? Ok(result) : NotFound($"Blog with ID {id} not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request." + ex.Message);
            }
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateAsync([FromBody] CreateBlogCommand command)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return BadRequest(ModelState);
                }

                var result = await Mediator.Send(command);

                if (result == null)
                {
                    return StatusCode(StatusCodes.Status500InternalServerError, "Blog creation failed.");
                }

                //return CreatedAtAction(nameof(GetAllAsync), new { id = result.Id }, result);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request." + ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(int id, [FromBody] UpdateBlogCommand command)
        {
            try
            {
                if (!ModelState.IsValid)
                    return BadRequest(ModelState);

                command.Id = id;
                var result = await Mediator.Send(command);
                return result != null ? Ok(result) : NotFound($"Blog with ID {id} not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request." + ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(int id)
        {
            try
            {
                var result = await Mediator.Send(new DeleteBlogCommand { Id = id });

                if (result != null)
                {
                    return NoContent();
                }
                return NotFound($"Blog with ID {id} not found.");
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing your request." + ex.Message);
            }
        }

    }
}
