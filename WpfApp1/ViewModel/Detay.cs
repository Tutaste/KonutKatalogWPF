using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    public class Detay : BaseViewModel
    {
        private Liste listeViewModel;

        public Detay(Liste listevm)
        {
            listeViewModel = listevm;
        }

        public Liste ListeViewModel 
        {
            get { return listeViewModel; }
            set
            {
                listeViewModel = value;
                OnPropertyChanged("ListeViewModel");
            }
        }
    }
}
