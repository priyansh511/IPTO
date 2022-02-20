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

    [Table("PatientDetail")]
    public partial class PatientDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PatientId { get; set; }

        public string Name { get; set; }

        public Ailment Ailment { get; set; }

        public int Age { get; set; }

        
        public string TreatmentPackageName { get; set; }

        public string TreatmentStatus { get; set; }
        public DateTime TreatmentCommencementDate { get; set; }
        

        public virtual ICollection<TreatmentPlan> TreatmentPlans { get; set; }

        public virtual ICollection<InitiateClaim> InitiateClaims { get; set; }

        public PatientDetail()
        {
            TreatmentPlans = new HashSet<TreatmentPlan>();
            InitiateClaims = new HashSet<InitiateClaim>();
        }
        
    }
}