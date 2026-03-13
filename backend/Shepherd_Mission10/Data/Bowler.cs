/*
Mary Catherine Shepherd
IS 413
Mission 10

This class represents a Bowler from the Bowling League database.
It maps directly to the Bowlers table in the SQLite database.
Entity Framework uses this class to retrieve and store bowler data.
*/

namespace Shepherd_Mission10.Data
{
    public class Bowler
    {
        // Primary key for the Bowler table
        public int BowlerId { get; set; }

        // Last name of the bowler
        public string? BowlerLastName { get; set; }

        // First name of the bowler
        public string? BowlerFirstName { get; set; }

        // Middle initial of the bowler (may be null)
        public string? BowlerMiddleInit { get; set; }

        // Street address of the bowler
        public string? BowlerAddress { get; set; }

        // City where the bowler lives
        public string? BowlerCity { get; set; }

        // State where the bowler lives
        public string? BowlerState { get; set; }

        // Zip code for the bowler's address
        public string? BowlerZip { get; set; }

        // Phone number of the bowler
        public string? BowlerPhoneNumber { get; set; }

        // Foreign key that connects the bowler to a team
        public int? TeamId { get; set; }

        // Navigation property used by Entity Framework
        // This links the Bowler to its associated Team
        public Team? Team { get; set; }
    }
}