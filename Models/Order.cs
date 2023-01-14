using System.ComponentModel.DataAnnotations;

namespace GastroAPI.Models
{
    public class Order
    {
        public long Id { get; set; }
        public String TableNumber { get; set; } // otetaan ylhaalta
        public List<BasketDTO>? Orders { get; set; }
        public DateTime OrderTime { get; set; } 
        public String Status { get; set; } 
    }
    public class OrderDTO
    {
        public String TableNumber { get; set; } // otetaan ylhaalta
        public virtual List<BasketDTO>? Orders { get; set; }
        public String Status { get; set; }

    }
}
