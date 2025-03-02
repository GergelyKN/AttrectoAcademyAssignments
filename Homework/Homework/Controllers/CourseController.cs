using Homework.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CourseController : ControllerBase
	{
		public static List<Course> Courses = new List<Course>();


		[HttpGet]
		public IEnumerable<Course> Get()
		{
			return Courses;
		}


		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var course = Courses.FirstOrDefault(x => x.Id == id);

			if (course != null)
			{
				return Ok(course);
			}

			return NotFound();
		}


		[HttpPost]
		public IActionResult Post([FromBody] Course course)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			Courses.Add(course);

			return CreatedAtAction(nameof(Get), new { id = course.Id }, course);
		}


		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] Course course)
		{
			if (!ModelState.IsValid)
			{
				return BadRequest(ModelState);
			}

			var courseToUpdate = Courses.FirstOrDefault(x => x.Id == id);
			if (courseToUpdate != null)
			{
				courseToUpdate.Description = course.Description;
				courseToUpdate.Name = course.Name;

				return Ok(courseToUpdate);
			}

			return NotFound();
		}


		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var courseToDelete = Courses.FirstOrDefault(x => x.Id == id);
			if (courseToDelete != null)
			{
				Courses.Remove(courseToDelete);
				return NoContent();
			}

			return NotFound();
		}
	}
}
