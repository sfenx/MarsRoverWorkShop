using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace MarsRoverWorkShop.Command
{
    public class Invoker : IInvoker
    {
        private readonly IServiceProvider _serviceProvider;

        public Invoker(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public void SendCommand(string command)
        {
            var commandExecuter = GetCommandExecuterFromAssembly();

            var executer = commandExecuter.SingleOrDefault(x => x.IsCommandMatched(command));
            executer?.ExecuteCommand(command);
        }

        private IEnumerable<Executer> GetCommandExecuterFromAssembly()
        {
            return Assembly.GetExecutingAssembly()
                .DefinedTypes
                .Where(type => type.IsSubclassOf(typeof(Executer)) && !type.IsAbstract)
                .Select(x => Activator.CreateInstance(x, _serviceProvider) as Executer)
                .ToList();
        }
    }
}
