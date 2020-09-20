using MarsRoverWorkShop.Enums;
using MarsRoverWorkShop.LandingSurface;
using System;
using System.Collections.Generic;

namespace MarsRoverWorkShop.MarsRover
{
    public class RoverManager : IRoverManager
    {
        public Rover Rover { get; private set; }
        public List<Rover> RoverList { get; } = new List<Rover>();

        public ILandingSurface LandingSurface { get; }
        

        public RoverManager(ILandingSurface landingSurface)
        {
            LandingSurface = landingSurface;
        }

        public void DeployRover(int x, int y, Directions direction)
        {
            CheckIfLocationToDeployIsValid(x, y);
            var rover = new Rover(x, y, direction, LandingSurface);
            RoverList.Add(rover);
            Rover = rover;
        }

        private void CheckIfLocationToDeployIsValid(int x, int y)
        {
            if (!IsAppropriateLocationToDeployRover(x, y))
                throw new Exception("Rover outside of bounds");
        }

        private bool IsAppropriateLocationToDeployRover(int x, int y)
        {
            return x >= 0 && x < LandingSurface.Dimension.Width &&
                   y >= 0 && y < LandingSurface.Dimension.Height;
        }
    }
}
