using System.Collections.Generic;
using SeaBattle.Domain;

namespace SeaBattle.Application.Interfaces
{
    public interface ICoordinatesParser
    {
        IEnumerable<ShipCoordinates> Parse(string coordinates);
    }
}