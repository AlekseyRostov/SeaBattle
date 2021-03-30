using System.Threading.Tasks;
using SeaBattle.Application.Interfaces;
using SeaBattle.Domain;

namespace SeaBattle.Infrastructure.Services
{
    public class BattleService: IBattleService
    {
        private readonly IBattleRepository _battleRepository;

        public BattleService(IBattleRepository battleRepository)
        {
            _battleRepository = battleRepository;
        }

        public async Task CreateBattle(int range)
        {
            var battle = new Battle();
            battle.CreateBattle(range);
            await _battleRepository.CreateBattle(battle);
        }

        public async Task ClearBattle()
        {
            var battle = await _battleRepository.GetBattle();
            battle.Clear();
            await _battleRepository.UpdateBattle(battle);
        }
    }
}