namespace GastroAPI.Models
{
    public class Item
    {
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
        public String Name { get; set; }
        public String Price { get; set; }
        public String Alv { get; set; }
        public String Calories { get; set; }
        public String? Description { get; set; }
        public String Image { get; set; }

    }
}
