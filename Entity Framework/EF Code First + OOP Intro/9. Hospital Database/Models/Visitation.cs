namespace _9.Hospital_Database
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
    }
}
