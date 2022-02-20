using InsuranceClaimRepository.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaimRepository.Models
{
    

    [Table("InitiateClaim")]
    public partial class InitiateClaim
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int InitiationId { get; set; }

        
        [ForeignKey("PatientDetail")]
        public int PatientId { get; set; }

        public Ailment Ailment { get; set; }

        [ForeignKey("TreatmentPlan")]
        public int TreatmentPlanId { get; set; }

        
        [ForeignKey("InsurerDetail")]
        public int InsurerId { get; set; }

        public virtual InsurerDetail InsurerDetail { get; set; }
        public virtual TreatmentPlan TreatmentPlan { get; set; }
        public virtual PatientDetail PatientDetail { get; set; }


    }
}
