
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPTreatment.Repository.Models
{
    public class TreatmentPlanValidation
    {
        [Required(ErrorMessage = "Please enter Treatment Plan Id")]
        [Display(Name = "Treatment Plan Id")]
        public int TreatmentPlanId { get; set; }

        [Required(ErrorMessage = "Please enter Pakage Name")]
        [Display(Name = "Package Name")]
        public string PackageName { get; set; }

        [Required(ErrorMessage = "Please enter Test Details")]
        [Display(Name = "Test Details")]
        public string TestDetails { get; set; }

        [Required(ErrorMessage = "Please enter cost6")]
        [Display(Name = "Cost")]
        public int Cost { get; set; }

        [Required(ErrorMessage = "Please enter Treatment Commencement Date")]
        [Display(Name = "Treatment Commencement Date")]
        public DateTime TreatmentCommencementDate { get; set; }

        [Required(ErrorMessage = "Please enter Treatment End Date")]
        [Display(Name = "Treatment End Date")]
        public DateTime TreatmentEndDate { get; set; }

        [Required(ErrorMessage = "Please enter Specialist Id")]
        [Display(Name = "Specialist Id")]
        public int SpecialistId { get; set; }

        [Required(ErrorMessage = "Please enter Patient Id")]
        [Display(Name = "Patient Id")]
        public int PatientId { get; set; }


        //public virtual SpecialistDetail SpecialistDetail { get; set; }
        public virtual PatientDetail PatientDetail { get; set; }

        [ModelMetadataType(typeof(TreatmentPlanValidation))]
        public partial class TreatmentPlan { }
    }
}

