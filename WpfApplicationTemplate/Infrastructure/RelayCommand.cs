using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApplicationTemplate.Infrastructure
{
    public class RelayCommand<T> : ICommand
    {
        protected readonly Action<T?> _execute;
        protected readonly Func<T?, bool>? _canExecute;

        public RelayCommand(Action<T?> execute, Func<T?, bool>? canExecute = null)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute), "Command must have execute action provided");
            _canExecute = canExecute;
        }

        public bool CanExecute(object? parameter) => _canExecute == null || _canExecute((T?)parameter);

        public void Execute(object? parameter)
        {
            _execute((T?)parameter);
        }

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }
    }

    public class RelayCommand : RelayCommand<object?>
    {
        public RelayCommand(Action<object?> execute, Func<object?, bool>? canExecute = null)
            : base(execute, canExecute)
        { }
    }
}
