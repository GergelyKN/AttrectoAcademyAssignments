using Homework.Data;
using Homework.Dtos;
using Homework.Repositories;
using Homework.Services.MapperService;

namespace Homework.Services
{
	public class UserService : IUserService
	{
		private readonly IUserRepository _userRepository;
		private readonly IMapperService _mapperService;

		public UserService(IUserRepository userRepository, IMapperService mapperService)
		{
			_userRepository = userRepository;
			_mapperService = mapperService;
		}

		public async Task<UserDto?> GetByEmailAsync(string email)
		{
			var user = await _userRepository.GetByEmailAsync(email);
			if(user != null)
			{
				return _mapperService.MapToDtoUser(user);
			}

			return null;
		}

		public async Task CreateAsync(UserDto data)
		{
			if (await GetByEmailAsync(data.Email) != null)
			{
				throw new InvalidOperationException("Email already in use.");
			}

			var hashedPassword = BCrypt.Net.BCrypt.HashPassword(data.Password);
			data.Password = hashedPassword;

			await _userRepository.CreateAsync(_mapperService.MapToModelUser(data));
		}

		public Task<bool> DeleteAsync(int id)
			=> _userRepository.DeleteAsync(id);

		public async Task<List<UserDto>> GetAllAsync()
		{
			var users = await _userRepository.GetAllAsync();

			return users.Select(_mapperService.MapToDtoUser).ToList();
		}

		public async Task<UserDto?> GetByIdAsync(int id)
		{
			var user = await _userRepository.GetByIdAsync(id);

			return user != null ? _mapperService.MapToDtoUser(user) : null;
		}


		public async Task<UserDto?> UpdateAsync(int id, UserDto data)
		{
			var user = await _userRepository.GetByIdAsync(id);

			if (user != null)
			{
				user.Name = data.Name;

				await _userRepository.UpdateAsync();
			}

			return user != null ? _mapperService.MapToDtoUser(user) : null;
		}

		public async Task<List<UserDto>> GetAdultUsersAsync()
		{
			var users = (await _userRepository.GetAdultUsersAsync())
							.Select(_mapperService.MapToDtoUser).ToList();
			return users;
		}
	}
}