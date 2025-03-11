using Homework.Data;

namespace Homework.Repositories
{
	public interface IUserRepository
	{
		void Create(User data);
		bool Delete(int id);
		List<User> GetAdultUsers();
		List<User> GetAll();
		User? GetById(int id);
		User? Update(int id, User data);
	}
}