using System.Threading.Tasks;
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



		public async Task<List<User>> GetAllAsync()
		{
			return await _context.Users.Include(u => u.Courses).ToListAsync();
		}


		public async Task<User?> GetByIdAsync(int id)
		{
			return await _context.Users.Include(u => u.Courses).FirstOrDefaultAsync(user => user.Id == id);
		}


		public async Task<User?> GetByEmailAsync(string email)
		{
			return await _context.Users.Include(u => u.Courses).FirstOrDefaultAsync(u => u.Email == email);
		}

		public async Task<List<User>> GetAdultUsersAsync()
		{
			return await _context.Users.Include(u => u.Courses).Where(u => u.Age >= 18).ToListAsync();
		}


		public async Task CreateAsync(User data)
		{
			await _context.Users.AddAsync(data);
			await _context.SaveChangesAsync();
		}


		public async Task<int> UpdateAsync()
		{
			return await _context.SaveChangesAsync();
			
		}


		public async Task<bool> DeleteAsync(int id)
		{
			var user = await GetByIdAsync(id);

			if (user != null)
			{
				_context.Users.Remove(user);
				await _context.SaveChangesAsync();

				return true;
			}

			return false;
		}
	}
}
