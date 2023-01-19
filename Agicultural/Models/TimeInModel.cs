using System.ComponentModel.DataAnnotations.Schema;

namespace Agicultural.Models
{
    public class TimeInModel
    {
        [Column("timein")]
        public string? timein { get; set; }
        [Column("timeout")]
        public string? timeout { get; set; }
        [Column("date")]
        public string? date { get; set; }
        [Column("empid")]
        public string? empid { get; set; }
    }
}
