using System.Collections.Generic;

namespace SeaBattle.Domain
{
    public class ShipCoordinates
    {
        public ShipCoordinates(IReadOnlyCollection<Coordinates> coordinates)
        {
            Coordinates = coordinates;
        }

        public IReadOnlyCollection<Coordinates> Coordinates { get; }
    }
}