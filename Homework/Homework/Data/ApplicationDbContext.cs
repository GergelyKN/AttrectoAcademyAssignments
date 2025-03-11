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
				.HasOne(c => c.Author)
				.WithMany(u => u.Courses)
				.HasForeignKey(c => c.UserId)
				.OnDelete(DeleteBehavior.Cascade);
		}

		public DbSet<User> Users { get; set; }
		public DbSet<Course> Courses { get; set; }
	}
}
