using Homework.Dtos;

namespace Homework.Services.CourseServices
{
	public interface ICourseService
	{
		Task<List<CourseDto>> GetAllAsync();
		Task<CourseDto?> GetByIdAsync(int id);
		Task CreateAsync(CourseDto courseDto);
		Task<CourseDto?> UpdateAsync(int id, CourseDto courseDto);
		Task<bool> DeleteAsync(int id);

	}
}
