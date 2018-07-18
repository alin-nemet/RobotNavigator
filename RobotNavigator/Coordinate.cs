namespace RobotNavigator
{
    public class Coordinate
    {
        public int x { get; }
        public int y { get; }
        public Robot Robot { get; internal set; }

        public Coordinate(int x, int y)
        {
            this.x = x;
            this.y = y;
        }
    }
}