using System.Threading.Tasks;
using System.Windows.Input;

namespace HomeWork11.Commands
{
    public interface IAsyncCommand : ICommand
    {
        Task ExecuteAsync(object parameter);
    }
}