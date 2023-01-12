namespace GastroAPI.Models
{
    public class Item
    {
        // itemin tiedot tietokannassa
        public long Id { get; set; }
        public String Name { get; set; }
        public String Price { get; set; }
        public String Alv { get; set; }
        public String Calories { get; set; }
        public String? Description { get; set; }
        public String Image { get; set; }
    }

    public class ItemDTO
    {
        // itemin tiedot sivulla esitettyna
        public String Name { get; set; }
        public String Price { get; set; }
        public String Alv { get; set; }
        public String Calories { get; set; }
        public String? Description { get; set; }
        public String Image { get; set; }

    }
}
