namespace GastroAPI.Models
{
    public class Basket
    {
        // tämä menee tietokantaan, kun ostoskoriin on lisatty tavaraa
        public long Id { get; set; }
        public long TableNumber { get; set; } // huom. table modelia ei nyt kayteta
        public virtual Item? Item { get; set; }
        public virtual Item? Price { get; set; }
        public String Amount { get; set; } // pitää lisätä kentäksi
        public DateTime OrderTime { get; set; }
    }
    public class BasketDTO
    {
        // tämä tuodaan esiin ostoskorissa
        // huom. ehka ei tuoda table numberia koska se on jo kannassa ja nakyy sivulla, talla tavoin voitaisiin ehka loopata sita sisaltoa
        public String Item { get; set; } // reservationDTO:ssa tama myos string
        public String Price { get; set; } // huom. reservationDTO:ssa tama on long tyyppinen
        public String Amount { get; set; }
    }

}
