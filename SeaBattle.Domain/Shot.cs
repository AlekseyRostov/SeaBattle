namespace SeaBattle.Domain
{
    public class Shot
    {
        public Shot(Coordinates coordinates)
        {
            Coordinates = coordinates;
        }

        public Coordinates Coordinates { get; }
    }
}