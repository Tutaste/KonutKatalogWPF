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
        private List<Konut> konutlar = new List<Konut>();
        private Konut seciliKonut;
        private ICommand detayGoster;
        private MainViewModel mainViewModel;

        public ListeViewModel(MainViewModel mainvm)
        {

            //konutlar.Add(new Daire() { Alan = 100, Fiyat = 500, Asansor = true, Balkon = true, Kat = 4}) ;
            //konutlar.Add(new Villa() { Alan = 200, Fiyat = 250, BahceAlani = 200, Garaj = false, VillaTipi = "Dublex"});
            //konutlar.Add(new Daire() { Alan = 600, Fiyat = 900, Asansor = false, Balkon = true, Kat = 3 });
            //konutlar.Add(new Villa() { Alan = 700, Fiyat = 400, BahceAlani = 250, Garaj = true, VillaTipi = "Triplex"});

            this.mainViewModel = mainvm;
            detayGoster = new DetayGosterCommand(mainViewModel);
        }

        public List<Konut> Konutlar
        {
            get { return konutlar; }
            set
            {
                konutlar = value;
                OnPropertyChanged("Konutlar");
            }
        }

        public Konut SeciliKonut
        {
            get { return seciliKonut; }
            set
            {
                seciliKonut = value;
                OnPropertyChanged("SeciliKonut");
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

        public MainViewModel MainViewModel { get => mainViewModel; set => mainViewModel = value; }
    }
}
