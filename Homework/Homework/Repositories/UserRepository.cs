using Homework.Data;
using Microsoft.EntityFrameworkCore;

namespace Homework.Repositories
{
	public class UserRepository : IUserRepository
	{
		private readonly ApplicationDbContext _context;


		public UserRepository(ApplicationDbContext context)
		{
			_context = context;
		}


		public List<User> GetAll()
		{
			return _context.Users.Include(u => u.Courses).ToList();
		}


		public User? GetById(int id)
		{
			return _context.Users.Include(u => u.Courses).FirstOrDefault(user => user.Id == id);
		}


		public List<User> GetAdultUsers()
		{
			return _context.Users.Include(u => u.Courses).Where(u => u.Age >= 18).ToList();
		}


		public void Create(User data)
		{
			_context.Users.Add(data);
			_context.SaveChanges();
		}


		public User? Update(int id, User data)
		{

			var user = GetById(id);

			if (user != null)
			{
				user.Name = data.Name;
				user.Role = data.Role;
				user.Courses = data.Courses;
				_context.SaveChanges();

				return user;
			}

			return null;
		}


		public bool Delete(int id)
		{
			var user = GetById(id);

			if (user != null)
			{
				_context.Users.Remove(user);
				_context.SaveChanges();

				return true;
			}

			return false;
		}
	}
}
