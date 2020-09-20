using MarsRoverWorkShop.Command;
using MarsRoverWorkShop.LandingSurface;
using MarsRoverWorkShop.MarsRover;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace MarsRoverWorkShop
{
    public class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
               .AddSingleton<ILandingSurface, Area>()
               .AddSingleton<IRoverManager, RoverManager>()
               .BuildServiceProvider();

            var commandInvoker = new Invoker(serviceProvider);
            commandInvoker.SendCommand("5 5");
            commandInvoker.SendCommand("1 2 N");
            commandInvoker.SendCommand("LMLMLMLMM");
            commandInvoker.SendCommand("3 3 E");
            commandInvoker.SendCommand("MMRMMRMRRM");

            Console.ReadLine();
        }
    }
}
