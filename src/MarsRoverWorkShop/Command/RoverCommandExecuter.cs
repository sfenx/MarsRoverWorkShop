using MarsRoverWorkShop.Enums;
using MarsRoverWorkShop.MarsRover;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.RegularExpressions;

namespace MarsRoverWorkShop.Command
{
    public class RoverCommandExecuter : Executer
    {
        private readonly IRoverManager _roverManager;

        public RoverCommandExecuter(IServiceProvider serviceProvider)
        {
            _roverManager = serviceProvider.GetService<IRoverManager>();
        }

        public override Regex CommandPattern => new Regex("^[LMR]+$");

        public override void ExecuteCommand(string command)
        {
            if (CheckIfActiveRoverExists(out var rover))
                return;

            MoveRoverWithCommand(command, rover);
            WriteRoverLocation(rover);
        }

        private static void MoveRoverWithCommand(string command, Rover rover)
        {
            foreach (var order in command)
            {
                var movement = Enum.Parse<Movements>(order.ToString());
                rover.Move(movement);
            }
        }

        private static void WriteRoverLocation(Rover rover)
        {
            Console.WriteLine($"{rover.X} {rover.Y} {rover.Direction}");
        }

        private bool CheckIfActiveRoverExists(out Rover rover)
        {
            rover = _roverManager.Rover;
            return rover == null;
        }
    }
}
