using System.Text.RegularExpressions;

namespace MarsRoverWorkShop.Command
{
    public abstract class Executer : IExecuter
    {
        public abstract void ExecuteCommand(string command);
        public abstract Regex CommandPattern { get; }        
        public bool IsCommandMatched(string command)
        {
            return CommandPattern.IsMatch(command);
        }
    }
}
