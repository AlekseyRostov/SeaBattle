namespace SeaBattle.Domain
{
    public class ShotStatus
    {
        public ShotStatus(bool destroy, bool knock)
        {
            Destroy = destroy;
            Knock = knock;
        }

        public bool Destroy { get; }

        public bool Knock { get; }
    }
}