using System.Collections.Generic;
using System.Linq;
using SeaBattle.Domain.Exceptions;

namespace SeaBattle.Domain
{
    public class Battle
    {
        private BattleMatrix _battleMatrix;
        private IList<Ship> _ships;
        private IList<Shot> _shots;

        public void CreateBattle(int range)
        {
            _battleMatrix = new BattleMatrix(range);
            _ships = new List<Ship>();
            _shots = new List<Shot>();
        }

        public void CreateShips(IReadOnlyCollection<ShipCoordinates> shipsCoordinates)
        {
            if (_ships == null)
            {
                throw new InvalidBusinessLogicException("Для добавления кораблей необходимо сначала создать игру.");
            }

            if (_ships.Count > 0)
            {
                throw new InvalidBusinessLogicException("Корабли уже поставлены. Повторная постановка кораблей запрещена.");
            }

            foreach (var shipCoordinates in shipsCoordinates)
            {
                CreateShip(shipCoordinates);
            }
        }

        private void CreateShip(ShipCoordinates shipCoordinate)
        {
            var ship = new Ship(shipCoordinate);
            _battleMatrix.AddShip(ship);
            _ships.Add(ship);
        }

        public ShotInformation Shot(Coordinates coordinates)
        {
            if (AllShipsIsDestroy())
            {
                throw new InvalidBusinessLogicException("Все корабли уничтожены, выстрелы невозможны.");
            }
            
            var shotStatus = _battleMatrix.Shot(coordinates);
            _shots.Add(new Shot(coordinates));
            return new ShotInformation(destroy: shotStatus.Destroy, knock: shotStatus.Knock, AllShipsIsDestroy());
        }

        private bool AllShipsIsDestroy()
        {
            return _ships.All(x => x.Status == ShipStatus.Destroy);
        }

        public BattleStatistics GetStatistics()
        {
            var statistics = new BattleStatistics
            {
                ShotCount = _shots.Count,
                ShipCount = _ships.Count,
                Knocked = _ships.Count(x => x.Status == ShipStatus.Knock),
                Destroyed = _ships.Count(x => x.Status == ShipStatus.Destroy)
            };
            return statistics;
        }

        public void Clear()
        {
            _battleMatrix.Clear();
            _ships = new List<Ship>();
            _shots = new List<Shot>();
        }
    }

    
}