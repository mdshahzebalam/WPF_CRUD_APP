using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using System.Windows.Input;


namespace Shahzeb.Model
{
    public class RelayCommand : ICommand
    {

        private Action DoWork;
        public RelayCommand(Action work)
        {
            DoWork = work;
        }
        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object? parameter)
        {
            return true;
        }

        public void Execute(object? parameter)
        {
            DoWork();
        }

        // ICommand Members
    }
}