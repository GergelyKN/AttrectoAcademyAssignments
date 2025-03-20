using Homework.Data;
using Homework.Dtos;
using Homework.Repositories;
using Homework.Services.CourseServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CourseController : ControllerBase
	{
		
		private readonly ICourseService _courseService;

		public CourseController(ICourseService courseService)
		{
			_courseService = courseService;
		}


		[Authorize]
		[HttpGet]
		public async Task<IEnumerable<CourseDto>> GetAsync()
		{
			return await _courseService.GetAllAsync();
		}

		[Authorize]
		[HttpGet("{id}", Name = "GetCourseAsync")]
		public async Task<IActionResult> GetAsync(int id)
		{
			var course = await _courseService.GetByIdAsync(id);
			return course == null ? NotFound() : Ok(course);
		}


		[Authorize]
		[HttpPost]
		public async Task<IActionResult> PostAsync([FromBody] CourseDto courseDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			await _courseService.CreateAsync(courseDto);
			return NoContent();
		}

		[Authorize]
		[HttpPut("{id}")]
		public async Task<IActionResult> PutAsync(int id, [FromBody] CourseDto courseDto)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var courseToUpdate = await _courseService.UpdateAsync(id, courseDto);
			return courseToUpdate == null ? NotFound() : Ok(courseToUpdate);
		}

		[Authorize]
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var result = await _courseService.DeleteAsync(id);
			return result ? NoContent() : NotFound();
		}
	}
}
