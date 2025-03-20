using Homework.Data;
using Microsoft.EntityFrameworkCore;

namespace Homework.Repositories
{
	public class CourseRepository : ICourseRepository
	{

		private readonly ApplicationDbContext _context;

		public CourseRepository(ApplicationDbContext context)
		{
			_context = context;
		}



		public async Task<List<Course>> GetAllAsync()
		{
			return await _context.Courses.Include(c => c.Author).ToListAsync();
		}


		public async Task<Course?> GetByIdAsync(int id)
		{
			return await _context.Courses.Include(c => c.Author).FirstOrDefaultAsync(c => c.Id == id);
		}


		public async Task CreateAsync(Course course)
		{
			await _context.Courses.AddAsync(course);
			await _context.SaveChangesAsync();
		}


		public async Task<int> UpdateAsync()
		{
			return await _context.SaveChangesAsync();
		}


		public async Task<bool> DeleteAsync(int id)
		{
			var course = await GetByIdAsync(id);
			if (course != null)
			{
				_context.Courses.Remove(course);
				await _context.SaveChangesAsync();
				return true;
			}
			return false;
		}
	}
}
