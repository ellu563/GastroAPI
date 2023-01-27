using MessagePack;
using System.ComponentModel.DataAnnotations;
using KeyAttribute = System.ComponentModel.DataAnnotations.KeyAttribute;

namespace GastroAPI.Models
{
    public class Basket
    {
        [Key]
        // huom. productId olisi paremmin ollut nimetty basketId
        public long ProductId { get; set; }
        public String TableNumber { get; set; } 
        public String CustomerCode { get; set; }
        public String Item { get; set; }
        public String Price { get; set; }
        public String Amount { get; set; } 
        public DateTime OrderTime { get; set; }
        public String Status { get; set; }
    }
    public class BasketDTO
    {
        // tämä tuodaan esiin ostoskorissa
        [Key]
        public long ProductId { get; set; } 
        public String? Item { get; set; } 

        public String? Price { get; set; } 
        public String? Amount { get; set; }
        public string Status { get; set; }
    }
}
