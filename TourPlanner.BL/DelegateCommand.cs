using System;
using System.Windows.Input;

namespace TourPlanner {
    public class DelegateCommand : ICommand {
        readonly Action<object> execute;
        readonly Predicate<object>? canExecute;

        public DelegateCommand(Predicate<object> canExecute, Action<object> execute) {
           this.execute = execute ?? throw new ArgumentNullException(nameof(execute));
            this.canExecute = canExecute;
            //(this.canExecute, this.execute) = (canExecute, execute);
        }
            

        public DelegateCommand(Action<object> execute) : this(null, execute) { }

        public event EventHandler? CanExecuteChanged;

        public void RaiseCanExecuteChanged() => CanExecuteChanged?.Invoke(this, EventArgs.Empty);

        public bool CanExecute(object? parameter) => canExecute?.Invoke(parameter) ?? true;

        public void Execute(object? parameter) => execute?.Invoke(parameter);
    }
}
