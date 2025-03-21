using Homework.Data;
using Homework.Dtos;
using Homework.Repositories;
using Homework.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Homework.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{

		private readonly IUserService _userService;
		private readonly ITokenService _tokenService;

		public UsersController(IUserService userService, ITokenService tokenService)
		{
			_userService = userService;
			_tokenService = tokenService;
		}



		[Authorize]
		[HttpGet]
		public async Task<IEnumerable<UserDto>> GetAsync()
		{
			return await _userService.GetAllAsync();
		}


		[Authorize]
		[HttpGet("{id}")]
		public async Task<IActionResult> GetAsync(int id)
		{
			var user = await _userService.GetByIdAsync(id);
			return user == null ? NotFound() : Ok(user);
		}

		[Authorize]
		[HttpGet("me")]
		public async Task<IActionResult> GetMeAsync()
		{
			var userId = _tokenService.GetUserIdFromToken();
			if (userId != null)
			{
				var user = await _userService.GetByIdAsync(userId.Value);
				return Ok(user);
			}

			return NotFound();
		}



		[Authorize]
		[HttpGet("adults")]
		public async Task<IEnumerable<UserDto>> GetAdultUsers()
		{
			return await _userService.GetAdultUsersAsync();
		}


		[AllowAnonymous]
		[HttpPost]
		public async Task<IActionResult> PostAsync([FromBody] UserDto data)
		{
			await _userService.CreateAsync(data);
			return NoContent();
		}


		[Authorize]
		[HttpPut("{id}")]
		public async Task<IActionResult> PutAsync(int id, [FromBody] UserDto data)
		{
			var user = await _userService.UpdateAsync(id, data);
			return user == null ? NotFound() : Ok(user);
		}


		[Authorize]
		[HttpDelete("{id}")]
		public async Task<IActionResult> DeleteAsync(int id)
		{
			var result = await _userService.DeleteAsync(id);
			return result ? NoContent() : NotFound();
		}
	}
}
