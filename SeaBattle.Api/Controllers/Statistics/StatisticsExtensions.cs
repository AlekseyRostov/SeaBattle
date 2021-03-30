using SeaBattle.Domain;

namespace SeaBattle.Api.Controllers.Statistics
{
    public static class StatisticsExtensions
    {
        public static StatisticsResponse ToRest(this BattleStatistics statistics)
        {
            return new StatisticsResponse()
            {
                Destroyed = statistics.Destroyed,
                Knocked = statistics.Knocked,
                ShipCount = statistics.ShipCount,
                ShotCount = statistics.ShotCount
            };
        }
    }
}