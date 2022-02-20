using IPTreatment.Repository.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPTOffering.Repository.Models
{
    public class IPTreatmentPackageValidation
    {
        [Required(ErrorMessage = "Please enter IP Treatment Package Id")]
        [Display(Name = "IP Treatment Package Id")]
        public int IPTreatmentPackagesId { get; set; }

        [Required(ErrorMessage = "Please select an ailment")]
        public Ailment Ailment { get; set; }
        [ForeignKey("PackageDetail")]

        [Required(ErrorMessage = "Please enter Package Id")]
        [Display(Name = "Package Id")]
        public int PackageId { get; set; }

        [Required(ErrorMessage = "Please enter Package Detail")]
        [Display(Name = "Package Detail")]
        public virtual PackageDetail PackageDetail { get; set; }

        [ModelMetadataType(typeof(IPTreatmentPackageValidation))]
        public partial class IPTreatmentPackage { }
    }
}
