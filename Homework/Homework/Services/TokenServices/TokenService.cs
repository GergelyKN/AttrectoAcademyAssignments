using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Homework.Data;
using Homework.Options;
using Microsoft.Extensions.Options;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Homework.Services
{
	public class TokenService : ITokenService
	{
		private readonly JwtOptions _jwtOptions;
		public TokenService(IOptions<JwtOptions> options)
		{
			_jwtOptions = options.Value;
		}


		public string CreateToken(User user)
		{
			var claims = new List<Claim>
			{
				new (JwtRegisteredClaimNames.Sub, user.Id.ToString()),
				new (JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
			};
			
			var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Key));
			var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
			var expires = DateTime.Now.AddMinutes(30);

			var tokenDescriptor = new JwtSecurityToken(
				_jwtOptions.Issuer,
				_jwtOptions.Issuer,
				claims,
				expires: expires,
				signingCredentials: credentials
			);

			return new JwtSecurityTokenHandler().WriteToken(tokenDescriptor);

		}

		public int? GetUserIdFromToken(ClaimsPrincipal user)
		{
			var userIdClaim = user.Claims.FirstOrDefault(c => c.Type == JwtRegisteredClaimNames.Sub);
			return userIdClaim != null ? int.Parse(userIdClaim.Value) : null;
		}

	}
}