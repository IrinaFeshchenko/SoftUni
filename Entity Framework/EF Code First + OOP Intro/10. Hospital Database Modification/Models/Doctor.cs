namespace _10.Hospital_Database_Modification
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Doctor
    {
        [Key]
        public int Id { get; set; }

        [StringLength(30, ErrorMessage = "Invalid FirstName", MinimumLength = 4)]
        public string Name { get; set; }

        [StringLength(30, ErrorMessage = "Invalid Specialty", MinimumLength = 2)]
        public string Specialty { get; set; }

        public virtual ICollection<Visitation> Visitations { get; set; }
        public virtual Visitation Visitation { get; set; }

        public virtual ICollection<Patient> Patients { get; set; }
        public virtual Patient Patient { get; set; }
    }
}
