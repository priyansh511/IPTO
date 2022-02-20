using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPTreatment.Repository.Models
{
    [Table("TreatmentPlan")]
    public partial class TreatmentPlan
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int TreatmentPlanId { get; set; }
        public string PackageName { get; set; }
        public string TestDetails  { get; set; }
        public int Cost { get; set; }

        public DateTime TreatmentCommencementDate { get; set; }
        public DateTime TreatmentEndDate { get; set; }
        [ForeignKey("SpecialistDetail")]
        public int SpecialistId { get; set; }
        [ForeignKey("PatientDetail")]
        public int PatientId { get; set; }
        

        public virtual SpecialistDetail SpecialistDetail { get; set; }
        public virtual PatientDetail PatientDetail { get; set; }

    }
}
