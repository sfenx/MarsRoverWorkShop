using MarsRoverWorkShop.Enums;
using MarsRoverWorkShop.LandingSurface;
using System.Collections.Generic;

namespace MarsRoverWorkShop.MarsRover
{
    public interface IRoverManager
    {        
        Rover Rover { get; }
        List<Rover> RoverList { get; }
        ILandingSurface LandingSurface { get; }
        void DeployRover(int x, int y, Directions direction);
    }
}
