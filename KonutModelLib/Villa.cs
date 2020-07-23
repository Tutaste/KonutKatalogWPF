

namespace KonutModelLib
{
    public enum VillaTipi
    {
        Dublex,
        Triplex
    }


    public class Villa : Konut
    {
        

        public int BahceAlani { get; set; }

        public Ozellik Garaj { get; set; } 

        public VillaTipi VillaTipi { get; set; }

    }
}
