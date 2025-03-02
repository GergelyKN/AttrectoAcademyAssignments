using Homework.Data;
using Homework.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Homework.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class UsersController : ControllerBase
	{
		private readonly UserRepository _repository;


		public UsersController()
		{
			_repository = new UserRepository();
		}


		[HttpGet]
		public IEnumerable<User> Get()
		{
			return _repository.GetAll();
		}


		[HttpGet("{id}")]
		public IActionResult Get(int id)
		{
			var user = _repository.GetById(id);
			return user == null ? NotFound() : Ok(user);
		}


		[HttpPost]
		public IActionResult Post([FromBody] User data)
		{
			_repository.Create(data);
			return NoContent();
		}


		[HttpPut("{id}")]
		public IActionResult Put(int id, [FromBody] User data)
		{
			var user = _repository.Update(id, data);
			return user == null ? NotFound() : Ok(user);
		}


		[HttpDelete("{id}")]
		public IActionResult Delete(int id)
		{
			var result = _repository.Delete(id);
			return result ? NoContent() : NotFound();
		}
	}
}
