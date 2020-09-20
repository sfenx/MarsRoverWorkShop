using MarsRoverWorkShop.Enums;
using MarsRoverWorkShop.LandingSurface;
using System;

namespace MarsRoverWorkShop.MarsRover
{
    public class Rover : IRover
    {
        public int X { get; private set; }
        public int Y { get; private set; }
        public Directions Direction { get; private set; }
        public ILandingSurface LandingSurface { get; }

        public Rover(int x, int y, Directions direction, ILandingSurface landingSurface)
        {
            X = x;
            Y = y;
            Direction = direction;
            LandingSurface = landingSurface;
        }

        public void Move(Movements movement)
        {
            switch (movement)
            {
                case Movements.L:
                    TurnLeft();
                    break;
                case Movements.R:
                    TurnRight();
                    break;
                case Movements.M:
                    MoveForward();
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(movement), movement, null);
            }
        }

        private void TurnLeft()
        {
            switch (Direction)
            {
                case Directions.N:
                    Direction = Directions.W;
                    break;

                case Directions.W:
                    Direction = Directions.S;
                    break;

                case Directions.S:
                    Direction = Directions.E;
                    break;

                case Directions.E:
                    Direction = Directions.N;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
        private void TurnRight()
        {
            switch (Direction)
            {
                case Directions.N:
                    Direction = Directions.E;
                    break;

                case Directions.E:
                    Direction = Directions.S;
                    break;

                case Directions.S:
                    Direction = Directions.W;
                    break;

                case Directions.W:
                    Direction = Directions.N;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void MoveForward()
        {
            switch (Direction)
            {
                case Directions.N:
                    if (Y + 1 <= LandingSurface.Dimension.Height)
                        Y += 1;
                    break;

                case Directions.E:
                    if (X + 1 <= LandingSurface.Dimension.Width)
                        X += 1;
                    break;

                case Directions.S:
                    if (Y - 1 >= 0)
                        Y -= 1;
                    break;

                case Directions.W:
                    if (X - 1 >= 0)
                        X -= 1;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }              
    }
}
