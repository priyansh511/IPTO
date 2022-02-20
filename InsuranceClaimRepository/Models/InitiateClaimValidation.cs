using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaimRepository.Models
{ 
    public class InitiateClaimValidation       // Buddy class
    {
        
        
        [Required(ErrorMessage = "Please enter Patient Id")]
        [Display(Name ="Patient Id")]
        public int PatientId { get; set; }

        [Required(ErrorMessage ="Please select an ailment")]
        public Ailment Ailment { get; set; }

        [Required(ErrorMessage = "Please enter Treatment Plan Id")]
        [Display(Name = "Treatment Plan Id")]
        public int TreatmentPlanId { get; set; }

        [Required(ErrorMessage = "Please select Insurer Id")]
        [Display(Name = "Insurer Id")]
        public int InsurerId { get; set; }

    }

    [ModelMetadataType(typeof(InitiateClaimValidation))]
    public partial class InitiateClaim { }
}
