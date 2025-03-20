using Homework.Data;
using Homework.Dtos;

namespace Homework.Services.MapperService
{
	public interface IMapperService
	{
		UserDto MapToDtoUser(User user);
		User MapToModelUser(UserDto userDto);
		Course MapToModelCourse(CourseDto courseDto);
		CourseDto MapToDtoCourse(Course course);
	}
}
