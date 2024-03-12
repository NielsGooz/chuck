using ChuckNoris.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace ChuckNoris.Api.DAL
{
	public class ChuckContext : DbContext
	{
		public ChuckContext(DbContextOptions dbContextOptions) : base(dbContextOptions) { }

		public DbSet<ChuckFact> Facts { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
		}
	}
}
