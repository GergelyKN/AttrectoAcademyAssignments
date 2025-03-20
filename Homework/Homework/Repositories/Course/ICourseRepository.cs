using Homework.Data;

namespace Homework.Repositories
{
	public interface ICourseRepository
	{
		Task CreateAsync(Course course);
		Task<bool> DeleteAsync(int id);
		Task<List<Course>> GetAllAsync();
		Task<Course?> GetByIdAsync(int id);
		Task<int> UpdateAsync();
	}
}