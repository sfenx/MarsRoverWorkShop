using MarsRoverWorkShop.Enums;
using MarsRoverWorkShop.MarsRover;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Text.RegularExpressions;

namespace MarsRoverWorkShop.Command
{
    public class RoverExecuter : Executer
    {
        private readonly IRoverManager _roverManager;

        public RoverExecuter(IServiceProvider serviceProvider)
        {
            _roverManager = serviceProvider.GetService<IRoverManager>();
        }

        public override Regex CommandPattern => new Regex("^\\d+ \\d+ [NSWE]$");

        public override void ExecuteCommand(string command)
        {
            ParseCommand(command, out var x, out var y, out var direction);
            _roverManager.DeployRover(x, y, direction);
        }

        private static void ParseCommand(string command, out int x, out int y, out Directions direction)
        {
            var splittedCommand = command.Split(' ');
            x = int.Parse(splittedCommand[0]);
            y = int.Parse(splittedCommand[1]);
            direction = Enum.Parse<Directions>(splittedCommand[2]);
        }
    }
}
