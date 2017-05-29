namespace _10.Hospital_Database_Modification
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;

    public class Patient
    {
        public Patient()
        {
            Visitations = new HashSet<Visitation>();
            Diagnoses = new HashSet<Diagnosis>();
            Medicaments = new HashSet<Medicament>();
        }

        [Key]
        public int Id { get; set; }

        [StringLength(30, ErrorMessage ="Invalid FirstName", MinimumLength = 4)]
        public string FirstName { get; set; }

        [StringLength(30, ErrorMessage ="Invalid LastName",MinimumLength = 4)]
        public string LastName { get; set; }

        [StringLength(1024, ErrorMessage ="Invalid Address", MinimumLength = 4)]
        public string Address { get; set; }

        [Required]
        [RegularExpression(@"^[A-Za-z0-9]+[.-_]*[A-Za-z0-9]+@\w+[.]+\w+$",ErrorMessage ="Invalid Email")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public DateTime? DateOfBirth { get; set; }

        [MaxLength(1024 * 1024,ErrorMessage ="Invalid Image Size")]
        public byte[] Picture { get; set; }

        public bool? HasInsurance { get; set; }

        public virtual ICollection<Visitation> Visitations { get; set; }
        public virtual Visitation Visitation { get; set; }

        public virtual ICollection<Diagnosis> Diagnoses { get; set; }
        public virtual Diagnosis Diagnose { get; set; }

        public virtual ICollection<Medicament> Medicaments { get; set; }
        public virtual Medicament Medicament { get; set; }

        public int DoctorId { get; set; }
        public virtual Doctor doctor { get; set; }
    }
}
