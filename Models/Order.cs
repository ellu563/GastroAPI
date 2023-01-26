using System.ComponentModel.DataAnnotations;

namespace GastroAPI.Models
{
    public class Order
    {
        public long Id { get; set; }
        public String TableNumber { get; set; } 
        public List<Products>? Orders { get; set; }
        public DateTime OrderTime { get; set; } 
        public String Status { get; set; } 
    }
    public class OrderDTO
    {
        public String TableNumber { get; set; } 
        public virtual List<Products>? Orders { get; set; }
        public String Status { get; set; }

    }
}
