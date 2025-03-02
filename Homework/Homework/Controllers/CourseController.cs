using Homework.Data;
using Homework.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CourseController : ControllerBase
	{
		
		private readonly CourseRepository _repository;

		public CourseController()
        {
			_repository = new CourseRepository();
        }


        [HttpGet]
		public IActionResult Get()
		{
			return Ok(_repository.GetAll());
		}


		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var course = _repository.GetById(id);
			return course == null ? NotFound() : Ok(course);
		}


		[HttpPost]
		public IActionResult Post([FromBody] Course course)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			_repository.Create(course);
			return CreatedAtAction(nameof(Get), new { id = course.Id }, course);
		}


		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] Course course)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var courseToUpdate = _repository.Update(id, course);
			return courseToUpdate == null ? NotFound() : Ok(courseToUpdate);
		}


		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var result = _repository.Delete(id);
			return result ? NoContent() : NotFound();
		}
	}
}
