using Homework.Data;

namespace Homework.Repositories
{
	public class CourseRepository
	{
		private readonly ApplicationDbContext _context;


		public CourseRepository()
		{
			_context = new ApplicationDbContext();
		}


		public List<Course> GetAll()
		{
			return _context.Courses.ToList();
		}


		public Course? GetById(int id)
		{
			return _context.Courses.FirstOrDefault(c => c.Id == id);
		}


		public void Create(Course course)
		{
			_context.Courses.Add(course);
			_context.SaveChanges();
		}


		public Course? Update(int id, Course updatedCourseData)
		{
			var course = GetById(id);
			if(course != null)
			{
				course.Name = updatedCourseData.Name;
				course.Description = updatedCourseData.Description;

				_context.SaveChanges();

				return course;
			}
			return null;
		}


		public bool Delete(int id)
		{
			var course = GetById(id);
			if(course != null)
			{
				_context.Courses.Remove(course);
				_context.SaveChanges();
				return true;
			}
			return false;
		}	
	}
}
