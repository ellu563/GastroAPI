namespace GastroAPI.Models
{
    public class Order
    {
        public long Id { get; set; }
        public Table? TableNumber { get; set; }
        public Item? Item { get; set; }
        public String Amount { get; set; }
    }
}
