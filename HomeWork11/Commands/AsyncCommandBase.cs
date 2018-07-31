using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace HomeWork11.Commands
{
    public class AsyncCommandBase : IAsyncCommand
    {
        private readonly Func<object, Task> _parametrizedCommand;
        private readonly Func<Task> _command;
        private bool _canExecute;

        public bool CanExecute
        {
            get { return _canExecute; }
            set
            {
                if (_canExecute != value)
                {
                    _canExecute = value;
                    var canExecuteChanged = CanExecuteChanged;
                    canExecuteChanged?.Invoke(this, EventArgs.Empty);
                }
            }
        }

        public AsyncCommandBase(Func<object, Task> parametrizedCommand, bool canExecute = true)
        {
            _parametrizedCommand = parametrizedCommand;
            _canExecute = canExecute;
        }

        public AsyncCommandBase(Func<Task> command, bool canExecute = true)
        {
            _command = command;
            _canExecute = canExecute;
        }


        public Task ExecuteAsync(object parameter)
        {
            if (_command != null)
                return _command();

            return _parametrizedCommand?.Invoke(parameter);
        }


        bool ICommand.CanExecute(object parameter)
        {
            return _canExecute;
        }

        public async void Execute(object parameter)
        {
            await ExecuteAsync(parameter);
        }

        public event EventHandler CanExecuteChanged;
    }
}