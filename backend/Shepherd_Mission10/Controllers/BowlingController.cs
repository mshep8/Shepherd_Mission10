/*
Mary Catherine Shepherd
IS 413
Mission 10

This controller handles API requests related to bowlers.
It retrieves bowler data from the repository and returns it
to the React frontend in JSON format.
*/

using Microsoft.AspNetCore.Mvc;
using Shepherd_Mission10.Data;

namespace Shepherd_Mission10.Controllers
{
    // This attribute tells ASP.NET that this class is an API controller
    [ApiController]

    // This sets the base route for the controller.
    // Since the controller name is BowlingController,
    // the base route becomes /Bowling
    [Route("[controller]")]
    public class BowlingController : ControllerBase
    {
        // This variable stores the repository that interacts with the database
        private IBowlingRepository _bowlingRepo;

        // Constructor that receives the repository through dependency injection
        // ASP.NET automatically provides the repository when the controller is created
        public BowlingController(IBowlingRepository temp)
        {
            _bowlingRepo = temp;
        }

        // This attribute defines a GET endpoint called:
        // /Bowling/GetBowlers
        [HttpGet("GetBowlers")]

        // This method retrieves bowlers from the repository
        public IActionResult GetBowlers()
        {
            // Get bowlers filtered by the repository (Marlins and Sharks teams)
            var bowlers = _bowlingRepo.GetBowlers();

            // Convert the database objects into a cleaner format for the frontend
            // This creates a new anonymous object with only the fields we want to send
            var bowlerList = bowlers.Select(b => new
            {
                // Combine first, middle, and last names into a single name
                bowlerName = b.BowlerFirstName + " " +
                             (string.IsNullOrEmpty(b.BowlerMiddleInit) ? "" : b.BowlerMiddleInit + " ") +
                             b.BowlerLastName,

                // Get the team name (check for null in case there is no team)
                teamName = b.Team != null ? b.Team.TeamName : "",

                // Address information
                address = b.BowlerAddress,
                city = b.BowlerCity,
                state = b.BowlerState,
                zip = b.BowlerZip,

                // Phone number
                phoneNumber = b.BowlerPhoneNumber
            });

            // Return the data as JSON with a 200 OK response
            return Ok(bowlerList);
        }
    }
}