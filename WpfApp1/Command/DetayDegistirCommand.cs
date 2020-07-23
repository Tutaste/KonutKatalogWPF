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
    class DetayDegistirCommand : ICommand
    {
        private MainViewModel viewModel;

        public DetayDegistirCommand(MainViewModel mainViewModel)
        {
            this.viewModel = mainViewModel;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            int i = int.Parse(parameter.ToString());

            int index = viewModel.Konutlar.IndexOf(viewModel.SeciliKonut) + i;
            if(i == 1)
            {
                if (index == viewModel.Konutlar.Count)
                {
                    index = 0;
                }
            }
            else if(i == -1)
            {
                if (index == -1)
                {
                    index = viewModel.Konutlar.Count - 1;
                }
            }
            
            viewModel.SeciliKonut = viewModel.Konutlar[index];
        }
    }
}
