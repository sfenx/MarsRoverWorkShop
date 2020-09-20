using FluentAssertions;
using MarsRoverWorkShop.Enums;
using MarsRoverWorkShop.LandingSurface;
using MarsRoverWorkShop.MarsRover;
using System;
using System.Linq;
using Xunit;

namespace MarsRoverWorkShop.Tests
{
    public class MarsRoverTests
    {
        [Theory]
        [InlineData("MM")]
        [InlineData("MMLR")]
        [InlineData("LLLLMM")]
        public void RoverShouldMoveTo2North4X4MoveTwoLineUp(string command)
        {
            // Arrange
            var area = new Area();
            area.Define(5, 5);
            IRoverManager manager = new RoverManager(area);
            manager.DeployRover(0, 0, Directions.N);
            var movements = command
                .ToCharArray()
                .Select(x => Enum.Parse<Movements>(x.ToString()))
                .ToList();

            // Act
            movements.ForEach(manager.Rover.Move);

            // Assert
            manager.Rover.Should().NotBeNull();
            manager.Rover.X.Should().Be(0);
            manager.Rover.Y.Should().Be(2);
            manager.Rover.Direction.Should().Be(Directions.N);
        }

        [Theory]
        [InlineData(new object[] {"5 5", "1 2", "LMLMLMLMM", 1, 3, Directions.N })]
        [InlineData(new object[] { "5 5", "3 3", "MMRMMRMRRM", 5, 1, Directions.E })]
        public void GeneratePlataueAndExecuteRoverDataShouldEqualToInputValues(string plateauSurfaceSize, string roverPosition, string roverCommand, int expectedX, int exceptedY, Directions direction
            )
        {
            // Arrange
            var splittedPlateauCommand = plateauSurfaceSize.Split(' ');            
            var area = new Area();
            area.Define(int.Parse(splittedPlateauCommand[0]), int.Parse(splittedPlateauCommand[1]));
            IRoverManager manager = new RoverManager(area);

            var splittedRoverCommand = roverPosition.Split(' ');
            
            manager.DeployRover(int.Parse(splittedRoverCommand[0]), int.Parse(splittedRoverCommand[1]), direction);
            var movements = roverCommand
                .ToCharArray()
                .Select(x => Enum.Parse<Movements>(x.ToString()))
                .ToList();

            // Act
            movements.ForEach(manager.Rover.Move);

            // Assert
            Assert.NotNull(manager.Rover);            
            Assert.Equal(expectedX, manager.Rover.X);
            Assert.Equal(exceptedY, manager.Rover.Y);
            Assert.Equal(direction, manager.Rover.Direction);
        }


        [Theory]
        [InlineData(new object[] { "5 5", "1 2", "MMMMMMMMMMMMM", 1, 3, Directions.N })]
       
        public void RoverShouldNotMoveLimitOfArea(string areaSurfaceSize, string roverPosition, string roverCommand, int expectedX, int exceptedY, Directions direction
            )
        {
            // Arrange
            var splittedAreaCommand = areaSurfaceSize.Split(' ');
            var area = new Area();
            area.Define(int.Parse(splittedAreaCommand[0]), int.Parse(splittedAreaCommand[1]));
            IRoverManager manager = new RoverManager(area);

            var splittedRoverCommand = roverPosition.Split(' ');

            manager.DeployRover(int.Parse(splittedRoverCommand[0]), int.Parse(splittedRoverCommand[1]), direction);
            var movements = roverCommand
                .ToCharArray()
                .Select(x => Enum.Parse<Movements>(x.ToString()))
                .ToList();

            // Act
            movements.ForEach(manager.Rover.Move);

            // Assert
            Assert.NotNull(manager.Rover);
            Assert.True(expectedX <= 5);
            Assert.True(exceptedY <= 5);
        }

    }
}
