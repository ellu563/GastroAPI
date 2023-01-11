using System.ComponentModel.DataAnnotations;

namespace GastroAPI.Models
{
    public class Table
    {
        public long Id { get; set; }
        public String TableNumber { get; set; }
        public DateTime Time { get; set; }
        public String Status { get; set; }
    }
}
