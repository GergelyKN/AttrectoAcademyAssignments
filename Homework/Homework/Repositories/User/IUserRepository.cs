using Homework.Data;

namespace Homework.Repositories
{
	public interface IUserRepository
	{
		Task CreateAsync(User data);
		Task<bool> DeleteAsync(int id);
		Task<List<User>> GetAdultUsersAsync();
		Task<List<User>> GetAllAsync();
		Task<User?> GetByIdAsync(int id);
		Task<User?> GetByEmailAsync(string email);
		Task<int> UpdateAsync();
	}
}