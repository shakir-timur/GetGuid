using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace GetGuid
{
    class QuickCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        Action execute;
        Func<bool> canExecute;

        public bool CanExecute(object parameter)
        {
            return canExecute.Invoke();
        }

        public void Execute(object parameter)
        {
            execute.Invoke();
        }

        public QuickCommand(Action execute, Func<bool> canExecute = null)
        {
            this.canExecute = canExecute ?? (() => true);
            this.execute = execute;
        }
    }
}
