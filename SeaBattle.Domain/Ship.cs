using System;
using System.Linq;

namespace SeaBattle.Domain
{
    public class Ship
    {
        public ShipCoordinates Coordinates { get; private set; }

        public ShipStatus Status { get; private set; }

        public Ship(ShipCoordinates coordinates)
        {
            Coordinates = coordinates;
            Status = ShipStatus.Live;
        }

        public ShotStatus Shot(Coordinates shotCoordinates)
        {
            var hit = Coordinates.Coordinates.First(x =>
                string.Equals(x.Value, shotCoordinates.Value, StringComparison.OrdinalIgnoreCase));
            
            hit.Status = StatusCoordinates.Knock;
            var shipIsDestroy = Coordinates.Coordinates.All(x => x.Status == StatusCoordinates.Knock);
            Status = shipIsDestroy ? ShipStatus.Destroy : ShipStatus.Knock;

            return new ShotStatus(destroy: shipIsDestroy, knock: true);
        }
    }
}