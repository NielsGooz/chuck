using ChuckNoris.Api.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;

namespace ChuckNoris.Api.DAL
{
	public class ChuckContext : DbContext
	{
		public ChuckContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
		{
			var dbCreator = Database.GetService<IDatabaseCreator>() as RelationalDatabaseCreator;
			if (dbCreator != null)
			{
				if (!dbCreator.CanConnect())
				{
					dbCreator.Create();
				}

				if (!dbCreator.HasTables())
				{
					dbCreator.CreateTables();
				}
			}
		}

		public DbSet<ChuckFact> Facts { get; set; }

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
            modelBuilder.Entity<ChuckFact>().HasData(
				new ChuckFact(){ Id = 1, Rating = 10, Text = "Chuck Norris doesn't read books. He stares them down until he gets the information he wants" },
                new ChuckFact() { Id = 2, Rating = 5, Text = "Time waits for no man. Unless that man is Chuck Norris." },
                new ChuckFact() { Id = 3, Rating = 3, Text = "If you spell Chuck Norris in Scrabble, you win. Forever." },
                new ChuckFact() { Id = 4, Rating = 5, Text = "Chuck Norris breathes air ... five times a day." },
                new ChuckFact() { Id = 5, Rating = 3, Text = "In the Beginning there was nothing ... then Chuck Norris roundhouse kicked nothing and told it to get a job." },
                new ChuckFact() { Id = 6, Rating = 6, Text = "When God said, “Let there be light!” Chuck Norris said, “Say Please.”" },
                new ChuckFact() { Id = 7, Rating = 5, Text = "Chuck Norris has a mug of nails instead of coffee in the morning." },
                new ChuckFact() { Id = 8, Rating = 8, Text = "If Chuck Norris were to travel to an alternate dimension in which there was another Chuck Norris and they both fought, they would both win." },
                new ChuckFact() { Id = 9, Rating = 4, Text = "The dinosaurs looked at Chuck Norris the wrong way once. You know what happened to them." });
        }
	}
}
