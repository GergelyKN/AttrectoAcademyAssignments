using Homework.Data;

namespace Homework.Repositories
{
	public interface ICourseRepository
	{
		void Create(Course course);
		bool Delete(int id);
		List<Course> GetAll();
		Course? GetById(int id);
		Course? Update(int id, Course updatedCourseData);
	}
}