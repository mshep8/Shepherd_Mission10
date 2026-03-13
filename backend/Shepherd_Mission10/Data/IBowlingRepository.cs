namespace Shepherd_Mission10.Data
{
    public interface IBowlingRepository
    {
        IEnumerable<Bowler> GetBowlers();
    }
}