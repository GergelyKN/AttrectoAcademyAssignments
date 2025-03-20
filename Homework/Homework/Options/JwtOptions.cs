using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework.Options
{
	public class JwtOptions
	{
		public required string Key { get; set; }
		public required string Issuer { get; set; }
	}
}