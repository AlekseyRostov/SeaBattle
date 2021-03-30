using System.Collections.Generic;
using System.Linq;
using SeaBattle.Application.Interfaces;
using SeaBattle.Domain;

namespace SeaBattle.Infrastructure.Services
{
    public class CoordinatesParser : ICoordinatesParser
    {
        private readonly ICoordinatesValidator _coordinatesValidator;

        public CoordinatesParser(ICoordinatesValidator coordinatesValidator)
        {
            _coordinatesValidator = coordinatesValidator;
        }

        public IEnumerable<ShipCoordinates> Parse(string coordinates)
        {
            var shipsCoordinates = coordinates.Split(',').Where(x=> !string.IsNullOrWhiteSpace(x));
            foreach (var shipCoordinates in shipsCoordinates)
            {
                var parsedCoordinatesOfShip = shipCoordinates.Split(' ')
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .ToList();
                _coordinatesValidator.ValidateParsedCoordinates(parsedCoordinatesOfShip);
                yield return CreateShipCoordinates(parsedCoordinatesOfShip);
            }
        }

        private ShipCoordinates CreateShipCoordinates(IEnumerable<string> coordinatesOfShip)
        {
            var coordinates = coordinatesOfShip.Select(x => new Coordinates(x)).ToList();
            return new ShipCoordinates(coordinates);
        }
    }
}