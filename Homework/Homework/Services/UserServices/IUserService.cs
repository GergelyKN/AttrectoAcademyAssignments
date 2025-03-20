using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Homework.Data;
using Homework.Dtos;

namespace Homework.Services
{
	public interface IUserService
	{
		Task CreateAsync(UserDto data);
		Task<bool> DeleteAsync(int id);
		Task<List<UserDto>> GetAllAsync();
		Task<List<UserDto>> GetAdultUsersAsync();
		Task<UserDto?> GetByEmailAsync(string email);
		Task<UserDto?> GetByIdAsync(int id);
		Task<UserDto?> UpdateAsync(int id, UserDto data);
	}
}