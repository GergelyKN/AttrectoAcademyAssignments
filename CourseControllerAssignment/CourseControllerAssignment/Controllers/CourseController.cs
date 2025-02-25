using CourseControllerAssignment.Data;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CourseControllerAssignment.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class CourseController : ControllerBase
	{

		public static List<Course> Courses = new List<Course>();

		// GET: api/<CourseController>
		[HttpGet]
		public IEnumerable<Course> Get()
		{
			return Courses;
		}

		// GET api/<CourseController>/5
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

		// POST api/<CourseController>
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

		// PUT api/<CourseController>/5
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

		// DELETE api/<CourseController>/5
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
