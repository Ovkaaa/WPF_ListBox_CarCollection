using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CollectionCars.Infrostructure
{
    public class DelegateCommand : ICommand
    {
        private Func<object, bool> canExecuteMethod;
        private Action<object> executeMethod;

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public DelegateCommand(Action<object> eM, Func<object, bool> cEM = null)
        {
            executeMethod = eM;
            canExecuteMethod = cEM;
        }

        public bool CanExecute(object parameter)
        {
            return canExecuteMethod == null || canExecuteMethod(parameter);
        }

        public void Execute(object parameter)
        {
            executeMethod(parameter);
        }
    }
}
