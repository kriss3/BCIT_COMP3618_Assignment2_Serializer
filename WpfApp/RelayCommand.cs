using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace WpfApp
{
    public class RelayCommand : ICommand
    {
        private Action<object> execute;

        private Predicate<object> canExecute;

        public event EventHandler CanExecuteChanged;


        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            this.execute = execute;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            this.execute(parameter);
        }
    }
}
