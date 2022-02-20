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
    [Table("TreatmentPlan")]
    public partial class TreatmentPlan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int TreatmentPlanId { get; set; }
        public string PackageName { get; set; }
        public string TestDetails { get; set; }
        public int Cost { get; set; }

        public DateTime TreatmentCommencementDate { get; set; }
        public DateTime TreatmentEndDate { get; set; }
        public int SpecialistId { get; set; }

        public int PatientId { get; set; }
        

        //public virtual SpecialistDetail SpecialistDetail { get; set; }
        public virtual PatientDetail PatientDetail { get; set; }
        public virtual InitiateClaim InitiateClaim { get; set; }

    }
}