﻿using System.ComponentModel.DataAnnotations;

namespace Homework.Data
{
	public class User
	{
		[Key]
		public int Id { get; set; }


		[Required]
		[MaxLength(50)]
		public string? FirstName { get; set; }


		[Required]
		[MaxLength(50)]
		public string? LastName { get; set; }
	}
}
