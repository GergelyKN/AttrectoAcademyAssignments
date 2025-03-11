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


		public List<Course> GetAll()
		{
			return _context.Courses.Include(c => c.Author).ToList();
		}


		public Course? GetById(int id)
		{
			return _context.Courses.Include(c => c.Author).FirstOrDefault(c => c.Id == id);
		}


		public void Create(Course course)
		{
			_context.Courses.Add(course);
			_context.SaveChanges();
		}


		public Course? Update(int id, Course updatedCourseData)
		{
			var course = GetById(id);
			if (course != null)
			{
				course.Name = updatedCourseData.Name;
				course.Description = updatedCourseData.Description;
				course.UserId = updatedCourseData.UserId;

				_context.SaveChanges();

				return course;
			}
			return null;
		}


		public bool Delete(int id)
		{
			var course = GetById(id);
			if (course != null)
			{
				_context.Courses.Remove(course);
				_context.SaveChanges();
				return true;
			}
			return false;
	}
}
