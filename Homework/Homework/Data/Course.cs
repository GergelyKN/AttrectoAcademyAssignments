using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Homework.Data
{
	public class Course
	{
		[Key]
		public int Id { get; set; }


		[Required]
		[MaxLength(25)]
		public string? Name { get; set; }


		[Required]
		[MaxLength(200)]
		public string? Description { get; set; }


        public int? UserId { get; set; }

		[ForeignKey("UserId")]
        public User? Author { get; set; }
    }
}
