using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp1.ViewModel;

namespace WpfApp1.Command
{
    class DetayGosterCommand : ICommand
    {
        private MainViewModel mainViewModel;

        public DetayGosterCommand(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            if (mainViewModel.SeciliKonut == null)
            {
                return false;
            }
            else
            {
                return true;
            }
            
        }

        public void Execute(object parameter)
        {
            mainViewModel.DetaySayfaAcma();
        }
    }
}
