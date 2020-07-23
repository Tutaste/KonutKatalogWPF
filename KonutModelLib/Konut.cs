
using System.Xml.Serialization;

namespace KonutModelLib
{
    public enum Ozellik
    {
        Yok,
        Var
    }

    public abstract class Konut
    {
        public int Alan { get; set; }

        public int Fiyat { get; set; }

        public bool Favori { get; set; }
    }
}
