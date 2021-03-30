using System.Threading.Tasks;
using SeaBattle.Domain;

namespace SeaBattle.Application.Interfaces
{
    public interface IShipService
    {
        Task CreateShips(string coordinates);
        Task<ShotInformation> Shot(string coordinates);   
    }
}