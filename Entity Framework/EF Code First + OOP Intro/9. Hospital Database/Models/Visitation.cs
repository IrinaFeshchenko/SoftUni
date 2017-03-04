namespace _9.Hospital_Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Visitation
    {
        [Key]
        public int Id { get; set; }
        public DateTime? visitDate { get; set; }
        public string Notes { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
