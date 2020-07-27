using KonutModelLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfApp1.Command;

namespace WpfApp1.ViewModel
{
    public class DetayViewModel : BaseViewModel
    {
        private MainViewModel mainViewModel;
        private ICommand listeGoster;
        

        public Konut SeciliKonut
        {
            get { return mainViewModel.SeciliKonut; }
            set
            {
                mainViewModel.SeciliKonut = value;
                OnPropertyChanged(nameof(SeciliKonut));
            }
        }

        public DetayViewModel(MainViewModel mainViewModel)
        {
            this.mainViewModel = mainViewModel;
            mainViewModel.PropertyChanged += MainViewModel_PropertyChanged;

            listeGoster = new ListeGosterCommand(mainViewModel);
            DetayDegistir = new DetayDegistirCommand(mainViewModel);
        }

        private void MainViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
        {
            if (e.PropertyName.Equals(nameof(MainViewModel.SeciliKonut)))
            {
                OnPropertyChanged(nameof(SeciliKonut));
            }
        }


        public ICommand ListeGoster
        {
            get { return listeGoster; }
            set { listeGoster = value; }
        }

        public ICommand DetayDegistir
        {
            get; set;
        }

    }
}
