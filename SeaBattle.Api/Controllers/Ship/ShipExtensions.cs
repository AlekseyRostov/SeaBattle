using SeaBattle.Domain;

namespace SeaBattle.Api.Controllers.Ship
{
    public static class ShipExtensions
    {
        public static ShotInformationResponse ToRest(this ShotInformation shotInformation)
        {
            return new ShotInformationResponse()
            {
                Destroy = shotInformation.Destroy,
                Knock = shotInformation.Knock,
                End = shotInformation.End
            };
        }
    }
}