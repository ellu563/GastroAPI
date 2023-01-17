using MessagePack;

namespace GastroAPI.Models
{
    public class Basket
    {
        // tämä menee tietokantaan, kun ostoskoriin on lisatty tavaraa
        public long Id { get; set; }
        public String TableNumber { get; set; } // huom. table modelia ei nyt kayteta
        public String Item { get; set; }
        public String Price { get; set; }
        public String Amount { get; set; } // pitää lisätä kentäksi
        public DateTime OrderTime { get; set; }
    }
    public class BasketDTO
    {
        // tämä tuodaan esiin ostoskorissa
        // public long Id { get; set; } otetaan pois
        public String? Item { get; set; } // reservationDTO:ssa tama myos string

        public String? Price { get; set; } // huom. reservationDTO:ssa tama on long tyyppinen
        public String? Amount { get; set; }
    }
}
