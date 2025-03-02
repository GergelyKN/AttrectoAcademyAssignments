using Homework.Data;

namespace Homework.Repositories
{
	public class UserRepository
	{
		private readonly ApplicationDbContext _context;


		public UserRepository()
		{
			_context = new ApplicationDbContext();
		}


		public List<User> GetAll()
		{
			return _context.Users.ToList();
		}


		public User? GetById(int id)
		{
			return _context.Users.FirstOrDefault(user => user.Id == id);
		}


		public List<User> GetAdultUsers()
		{
			return _context.Users.Where(u => u.Age >= 18).ToList();
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
				user.FirstName = data.FirstName;
				user.LastName = data.LastName;
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
