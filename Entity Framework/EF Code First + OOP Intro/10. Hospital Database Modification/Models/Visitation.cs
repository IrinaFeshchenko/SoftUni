namespace _10.Hospital_Database_Modification
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Visitation
    {
        [Key]
        public int Id { get; set; }
        public DateTime? visitDate { get; set; }
        public string Notes { get; set; }
        public int PatientId { get; set; }
        public virtual Patient Patient { get; set; }
        public int DoctorId { get; set; }
        public virtual Patient Doctor { get; set; }
    }
}
