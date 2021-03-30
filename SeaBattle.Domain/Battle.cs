using System.Collections.Generic;
using System.Linq;
using SeaBattle.Domain.Exceptions;

namespace SeaBattle.Domain
{
    public class Battle
    {
        private BattleMatrix _battleMatrix;

        public void CreateBattle(int range)
        {
            _battleMatrix = new BattleMatrix(range);
        }

        public void CreateShips(IReadOnlyCollection<ShipCoordinates> shipsCoordinates)
        {
            if (_battleMatrix == null)
            {
                throw new InvalidBusinessLogicException("Для добавления кораблей необходимо сначала создать игру.");
            }

            if (_battleMatrix.Ships.Count > 0)
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
        }

        public ShotInformation Shot(Coordinates coordinates)
        {
            if (AllShipsIsDestroy())
            {
                throw new InvalidBusinessLogicException("Все корабли уничтожены, остановись.");
            }
            
            var shotStatus = _battleMatrix.Shot(coordinates);
            return new ShotInformation(destroy: shotStatus.Destroy, knock: shotStatus.Knock, AllShipsIsDestroy());
        }

        private bool AllShipsIsDestroy()
        {
            return _battleMatrix.Ships.All(x => x.Status == ShipStatus.Destroy);
        }

        public BattleStatistics GetStatistics()
        {
            var statistics = new BattleStatistics
            {
                ShotCount = _battleMatrix.Shots.Count,
                ShipCount = _battleMatrix.Ships.Count,
                Knocked = _battleMatrix.Ships.Count(x => x.Status == ShipStatus.Knock),
                Destroyed = _battleMatrix.Ships.Count(x => x.Status == ShipStatus.Destroy)
            };
            return statistics;
        }

        public void Clear()
        {
            _battleMatrix.Clear();
        }
    }

    
}