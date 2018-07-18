using System;
using System.Collections.Generic;
using System.Linq;

namespace RobotNavigator
{
    public class Robot
    {
        public Position Position { get; }
        public string Instructions { get; }

        public Robot(Position position, string instructions)
        {
            Position = position;
            Instructions = instructions;
        }

        public string GetInfo()
        {
            return $"({Position.x}, {Position.y}, {Position.direction})";
        }

        public void Move(List<Coordinate> grid)
        {
            // set current position in grid
            UpdateGrid(grid);
            // move robot
            Instructions.ToCharArray().ToList().ForEach(i =>
            {
                switch (i.ToString().ToUpper())
                {
                    case "L":
                        RotateLeft();
                        break;
                    case "R":
                        RotateRight();
                        break;
                    case "M":
                        ChangePosition(grid);
                        break;
                    default:
                        break;
                }
                UpdateGrid(grid);
            });
        }

        private void UpdateGrid(List<Coordinate> grid)
        {
            var cell = grid.FirstOrDefault(c => c.x == Position.x && c.y == Position.y);
            if (cell != null) {
                cell.Robot = this;
            }
        }

        private void ChangePosition(List<Coordinate> grid)
        {
            // not required, but it only moves on available position
            switch (Position.direction)
            {
                case "N":
                    if (PositionAvailable(Position.x, Position.y + 1, grid))
                    {
                        Position.y += 1;
                    }
                    break;
                case "E":
                    if (PositionAvailable(Position.x + 1, Position.y, grid))
                    {
                        Position.x += 1;
                    }
                    break;
                case "S":
                    if (PositionAvailable(Position.x, Position.y - 1, grid))
                    {
                        Position.y -= 1;
                    }
                    break;
                default:
                    if (PositionAvailable(Position.x - 1, Position.y, grid))
                    {
                        Position.x -= 1;
                    }
                    break;
            }
        }

        private bool PositionAvailable(int x, int y, List<Coordinate> grid)
        {
            var nextPos = grid.First(c => c.x == x && c.y == y);
            return nextPos.Robot == null;
        }

        public void RotateLeft()
        {
            switch (Position.direction)
            {
                case "N":
                    Position.direction = "W";
                    break;
                case "E":
                    Position.direction = "N";
                    break;
                case "S":
                    Position.direction = "E";
                    break;
                default:
                    Position.direction = "S";
                    break;
            }
        }

        public void RotateRight()
        {
            switch (Position.direction)
            {
                case "N":
                    Position.direction = "E";
                    break;
                case "E":
                    Position.direction = "S";
                    break;
                case "S":
                    Position.direction = "W";
                    break;
                default:
                    Position.direction = "N";
                    break;
            }
        }
    }
}
