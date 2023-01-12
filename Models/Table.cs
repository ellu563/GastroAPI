using System.ComponentModel.DataAnnotations;

namespace GastroAPI.Models
{
    public class Table
    {
        // viela mietinnassa tarviiko tata
        public long Id { get; set; }
        public String TableNumber { get; set; }
        public DateTime Time { get; set; }
        public String Status { get; set; }
    }
}
