using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using WpfApp1.Model;

namespace WpfApp1.ViewModel
{
    public class Liste : BaseViewModel
    {
        private XmlSerializer serializer;
        private FileStream file;
        private List<Konut> konutlar = new List<Konut>();
        private Type[] types = { typeof(Daire), typeof(Villa)};
        private Konut seciliKonut;

        public Liste()
        {

            //konutlar.Add(new Daire() { Alan = 100, Fiyat = 500, Asansor = true, Balkon = true, Kat = 4}) ;
            //konutlar.Add(new Villa() { Alan = 200, Fiyat = 250, BahceAlani = 200, Garaj = false, VillaTipi = "Dublex"});
            //konutlar.Add(new Daire() { Alan = 600, Fiyat = 900, Asansor = false, Balkon = true, Kat = 3 });
            //konutlar.Add(new Villa() { Alan = 700, Fiyat = 400, BahceAlani = 250, Garaj = true, VillaTipi = "Triplex"});
            serializer = new XmlSerializer(typeof(List<Konut>), types);
            file = File.Open(@".\Konutlar.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite);
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

        public Konut SeciliKonut
        {
            get { return seciliKonut; }
            set
            {
                seciliKonut = value;
                OnPropertyChanged("SeciliKonut");
            }
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
