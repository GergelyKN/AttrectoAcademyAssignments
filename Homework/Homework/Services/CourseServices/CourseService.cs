using Homework.Data;
using Homework.Dtos;
using Homework.Repositories;
using Homework.Services.MapperService;

namespace Homework.Services.CourseServices
{
	public class CourseService : ICourseService
	{
		private readonly ICourseRepository _courseRepository;
		private readonly IMapperService _mapperService;
		private readonly IUserService _userService;

		public CourseService(ICourseRepository courseRepository, IMapperService mapperService, IUserService userService)
		{
			_courseRepository = courseRepository;
			_mapperService = mapperService;
			_userService = userService;
		}


		public async Task CreateAsync(CourseDto courseDto)
		{
			
			var existingUser = await _userService.GetByEmailAsync(courseDto.Author.Email);

			if (existingUser == null)
			{
				throw new InvalidOperationException("Author does not exist.");
			}

			var course = new Course
			{
				Name = courseDto.Name,
				Description = courseDto.Description,
				UserId = existingUser.Id
			};

			await _courseRepository.CreateAsync(course);
		}


		public async Task<bool> DeleteAsync(int id)
		{
			return await _courseRepository.DeleteAsync(id);
		}

		public async Task<List<CourseDto>> GetAllAsync()
		{
			var courses = await _courseRepository.GetAllAsync();
			return courses.Select(_mapperService.MapToDtoCourse).ToList();
		}

		public async Task<CourseDto?> GetByIdAsync(int id)
		{
			var course = await _courseRepository.GetByIdAsync(id);
			
			return course == null ? null: _mapperService.MapToDtoCourse(course);
		}

		public async Task<CourseDto?> UpdateAsync(int id, CourseDto courseDto)
		{
			var course = await _courseRepository.GetByIdAsync(id);
			if (course == null)
			{
				return null;
			}

			course.Name = courseDto.Name;
			course.Description = courseDto.Description;


			if (courseDto.Author != null)
			{
				var existingUser = await _userService.GetByEmailAsync(courseDto.Author.Email);

				if (existingUser == null)
				{
					throw new InvalidOperationException("Author does not exist.");
				}

				course.UserId = existingUser.Id;
			}

			await _courseRepository.UpdateAsync();

			return _mapperService.MapToDtoCourse(course);
		}
	}
}
