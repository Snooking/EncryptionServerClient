using System;
using System.Windows.Input;

namespace BSK1.ViewModels
{
    internal class RelayCommand : ICommand
    {
        private Action _action;
        private Predicate<object> _canExecute;

        public RelayCommand(Action action)
        {
            _action = action;
            _canExecute = null;
        }

        public RelayCommand(Action action, Predicate<object> canExecute)
        {
            _action = action;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null ? true : _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _action();
        }
    }
}
