
namespace _9.Hospital_Database
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Medicament
    {
        [Key]
        public int Id { get; set; }
        [StringLength(30, MinimumLength = 4, ErrorMessage = "Invalid Name")]
        public string Name { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
