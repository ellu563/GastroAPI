namespace GastroAPI.Models
{
    public class Order
    {
        public long Id { get; set; }
        public String TableNumber { get; set; } // otetaan ylhaalta
        public String ItemName { get; set; } // voitaisiinko esitellä stringeina, silla baskettiin tuodaan string muotoista tavaraa
        public String Price { get; set; }
        public String Amount { get; set; }
        public DateTime OrderTime { get; set; } 
        public String Status { get; set; } // pystyykö esim. buttonin funktioon lisaamaan tan statuksen
        // kun nappia painettu, status olisi "open"
    }
    public class OrderDTO
    {
        // tuotaisiin esiin vaan item, price, amount, time, ja status, jolloin esim. pöytä 1 teksti olisi jo frontissa
        // get kutsut olisi siis pöydille erikseen
        // pöytä 1 > get ...jotain/tablenumber563
        // pöytä 2 > get ..jotain/{{tablenumber234}}
        public String ItemName { get; set; } 
        public String Price { get; set; }
        public String Amount { get; set; }
        public DateTime OrderTime { get; set; }
        public String Status { get; set; } // pystyykö esim. buttonin funktioon lisaamaan tan statuksen
        // kun nappia painettu, status olisi "open"
    }
}
