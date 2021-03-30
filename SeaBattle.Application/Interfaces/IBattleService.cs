using System.Threading.Tasks;

namespace SeaBattle.Application.Interfaces
{
    public interface IBattleService
    {
        Task CreateBattle(int range);
        Task ClearBattle();
    }
}