using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Triangle_Information.ViewModels
{
    /*
     * This is more boilerplate for the MVVM to work
     * This makes it so that we can execute commands in the xaml
     */
    public class DelegateCommand : ICommand
    {
        private SimpleEventHandler handler;
        private bool isEnabled = true;
        public event EventHandler CanExecuteChanged;
        public delegate void SimpleEventHandler();
        public DelegateCommand(SimpleEventHandler handler)
        {
            this.handler = handler;
        }

        public bool IsEnabled
        {
            get { return this.isEnabled; }
        }
        void ICommand.Execute(object parameter)
        {
            this.handler();
        }
        bool ICommand.CanExecute(object parameter)
        {
            return this.isEnabled;
        }
        private void OnCanExecutionChanged()
        {
            if (this.CanExecuteChanged != null)
            {
                this.CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}
