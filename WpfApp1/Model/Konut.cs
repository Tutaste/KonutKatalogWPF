using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace WpfApp1.Model
{
    [XmlInclude(typeof(Daire))]
    public abstract class Konut
    {
        public int Alan { get; set; }

        public int Fiyat { get; set; }
    }
}
