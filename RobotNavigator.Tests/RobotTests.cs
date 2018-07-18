using System.Collections.Generic;
using Xunit;

namespace RobotNavigator.Tests
{
    public class RobotTests
    {
        [Fact]
        public void MustHaveInitialPositionAndMovingInstructions(){
            var pos = new Position(1, 2, "N");
            var inst = "RLRLRLMMLMMRR";
            var robot = new Robot(pos, inst);
            Assert.True(robot.Position == pos);
            Assert.True(robot.Instructions == inst);
        }

        [Fact]
        public void ReturnsStringRepresentationOfCurrentPosition() {
            var robot = new Robot(new Position(1, 2, "N"), "RLRLRLMMLMMRR");
            Assert.Equal(robot.GetInfo(), "(1, 2, N)");
        }

        //
        [Fact]
        public void RotatingLeftFacingNorth()
        {
            var robot = new Robot(new Position(1, 2, "N"), "L");
            robot.Move(new List<Coordinate>{new Coordinate(0,0)});
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
        //
        [Fact]
        public void MovingNorthOneCell()
        {
            var robot = new Robot(new Position(0, 0, "N"), "M");
            robot.Move(new List<Coordinate> { new Coordinate(0, 0), new Coordinate(0, 1),  new Coordinate(1, 0), new Coordinate(1, 1)});
            Assert.Equal(robot.Position.x, 0);
            Assert.Equal(robot.Position.y, 1);
        }

        [Fact]
        public void MovingEastOneCell()
        {
            var robot = new Robot(new Position(0, 0, "E"), "M");
            robot.Move(new List<Coordinate> { new Coordinate(0, 0), new Coordinate(0, 1), new Coordinate(1, 0), new Coordinate(1, 1) });
            Assert.Equal(robot.Position.x, 1);
            Assert.Equal(robot.Position.y, 0);
        }

        [Fact]
        public void MovingSouthOneCell()
        {
            var robot = new Robot(new Position(1, 1, "S"), "M");
            robot.Move(new List<Coordinate> { new Coordinate(0, 0), new Coordinate(0, 1), new Coordinate(1, 0), new Coordinate(1, 1) });
            Assert.Equal(robot.Position.x, 1);
            Assert.Equal(robot.Position.y, 0);
        }
    }
}
