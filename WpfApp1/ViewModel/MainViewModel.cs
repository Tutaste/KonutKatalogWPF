using KonutModelLib;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Xml.Serialization;
using WpfApp1.Command;
using WpfApp1.View;
using WpfApp1.ViewModel;

namespace WpfApp1.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private const string FilePath = @".\Konutlar.xml";

        private Konut seciliKonut;
        private BaseViewModel currentViewModel;

        private Type[] types = { typeof(Daire), typeof(Villa) };

        private ListeViewModel listeSayfasi;
        private DetayViewModel detaySayfasi;

        public MainViewModel()
        {
            Konutlar = new List<Konut>();
            //Konutlar.Add(new Daire() { Alan = 100, Fiyat = 500, Asansor = true, Balkon = true, Kat = 4, Favori = true });
            //Konutlar.Add(new Villa() { Alan = 200, Fiyat = 250, BahceAlani = 200, Garaj = false, VillaTipi = "Dublex", Favori = false });
            //Konutlar.Add(new Daire() { Alan = 600, Fiyat = 900, Asansor = false, Balkon = true, Kat = 3, Favori = true });
            //Konutlar.Add(new Villa() { Alan = 700, Fiyat = 400, BahceAlani = 250, Garaj = true, VillaTipi = "Triplex", Favori = true });

            listeSayfasi = new ListeViewModel(this);
            detaySayfasi = new DetayViewModel(this);
            CurrentViewModel = listeSayfasi;

            WriteXML();
            ReadXML();
        }

        public List<Konut> Konutlar
        {
            get;
            set;
        }

        public Konut SeciliKonut
        {
            get
            {
                return seciliKonut;
            }
            set
            {
                seciliKonut = value;
                OnPropertyChanged(nameof(SeciliKonut));
            }
        }

        public BaseViewModel CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                currentViewModel = value;
                OnPropertyChanged(nameof(CurrentViewModel));
            }
        }

        public void DetaySayfaAcma()
        {
            CurrentViewModel = detaySayfasi;
        }

        public void ListeSayfasiAcma()
        {
            CurrentViewModel = listeSayfasi;
        }

        private void ReadXML()
        {
            if (File.Exists(FilePath))
            {
                using (var file = GetFileStream())
                {
                    var serializer = new XmlSerializer(typeof(List<Konut>), types);
                    Konutlar = serializer.Deserialize(file) as List<Konut>;
                }
            }
            else
            {
                WriteXML();
            }
        }

        public void WriteXML()
        {
            using (var file = GetFileStream())
            {
                var serializer = new XmlSerializer(typeof(List<Konut>), types);
                serializer.Serialize(file, Konutlar);
            }
        }

        private FileStream GetFileStream()
        {
            return File.Open(FilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
        }

    }
}
