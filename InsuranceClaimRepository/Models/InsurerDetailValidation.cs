using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaimRepository.Models
{
    public class InsurerDetailValidation       // Buddy class
    {


        [Required(ErrorMessage = "Please enter Insurance Amount Limit")]
        [Display(Name = "Insurance Amount Limit")]
        public decimal InsuranceAmountLimit { get; set; }


        [Required(ErrorMessage = "Please enter Disbursement Duration")]
        [Display(Name = "Disbursement Duration")]
        [Range(1, 5, ErrorMessage = "Disbursement Duration should be between 1-5 days")]
        public int DisbursementDuration { get; set; }


        [Required(ErrorMessage = "Please enter Insurer Name")]
        [MaxLength(30, ErrorMessage = "Patient name can be max 30 characters")]
        [Display(Name = "Insurer Name")]
        public string InsurerName { get; set; }

        [Required(ErrorMessage = "Please enter Insurer Package Name")]
        [MaxLength(30, ErrorMessage = "Insurer package name can be max 30 characters")]
        [Display(Name = "Insurer Package Name")]
        public string InsurerPackageName { get; set; }


    }

    [ModelMetadataType(typeof(InsurerDetailValidation))]
    public partial class InsurerDetail { }
}
