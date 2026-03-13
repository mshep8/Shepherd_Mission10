/*
Mary Catherine Shepherd
IS 413
Mission 10

This class represents a Team in the Bowling League database.
It maps to the Teams table and is used by Entity Framework
to retrieve and relate team information with bowlers.
*/

namespace Shepherd_Mission10.Data
{
    public class Team
    {
        // Primary key for the Teams table
        public int TeamId { get; set; }

        // Name of the bowling team (ex: Marlins, Sharks)
        public string? TeamName { get; set; }

        // Navigation property that represents the relationship
        // between a Team and the Bowlers on that team.
        // One team can have many bowlers.
        public List<Bowler> Bowlers { get; set; } = new List<Bowler>();
    }
}