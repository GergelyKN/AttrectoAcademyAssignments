using Homework.Data;
using Homework.Dtos;

namespace Homework.Services.MapperService
{
	public class MapperService : IMapperService
	{
		public UserDto MapToDtoUser(User user) => new()
		{
			Id = user.Id,
			Name = user.Name,
			Email = user.Email,
			Role = user.Role,
			Password = user.Password,
			Age = user.Age,
		};

		public CourseDto MapToDtoCourse(Course course) => new()
		{
			Id = course.Id,
			Author = MapToDtoUser(course.Author),
			Description = course.Description,
			Name = course.Name,
		};

		public User MapToModelUser(UserDto userDto) => new()
		{
			Id = userDto.Id,
			Name = userDto.Name,
			Email = userDto.Email,
			Role = userDto.Role,
			Age = userDto.Age,
			Password = userDto.Password
		};

		public Course MapToModelCourse(CourseDto courseDto) => new()
		{
			Id = courseDto.Id,
			Author = MapToModelUser(courseDto.Author),
			Description = courseDto.Description,
			Name = courseDto.Name,
		};
	}
}
