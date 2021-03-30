using System.Threading.Tasks;
using SeaBattle.Domain;

namespace SeaBattle.Application.Interfaces
{
    public interface IBattleRepository
    {
        Task<Battle> GetBattle();

        Task CreateBattle(Battle battle);
        
        Task UpdateBattle(Battle battle);
    }
}