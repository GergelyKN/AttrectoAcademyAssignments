using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Homework.Dtos
{
	public class UserDto
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

		[EmailAddress]
		public required string Email { get; set; }

		public required string Password { get; set; }
        
    }
}