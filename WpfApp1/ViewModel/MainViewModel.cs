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
        private BaseViewModel currentViewModel;
        private ListeViewModel listeSayfasi;
        

        private XmlSerializer serializer;
        private FileStream file;
        private List<Konut> konutlar = new List<Konut>();
        private Type[] types = { typeof(Daire), typeof(Villa) };

        public MainViewModel()
        {
            serializer = new XmlSerializer(typeof(List<Konut>), types);
            file = File.Open(@".\Konutlar.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
            ListeSayfasi = new ListeViewModel(this);
            CurrentViewModel = ListeSayfasi;

            ReadXML();
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

        public BaseViewModel CurrentViewModel
        {
            get { return currentViewModel; }
            set
            {
                currentViewModel = value;
                OnPropertyChanged("CurrentViewModel");
            }
        }


        public ListeViewModel ListeSayfasi
        {
            get { return listeSayfasi; }
            set
            {
                listeSayfasi = value;
                OnPropertyChanged("ListeSayfasi");
            }
        }

        public void DetaySayfaAcma()
        {
            CurrentViewModel = new DetayViewModel(ListeSayfasi);
        }

        public void ListeSayfasiAcma()
        {
            CurrentViewModel = ListeSayfasi;
        }

        public void ReadXML()
        {
            konutlar = (List<Konut>)serializer.Deserialize(file);
        }

        public void WriteXML()
        {
            serializer.Serialize(file, konutlar);
        }

    }
}
