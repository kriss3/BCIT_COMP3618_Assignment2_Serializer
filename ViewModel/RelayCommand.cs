using System;
using System.Windows.Input;

namespace ViewModel
{
    /// <summary>
    /// Standard RelayCommand class implementation to handle UI Commands;;
    /// Krzysztof Szczurowski;
    /// BCIT COMP 3618;
    /// Repo: https://github.com/kriss3/BCIT_COMP3618_Assignment2_Serializer.git
    /// </summary>
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
