using IPTreatment.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPTOffering.Repository.Models
{
    public class PackageDetailValidation
    {
        [Required(ErrorMessage = "Please enter Package Id")]
        [Display(Name = "Package Id")]
        public int PackageId { get; set; }

        [Required(ErrorMessage = "Please enter Treatment Package Name ")]
        [Display(Name = "Treatment Package name")]
        public string TreatmentPackageName { get; set; }

        [Required(ErrorMessage = "Please enter Test Details")]
        [Display(Name = "Test Details")]
        public string TestDetails { get; set; }

        [Required(ErrorMessage = "Please enter Cost")]
        [Display(Name = "Cost")]
        public decimal Cost { get; set; }

        [Required(ErrorMessage = "Please enter Treatment Duration")]
        [Display(Name = "Treatment Duration")]
        public int TreatmentDuration { get; set; }


        public virtual ICollection<IPTreatmentPackage> IPTreatmentPackages { get; set; }


        public PackageDetailValidation()
        {
            IPTreatmentPackages = new HashSet<IPTreatmentPackage>();

        }

        [ModelMetadataType(typeof(PackageDetailValidation))]
        public partial class PackageDetail { }
    }
}

