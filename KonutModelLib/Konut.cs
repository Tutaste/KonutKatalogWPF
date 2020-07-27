
using System;
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
        public event Action FavoriChanged;

        public int Alan { get; set; }

        public int Fiyat { get; set; }

        private bool _favori;

        public bool Favori
        {
            get
            {
                return _favori;
            }
            set
            {
                if (_favori == value)
                {
                    return;
                }
                _favori = value;
                OnFavoriChanged();
            }
        }

        private void OnFavoriChanged()
        {
            FavoriChanged?.Invoke();
        }
    }
}
