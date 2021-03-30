namespace SeaBattle.Domain
{
    public class Coordinates
    {
        public Coordinates(string value)
        {
            Value = value;
            Status = StatusCoordinates.Live;
        }

        public string Value { get; }
        
        public StatusCoordinates Status { get; set; }
    }
}