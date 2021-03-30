namespace SeaBattle.Domain
{
    public class BattleMatrixItem
    {
        public BattleMatrixItem(Coordinates coordinates)
        {
            Coordinates = coordinates;
            Ship = null;
        }
        
        public BattleMatrixItem(Coordinates coordinates, Ship ship)
        {
            Coordinates = coordinates;
            Ship = ship;
        }

        public Coordinates Coordinates { get; private set; }
        public Ship Ship { get; private set; }
    }
}