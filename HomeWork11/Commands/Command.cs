using System;
using System.Windows.Input;

namespace HomeWork11.Commands
{
    public class Command : ICommand
    {
        protected Action action = null;
        protected Action<object> parameterizedAction = null;

        private bool canExecute = false;

        public bool CanExecute
        {
            get { return canExecute; }
            set
            {
                if (canExecute != value)
                {
                    canExecute = value;
                    EventHandler canExecuteChanged = CanExecuteChanged;
                    if (canExecuteChanged != null)
                        canExecuteChanged(this, EventArgs.Empty);
                }
            }
        }

        public Command(Action action, bool canExecute = true)
        {
            //  Set the action.
            this.action = action;
            this.canExecute = canExecute;
        }

        public Command(Action<object> parameterizedAction, bool canExecute = true)
        {
            //  Set the action.
            this.parameterizedAction = parameterizedAction;
            this.canExecute = canExecute;
        }

        bool ICommand.CanExecute(object parameter)
        {
            return canExecute;
        }

        void ICommand.Execute(object parameter)
        {
            this.DoExecute(parameter);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            this.DoExecute(parameter);
        }

        protected void InvokeAction(object param)
        {
            Action theAction = action;
            Action<object> theParameterizedAction = parameterizedAction;
            if (theAction != null)
                theAction();
            else if (theParameterizedAction != null)
                theParameterizedAction(param);
        }

        public virtual void DoExecute(object param)
        {
            InvokeAction(param);
        }
    }
}