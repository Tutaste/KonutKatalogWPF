using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp1.Model
{
    public class Daire : Konut
    {
        public int Kat { get; set; }

        public bool Balkon { get; set; }

        public bool Asansor { get; set; }

    }
}
