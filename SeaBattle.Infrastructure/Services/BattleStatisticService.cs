using System.Threading.Tasks;
using SeaBattle.Application.Interfaces;
using SeaBattle.Domain;

namespace SeaBattle.Infrastructure.Services
{
    public class BattleStatisticService : IBattleStatisticService
    {
        private readonly IBattleRepository _battleRepository;

        public BattleStatisticService(IBattleRepository battleRepository)
        {
            _battleRepository = battleRepository;
        }

        public async Task<BattleStatistics> GetStatistics()
        {
            var battle = await _battleRepository.GetBattle();
            return battle.GetStatistics();
        }
    }
}