using Homework.Data;
using System.ComponentModel.DataAnnotations;

namespace Homework.Dtos
{
	public class CourseDto
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[MaxLength(25)]
		public string? Name { get; set; }

		[Required]
		[MaxLength(200)]
		public string? Description { get; set; }

		public required UserDto Author { get; set; }
	}
}
