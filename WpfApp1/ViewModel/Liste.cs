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
    class Liste
    {
        private XmlSerializer serializer;
        private FileStream file;
        private List<Konut> konutlar = new List<Konut>();

        public Liste()
        {

            konutlar.Add(new Daire() { Alan = 100, Fiyat = 500 });
            serializer = new XmlSerializer(typeof(List<Konut>));
            file = File.Open("Konutlar.xml", FileMode.OpenOrCreate, FileAccess.ReadWrite);
            ReadXML();
        }

        public List<Konut> Konutlar
        {
            get { return konutlar; }
            set
            {
                konutlar = value;
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
