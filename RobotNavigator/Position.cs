namespace RobotNavigator
{
    public class Position
    {
        public int x, y;
        public string direction;
        public Position(int x, int y, string direction)
        {
            this.x = x;
            this.y = y;
            this.direction = direction;
        }
    }
}
