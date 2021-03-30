using System;
using System.Collections.Generic;
using System.Linq;
using SeaBattle.Application.Interfaces;
using SeaBattle.Domain.Exceptions;

namespace SeaBattle.Infrastructure.Services
{
    public class CoordinatesValidator : ICoordinatesValidator
    {
        public void ValidateParsedCoordinates(IList<string> parsedCoordinates)
        {
            if (parsedCoordinates == null || parsedCoordinates.Count == 0)
            {
                throw new InvalidParsedCoordinatesException("Список координат корабля не может быть пустой.");
            }

            foreach (var coordinate in parsedCoordinates)
            {
                ValidateParsedCoordinates(coordinate);
                
            }
        }

        public void ValidateParsedCoordinates(string coordinate)
        {
            if (string.IsNullOrWhiteSpace(coordinate))
            {
                throw new InvalidParsedCoordinatesException("Пустые координаты корабля не допустимы");
            }

            if (!Char.IsDigit(coordinate[0]))
            {
                throw new InvalidParsedCoordinatesException("Координата должна начинаться с числового символа.");
            }

            var (numberPart, stringPart) = GetCoordinateParts(coordinate);
                
            if (string.IsNullOrWhiteSpace(numberPart))
            {
                throw new InvalidParsedCoordinatesException("В координате должна быть часть состоящая из цифр");
            }
                
            if (string.IsNullOrWhiteSpace(stringPart))
            {
                throw new InvalidParsedCoordinatesException("В координате должна быть часть состоящая из букв");
            }

            if (coordinate.Any(x => !Char.IsDigit(x) && !Char.IsLetter(x)))
            {
                throw new InvalidParsedCoordinatesException("Координата содержит недопустимые символы.");
            }
                
            // todo: добавить проверку последовательности числовой и буквенной части, чтобы числа не шли в перемешку с буквами
        }
        
        private (string , string) GetCoordinateParts(string coordinate)
        {
            var numberPart = coordinate.Where(x => Char.IsDigit(x)).ToString();
            var stringPart = coordinate.Where(x => Char.IsLetter(x)).ToString();
            return (numberPart, stringPart);
        }
    }
}