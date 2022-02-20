
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPTreatment.Repository.Models
{
    public class PatientDetailValidation
    {
        [Required(ErrorMessage = "Please enter Patient Id")]
        [Display(Name = "Patient Id")]
        public int PatientId { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        [Display(Name = "Patient Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please select an ailment")]
        public Ailment Ailment { get; set; }

        [Required(ErrorMessage = "Please enter your age")]
        [Display(Name = "Patient Age")]
        public int Age { get; set; }


        [Required(ErrorMessage = "Please enter Treatment Package Name")]
        [Display(Name = "Treatment Package Name")]
        public string TreatmentPackageName { get; set; }

        [Required(ErrorMessage = "Please enter Treatment Status")]
        [Display(Name = "Treatment Status")]
        public string TreatmentStatus { get; set; }

        [Required(ErrorMessage = "Please enter Treatment Commencement Date")]
        [Display(Name = "Treatment Commencement Date")]
        public DateTime TreatmentCommencementDate { get; set; }


        public virtual ICollection<TreatmentPlan> TreatmentPlans { get; set; }

       

        public PatientDetailValidation()
        {
            TreatmentPlans = new HashSet<TreatmentPlan>();
            
        }

        [ModelMetadataType(typeof(PatientDetailValidation))]
        public partial class PatientDetail { }
    }
}

