using System;
using System.Collections.Generic;
using Xunit;

namespace RobotNavigator.Tests
{
    public class RobotTests
    {
        [Fact]
        public void MustHaveInitialPositionAndMovingInstructions()
        {
            var pos = new Position(1, 2, "N");
            var inst = "RLRLRLMMLMMRR";
            var robot = new Robot(pos, inst);
            Assert.True(robot.Position == pos);
            Assert.True(robot.Instructions == inst);
        }

        [Fact]
        public void ReturnsStringRepresentationOfCurrentPosition()
        {
            var robot = new Robot(new Position(1, 2, "N"), "RLRLRLMMLMMRR");
            Assert.Equal(robot.GetInfo(), "(1, 2, N)");
        }

        //
        [Fact]
        public void RotatingLeftFacingNorth()
        {
            var robot = new Robot(new Position(1, 2, "N"), "L");
            robot.Move(new List<Coordinate> { new Coordinate(0, 0) });
            Assert.Equal(robot.Position.direction, "W");
        }

        [Fact]
        public void RotatingLeftFacingEast()
        {
            var robot = new Robot(new Position(1, 2, "E"), "L");
            robot.Move(new List<Coordinate> { new Coordinate(0, 0) });
            Assert.Equal(robot.Position.direction, "N");
        }

        [Fact]
        public void RotatingLeftFacingSouth()
        {
            var robot = new Robot(new Position(1, 2, "S"), "L");
            robot.Move(new List<Coordinate> { new Coordinate(0, 0) });
            Assert.Equal(robot.Position.direction, "E");
        }

        [Fact]
        public void RotatingLeftFacingWest()
        {
            var robot = new Robot(new Position(1, 2, "W"), "L");
            robot.Move(new List<Coordinate> { new Coordinate(0, 0) });
            Assert.Equal(robot.Position.direction, "S");
        }

        //
        [Fact]
        public void RotatingRightFacingNorth()
        {
            var robot = new Robot(new Position(1, 2, "N"), "R");
            robot.Move(new List<Coordinate> { new Coordinate(0, 0) });
            Assert.Equal(robot.Position.direction, "E");
        }

        [Fact]
        public void RotatingRightFacingEast()
        {
            var robot = new Robot(new Position(1, 2, "E"), "R");
            robot.Move(new List<Coordinate> { new Coordinate(0, 0) });
            Assert.Equal(robot.Position.direction, "S");
        }

        [Fact]
        public void RotatingRightFacingSouth()
        {
            var robot = new Robot(new Position(1, 2, "S"), "R");
            robot.Move(new List<Coordinate> { new Coordinate(0, 0) });
            Assert.Equal(robot.Position.direction, "W");
        }

        [Fact]
        public void RotatingRightFacingWest()
        {
            var robot = new Robot(new Position(1, 2, "W"), "R");
            robot.Move(new List<Coordinate> { new Coordinate(0, 0) });
            Assert.Equal(robot.Position.direction, "N");
        }
        // testing movement on 3x3 grid
        [Fact]
        public void MovingNorthOneCell()
        {
            var robot = new Robot(new Position(0, 0, "N"), "M");
            robot.Move(GenerateGrid(2, 2));
            Assert.Equal(robot.Position.x, 0);
            Assert.Equal(robot.Position.y, 1);
        }

        [Fact]
        public void MovingEastOneCell()
        {
            var robot = new Robot(new Position(0, 0, "E"), "M");
            robot.Move(GenerateGrid(2, 2));
            Assert.Equal(robot.Position.x, 1);
            Assert.Equal(robot.Position.y, 0);
        }

        [Fact]
        public void MovingSouthOneCell()
        {
            var robot = new Robot(new Position(1, 1, "S"), "M");
            robot.Move(GenerateGrid(2, 2));
            Assert.Equal(robot.Position.x, 1);
            Assert.Equal(robot.Position.y, 0);
        }

        [Fact]
        public void MovingWestOneCell()
        {
            var robot = new Robot(new Position(1, 0, "W"), "M");
            robot.Move(GenerateGrid(2, 2));
            Assert.Equal(robot.Position.x, 0);
            Assert.Equal(robot.Position.y, 0);
        }
        // testing movement on 5x5 grid
        [Fact]
        public void MovingAroundThePerimeterFromOrigin()
        {
            var robot = new Robot(new Position(0, 0, "N"), "MMMMRMMMMRMMMMRMMMM");
            robot.Move(GenerateGrid(4, 4));
            Assert.Equal(robot.Position.x, 0);
            Assert.Equal(robot.Position.y, 0);
        }

        [Fact]
        public void MovingFromBottomLeftCornerToUpperRightCorner()
        {
            var robot = new Robot(new Position(0, 0, "N"), "MMMMRMMMM");
            robot.Move(GenerateGrid(4, 4));
            Assert.Equal(robot.Position.x, 4);
            Assert.Equal(robot.Position.y, 4);
        }
        // 11x11 grid
        [Fact]
        public void TwoRobotsMovingOppositeFromUpperLeftCornerAndLowerRightCornerWillMeetInTheCenter()
        {
            var grid = GenerateGrid(10, 10);
            var robot1 = new Robot(new Position(0, 10, "S"), "MLMRMLMRMLMRMLMRMLMR");
            robot1.Move(grid);
            var robot2 = new Robot(new Position(10, 0, "N"), "MLMRMLMRMLMRMLMRMLMR");
            robot2.Move(grid);
            Console.WriteLine(robot1.GetInfo());
            Console.WriteLine(robot2.GetInfo());
            Assert.Equal(robot1.Position.x, 5);
            Assert.Equal(robot1.Position.y, 5);
            Assert.Equal(robot1.Position.direction, "S");
            Assert.Equal(robot2.Position.x, 5);
            Assert.Equal(robot2.Position.y, 5);
            Assert.Equal(robot2.Position.direction, "N");
        }

        // params are upper right coordinates
        private List<Coordinate> GenerateGrid(int x, int y)
        {
            var grid = new List<Coordinate>();
            for (int i = 0; i <= x; i++)
            {
                for (int j = 0; j <= y; j++)
                {
                    grid.Add(new Coordinate(i, j));
                }
            }
            return grid;
        }
    }
}
