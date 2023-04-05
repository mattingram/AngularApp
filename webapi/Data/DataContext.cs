using Microsoft.EntityFrameworkCore;

namespace webapi.Data
{
	public class DataContext : DbContext
	{
		public DataContext(DbContextOptions<DataContext> options) : base (options) {}

		public DbSet<SuperHero> SuperHeroes => Set<SuperHero>();

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			modelBuilder.Entity<SuperHero>().HasData(
				new List<SuperHero>
				{
					new SuperHero
					{
						Id = -1,
						FirstName = "Peter",
						LastName = "Parker",
						Name = "Spider Man",
						Place = "NYC"
					}
				});
			base.OnModelCreating(modelBuilder);
		}
	}
}
