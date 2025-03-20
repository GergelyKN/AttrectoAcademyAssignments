using Microsoft.EntityFrameworkCore;

namespace Homework.Data
{
	public class ApplicationDbContext : DbContext
	{

		public ApplicationDbContext(DbContextOptions options) : base(options)
		{

		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<Course>()
				.HasMany(c => c.Users)
				.WithMany(u => u.Courses)
				.UsingEntity(j => j.ToTable("CourseUser"));

			modelBuilder.Entity<Course>()
				.HasOne(c => c.Author)
				.WithMany()
				.HasForeignKey(c => c.UserId)
				.OnDelete(DeleteBehavior.Restrict);

		}

		public DbSet<User> Users { get; set; }
		public DbSet<Course> Courses { get; set; }
	}
}
