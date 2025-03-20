using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Homework.Data;

namespace Homework.Services
{
	public interface ITokenService
	{
		string CreateToken(User user);
		int? GetUserIdFromToken(ClaimsPrincipal user);
	}
}