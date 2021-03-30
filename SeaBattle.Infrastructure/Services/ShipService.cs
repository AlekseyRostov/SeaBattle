using System.Linq;
using System.Threading.Tasks;
using SeaBattle.Application.Interfaces;
using SeaBattle.Domain;

namespace SeaBattle.Infrastructure.Services
{
    public class ShipService : IShipService
    {
        private readonly IBattleRepository _battleRepository;
        private readonly ICoordinatesParser _coordinatesParser;

        public ShipService(IBattleRepository battleRepository, ICoordinatesParser coordinatesParser)
        {
            _battleRepository = battleRepository;
            _coordinatesParser = coordinatesParser;
        }

        public async Task CreateShips(string coordinates)
        {
            var shipsCoordinates = _coordinatesParser.Parse(coordinates).ToList();
            var battle = await _battleRepository.GetBattle();
            
            battle.CreateShips(shipsCoordinates);
            await _battleRepository.UpdateBattle(battle);
        }

        public async Task<ShotInformation> Shot(string coordinates)
        {
            var shotCoordinates = new Coordinates(coordinates);
            var battle = await _battleRepository.GetBattle();
            
            var shotInformation = battle.Shot(shotCoordinates);
            await _battleRepository.UpdateBattle(battle);
            
            return shotInformation;
        }

        
    }
}