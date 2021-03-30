using System;
using System.Collections.Generic;
using SeaBattle.Domain.Exceptions;

namespace SeaBattle.Domain
{
    public class BattleMatrix
    {
        private string Letters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        private readonly IDictionary<string, BattleMatrixItem> _matrix;
        private readonly int _range;

        public BattleMatrix(int range)
        {
            if (range > Letters.Length)
            {
                throw new ArgumentException("Размер поля не может превышать 26!");
            }

            _range = range;
            _matrix = CreateMatrix();
        }

        private IDictionary<string, BattleMatrixItem> CreateMatrix()
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
            
            return items;
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
            var matrixItem = _matrix[coordinates.Value];
            if (matrixItem.Coordinates.Status == StatusCoordinates.Knock)
            {
                throw new InvalidBusinessLogicException("Повторный выстрел.");
            }

            var ship = matrixItem.Ship;
            matrixItem.Coordinates.Status = StatusCoordinates.Knock;

            if (ship == null)
            {
                return new ShotStatus(destroy: false, knock: false);
            }

            return ship.Shot(coordinates);
        }

        public void Clear()
        {
            CreateMatrix();
        }
    }
}