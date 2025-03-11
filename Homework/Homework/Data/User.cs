using System.ComponentModel.DataAnnotations;

namespace Homework.Data
{
	public class User
	{
		[Key]
		public int Id { get; set; }


    [Required]
    [MaxLength(50)]
    public string? Name { get; set; }


		[Required]
		[MaxLength(15)]
		public string? Role { get; set; }


		[Required]
    [Range(0, 125, ErrorMessage = "Age must be between 0 and 125!")]
    public int Age { get; set; }


		public List<Course>? Courses { get; set; } = [];

	}
}
