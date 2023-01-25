namespace GastroAPI.Models
{
    public class Products
    {
        public long Id { get; set; } 

        public long ProductId { get; set; }
        public String? Item { get; set; } 

        public String? Price { get; set; } 
        public String? Amount { get; set; }

        public String? Status { get; set; }
    }

    public class ProductsDTO
    {
        public String? Item { get; set; }

        public String? Price { get; set; }
        public String? Amount { get; set; }
    }

}
