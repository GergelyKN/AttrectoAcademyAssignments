using System.ComponentModel.DataAnnotations;

namespace CourseControllerAssignment.Data
{
	public class Course
	{
		public int Id { get; set; }

		[Required]
		[MaxLength(25)]
		public string? Name { get; set; }

		[Required]
		[MaxLength(200)]
		public string? Description { get; set; }

	}
}
