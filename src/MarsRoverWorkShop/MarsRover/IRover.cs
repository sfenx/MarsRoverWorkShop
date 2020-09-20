using MarsRoverWorkShop.Enums;
using MarsRoverWorkShop.LandingSurface;

namespace MarsRoverWorkShop.MarsRover
{
    public interface IRover
    {
        int X { get; }
        int Y { get; }
        ILandingSurface LandingSurface { get; }
        Directions Direction { get; }
        void Move(Movements movement);
    }
}
