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
using Microsoft.AspNetCore.Mvc.ModelBinding.Binders;

namespace Homework.Services
{
	public class TokenService : ITokenService
	{
		private readonly JwtOptions _jwtOptions;
		private readonly IHttpContextAccessor _httpContextAccessor;

		public TokenService(IOptions<JwtOptions> options, IHttpContextAccessor httpContextAccessor)
		{
			_jwtOptions = options.Value;
			_httpContextAccessor = httpContextAccessor;
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

		public int? GetUserIdFromToken()
		{
			
			if(_httpContextAccessor.HttpContext is not null)
			{
				var userIdClaim = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier);
				if(userIdClaim != null)
				{
					return int.Parse(userIdClaim.Value);
				}

			}

			return null;
		}

	}
}