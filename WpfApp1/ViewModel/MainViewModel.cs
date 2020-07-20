using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using WpfApp1.Command;
using WpfApp1.View;
using WpfApp1.ViewModel;

namespace WpfApp1.ViewModel
{
    class MainViewModel : BaseViewModel
    {
        private BaseViewModel currentViewModel;
        private Liste listeSayfasi;
        private ICommand detayGoster;

        public MainViewModel()
        {
            listeSayfasi = new Liste();
            currentViewModel = listeSayfasi;

            detayGoster = new DetayGosterCommand(this);
        }

        public BaseViewModel CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                currentViewModel = value;
                OnPropertyChanged("CurrentViewModel");
            }
        }

        public ICommand DetayGoster
        {
            get { return detayGoster; }
            set
            {
                detayGoster = value;
                OnPropertyChanged("DetayGoster");
            }
        }

        public void DetaySayfaAcma()
        {
            CurrentViewModel = new Detay(listeSayfasi);
            
        }



    }
}
