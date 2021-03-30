namespace SeaBattle.Domain
{
    public class ShotInformation
    {
        public ShotInformation(bool destroy, bool knock, bool end)
        {
            Destroy = destroy;
            Knock = knock;
            End = end;
        }

        public bool Destroy { get; }

        public bool Knock { get; }
        
        public bool End { get; }
    }
}