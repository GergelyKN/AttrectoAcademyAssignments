using Homework.Data;
using Homework.Repositories;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;

namespace Homework
{
	public class Program
	{
		public static void Main(string[] args)
		{
			var builder = WebApplication.CreateBuilder(args);


			builder.Services.AddControllers()
				.AddNewtonsoftJson(options =>
				{	
					options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
				});

			builder.Services.AddEndpointsApiExplorer();
			builder.Services.AddSwaggerGen();


			builder.Services.AddScoped<IUserRepository, UserRepository>();
			builder.Services.AddScoped<ICourseRepository, CourseRepository>();

			builder.Services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlite(builder.Configuration.GetConnectionString("ApplicationDbContext")));

			var app = builder.Build();

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();
			app.UseAuthorization();
			app.MapControllers();
			app.Run();
		}
	}
}
