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
        private ListeViewModel listeViewModel;
        private ICommand listeGoster;

        public DetayViewModel(ListeViewModel listevm)
        {
            this.listeViewModel = listevm;

            listeGoster = new ListeGosterCommand(listevm.MainViewModel);
        }

        public ListeViewModel ListeViewModel 
        {
            get { return listeViewModel; }
            set
            {
                listeViewModel = value;
                OnPropertyChanged("ListeViewModel");
            }
        }

        public ICommand ListeGoster
        {
            get { return listeGoster; }
            set { listeGoster = value; }
        }

    }
}
