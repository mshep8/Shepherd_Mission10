/*
Mary Catherine Shepherd
IS 413
Mission 10

This class represents the database context for the Bowling League database.
Entity Framework Core uses this class to connect the application to the database
and map C# classes (Bowler and Team) to database tables.
*/

using Microsoft.EntityFrameworkCore;

namespace Shepherd_Mission10.Data
{
    // This class inherits from DbContext, which is the main class used
    // by Entity Framework Core to interact with the database
    public class BowlingLeagueContext : DbContext
    {
        // Constructor that receives database configuration options
        // These options are passed from Program.cs when the app starts
        public BowlingLeagueContext(DbContextOptions<BowlingLeagueContext> options)
            : base(options)
        {
        }

        // DbSet represents a table in the database.
        // This allows us to query and update records in the Bowlers table.
        public DbSet<Bowler> Bowlers { get; set; }

        // This represents the Teams table in the database.
        // Entity Framework will use the Team class to map this table.
        public DbSet<Team> Teams { get; set; }
    }
}