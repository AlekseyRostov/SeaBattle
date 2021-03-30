using System.Threading.Tasks;
using SeaBattle.Domain;

namespace SeaBattle.Application.Interfaces
{
    public interface IBattleStatisticService
    {
        Task<BattleStatistics> GetStatistics();
    }
}