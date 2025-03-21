using System.Text;
using Homework.Data;
using Homework.Options;
using Homework.Repositories;
using Homework.Services;
using Homework.Services.AccountServices;
using Homework.Services.CourseServices;
using Homework.Services.MapperService;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
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


			builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection(nameof(JwtOptions)));

			builder.Services.AddScoped<IUserRepository, UserRepository>();
			builder.Services.AddScoped<IUserService, UserService>();
			builder.Services.AddScoped<ITokenService, TokenService>();
			builder.Services.AddScoped<IAccountService, AccountService>();

			builder.Services.AddScoped<ICourseRepository, CourseRepository>();
			builder.Services.AddScoped<ICourseService, CourseService>();

			builder.Services.AddScoped<IMapperService,MapperService>();

			builder.Services.AddHttpContextAccessor();

			builder.Services.AddDbContext<ApplicationDbContext>(options =>
				options.UseSqlite(builder.Configuration.GetConnectionString("ApplicationDbContext")));

			


			builder.Services.AddSwaggerGen(c => {
				c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
				{
					Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
						Enter 'Bearer' [space] and then your token in the text input below.
						\r\n\r\nExample: 'Bearer 12345abcdef'",
					Name = "Authorization",
					In = ParameterLocation.Header,
					Type = SecuritySchemeType.ApiKey,
					Scheme = "Bearer"
				});
				c.AddSecurityRequirement(new OpenApiSecurityRequirement()
				{
					{
						new OpenApiSecurityScheme
							{
								Reference = new OpenApiReference
								{
									Type = ReferenceType.SecurityScheme,
									Id = "Bearer"
								},
									Scheme = "oauth2",
									Name = "Bearer",
									 In = ParameterLocation.Header,
							},
							new List<string>()
					}
				});
			});


			builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(opt =>
			{
				opt.TokenValidationParameters = new()
				{
					ValidateIssuer = true,
					ValidateAudience = true,
					ValidateLifetime = true,
					ValidateIssuerSigningKey = true,
					ValidIssuer = builder.Configuration["JwtOptions:Issuer"],
					ValidAudience = builder.Configuration["JwtOptions:Issuer"],
					IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtOptions:Key"]!))
				};
			});

			builder.Services.AddAuthorization();

			builder.Services.AddHttpContextAccessor();

			var app = builder.Build();

			if (app.Environment.IsDevelopment())
			{
				app.UseSwagger();
				app.UseSwaggerUI();
			}

			app.UseHttpsRedirection();
			app.UseAuthentication();
			app.UseAuthorization();
			app.MapControllers();
			app.Run();
		}
	}
}
