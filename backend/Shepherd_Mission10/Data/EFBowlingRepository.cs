/*
Mary Catherine Shepherd
IS 413
Mission 10

This class is the Entity Framework implementation of the bowling repository.
It connects the application to the database using the BowlingLeagueContext
and retrieves bowler data for the API controller.
*/

using Microsoft.EntityFrameworkCore;

namespace Shepherd_Mission10.Data
{
    // This class implements the IBowlingRepository interface.
    // It defines how the application will retrieve data from the database.
    public class EFBowlingRepository : IBowlingRepository
    {
        // Variable that stores the database context
        private BowlingLeagueContext _context;

        // Constructor that receives the database context through dependency injection
        // ASP.NET automatically provides the context when this class is created
        public EFBowlingRepository(BowlingLeagueContext temp)
        {
            _context = temp;
        }

        // This method retrieves bowlers from the database
        // It returns a collection of Bowler objects
        public IEnumerable<Bowler> GetBowlers()
        {
            return _context.Bowlers

                // Include loads related Team data along with each Bowler
                // Without this, Team information would not be available
                .Include(b => b.Team)

                // Filter the results so we only return bowlers on the
                // Marlins or Sharks teams (per the assignment instructions)
                .Where(b => b.Team != null &&
                            (b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks"))

                // Convert the query results into a list
                .ToList();
        }
    }
}