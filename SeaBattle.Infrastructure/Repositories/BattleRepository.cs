using System.Threading.Tasks;
using SeaBattle.Application.Interfaces;
using SeaBattle.Domain;
using SeaBattle.Infrastructure.Store;

namespace SeaBattle.Infrastructure.Repositories
{
    public class BattleRepository : IBattleRepository
    {
        public async Task CreateBattle(Battle battle)
        {
            BattleStoreSingleton.CreateBattle(battle);
        }

        public async Task<Battle> GetBattle()
        {
            return BattleStoreSingleton.Battle;
        }

        public async Task UpdateBattle(Battle battle)
        {
            BattleStoreSingleton.UpdateBattle(battle);
        }
    }
}