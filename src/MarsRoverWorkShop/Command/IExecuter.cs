using System.Text.RegularExpressions;

namespace MarsRoverWorkShop.Command
{
    public interface IExecuter
    {
        void ExecuteCommand(string command);
        Regex CommandPattern { get; }        
        bool IsCommandMatched(string command);
    }
}
