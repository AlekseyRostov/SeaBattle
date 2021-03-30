using System.Collections.Generic;

namespace SeaBattle.Application.Interfaces
{
    public interface ICoordinatesValidator
    {
        void ValidateParsedCoordinates(IList<string> parsedCoordinates);

        void ValidateParsedCoordinates(string coordinate);
    }
}