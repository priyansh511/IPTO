using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaimRepository.Models
{
    [Table("InsurerDetail")]
    public partial class InsurerDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InsurerId { get; set; }

        [StringLength(30)]
        [Required]
        public string InsurerName { get; set; }

        [StringLength(30)]
        [Required]
        public string InsurerPackageName { get; set; }

        public decimal InsuranceAmountLimit { get; set; }

        public int DisbursementDuration { get; set; }

        public virtual ICollection<InitiateClaim> InitiateClaims { get; set; }

        public InsurerDetail()
        {
            InitiateClaims = new HashSet<InitiateClaim>();
        }
    }
}
