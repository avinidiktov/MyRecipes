using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using MvvmCross.Core.ViewModels;

namespace MyRecipes.Core.MvvmCrossExtension.Command
{

    /// <summary>
    /// https://github.com/slodge/MonoCrossExtensions/blob/master/Cirrious/Cirrious.MvvmCross/
    /// </summary>

    public interface IMvxCommand : ICommand
    {
        bool CanExecute(object parameter);
        void Execute(object parameter);
        event EventHandler CanExecuteChanged;
    }

    public class MvxRelayCommand : IMvxCommand
    {
        private readonly Action _execute;
        private readonly Func<bool> _canExecute;

        public MvxRelayCommand(Action execute)
            : this(execute, null)
        {
        }

        public MvxRelayCommand(Action execute, Func<bool> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged;

        public void RaiseCanExecuteChanged()
        {
            var handler = CanExecuteChanged;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute();
        }

        public void Execute(object parameter)
        {
            if (CanExecute(parameter))
            {
                _execute();
            }
        }
    }
}
