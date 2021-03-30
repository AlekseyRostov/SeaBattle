using System;
using System.Collections.Generic;
using SeaBattle.Domain.Exceptions;

namespace SeaBattle.Domain
{
    public class BattleMatrix
    {
        private string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private IDictionary<string, BattleMatrixItem> _matrix;
        private readonly int _range;

        public IList<Ship> Ships { get; private set; }
        public IList<Shot> Shots { get; private set; }

        public BattleMatrix(int range)
        {
            if (range > Letters.Length)
            {
                throw new ArgumentException("Размер поля не может превышать 26!");
            }

            _range = range;
            CreateMatrix();
        }

        private void CreateMatrix()
        {
            var items = new Dictionary<string, BattleMatrixItem>();

            for (int numberIndex = 0; numberIndex < _range; numberIndex++)
            {
                for (int letterIndex = 0; letterIndex < _range; letterIndex++)
                {
                    string coordinate = $"{numberIndex}{Letters[letterIndex]}";
                    items.Add(coordinate, new BattleMatrixItem(new Coordinates(coordinate)));
                }
            }
            
            _matrix = items;
            Ships = new List<Ship>();
            Shots = new List<Shot>();
        }

        public void AddShip(Ship ship)
        {
            ValidateCoordinates(ship.Coordinates.Coordinates);

            foreach (var coordinates in ship.Coordinates.Coordinates)
            {
                var cell = _matrix[coordinates.Value];
                if (cell.Ship != null)
                {
                    throw new InvalidBusinessLogicException(
                        $"В ячейке: {coordinates.Value} уже установлен корабль. Повторная установка запрещена.");
                }
                
                _matrix[coordinates.Value] = new BattleMatrixItem(coordinates, ship);
            }
            Ships.Add(ship);
        }

        private void ValidateCoordinates(IReadOnlyCollection<Coordinates> shipCoordinates)
        {
            foreach (var shipCoordinate in shipCoordinates)
            {
                _matrix.TryGetValue(shipCoordinate.Value, out var item);
                if (item == null)
                {
                    throw new InvalidBusinessLogicException("Координаты корабля выходят за границы игрового поля.");
                }
            }
        }


        public ShotStatus Shot(Coordinates coordinates)
        {
            _matrix.TryGetValue(coordinates.Value, out var matrixItem);

            if (matrixItem == null)
            {
                throw new InvalidBusinessLogicException("Выстрел не может быть выполнен за границы поля.");
            }
            
            if (matrixItem.Coordinates.Status == StatusCoordinates.Knock)
            {
                throw new InvalidBusinessLogicException("Повторный выстрел. Сюда уже стреляли.");
            }

            var ship = matrixItem.Ship;
            matrixItem.Coordinates.Status = StatusCoordinates.Knock;

            if (ship == null)
            {
                return new ShotStatus(destroy: false, knock: false);
            }

            var result = ship.Shot(coordinates);
            Shots.Add(new Shot(coordinates));
            return result;
        }

        public void Clear()
        {
            CreateMatrix();
        }
    }
}