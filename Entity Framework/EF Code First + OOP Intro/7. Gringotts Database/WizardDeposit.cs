namespace _7.Gringotts_Database
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;

    public class WizardDeposit
    {
        [Key]
        public int Id { get; set; }

        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(60)]
        public string LastName { get; set; }

        [Column(TypeName = "text")]
        [StringLength(1000)]
        public string Notes { get; set; }

        [Range(0,200)]
        public int? Age { get; set; }

        [StringLength(100)]
        public string MagicWandCreator { get; set; }

        public short? MagicWandSize { get; set; }

        [StringLength(20)]
        public string DepositGroup { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DepositStartDate { get; set; }

        public decimal? DepositAmount { get; set; }

        public decimal? DepositInterest { get; set; }

        public decimal? DepositCharge { get; set; }

        [Column(TypeName = "date")]
        public DateTime? DepositExpirationDate { get; set; }

        public bool? IsDepositExpired { get; set; }
    }
}
