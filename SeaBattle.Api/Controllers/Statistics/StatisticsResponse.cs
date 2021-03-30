namespace SeaBattle.Api.Controllers.Statistics
{
    public class StatisticsResponse
    {
        public int ShipCount { get; set; }

        public int Destroyed { get; set; }

        public int Knocked { get; set; }

        public int ShotCount { get; set; }
    }
}