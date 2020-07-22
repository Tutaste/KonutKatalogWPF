using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Serialization;
using KonutModelLib;
using WpfApp1.Command;

namespace WpfApp1.ViewModel
{
    public class ListeViewModel : BaseViewModel
    {
        private ICommand detayGoster;
        private MainViewModel mainViewModel;
        private ICommand favoriKaydet;

        public ListeViewModel(MainViewModel mainvm)
        {
            this.mainViewModel = mainvm;
            detayGoster = new DetayGosterCommand(mainViewModel);
            favoriKaydet = new FavoriKaydetCommand(mainViewModel);
        }

        public List<Konut> Konutlar
        {
            get
            {
                return mainViewModel.Konutlar;
            }
        }

        public Konut SeciliKonut
        {
            get { return mainViewModel.SeciliKonut; }
            set
            {
                mainViewModel.SeciliKonut = value;
                OnPropertyChanged(nameof(SeciliKonut));
            }
        }

        public ICommand DetayGoster
        {
            get { return detayGoster; }
            set
            {
                detayGoster = value;
            }
        }

        public ICommand FavoriKaydet
        {
            get { return favoriKaydet; }
            set
            {
                favoriKaydet = value;
            }
        }

        public MainViewModel MainViewModel { get => mainViewModel; set => mainViewModel = value; }
    }
}
