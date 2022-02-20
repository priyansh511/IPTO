using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPTOffering.Repository.Models
{
    public class SpecialistDetailValidation
    {
        [Required(ErrorMessage = "Please enter Specialist Id")]
        [Display(Name = "Specialist Id")]
        public int SpecialistId { get; set; }

        [Required(ErrorMessage = "Please enter your name")]
        [Display(Name = "Specialist Name")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Please enter your Area Of Expertise")]
        [Display(Name = "Area Of Expertise")]
        public string AreaOfExpertise { get; set; }

        [Required(ErrorMessage = "Please enter your Experience In Years")]
        [Display(Name = "Experience In Years")]
        public int ExperienceInYears { get; set; } //in years

        [Required(ErrorMessage = "Please enter your Contact No")]
        [Display(Name = "Contact No")]
        public string ContactNo { get; set; }

        [ModelMetadataType(typeof(SpecialistDetailValidation))]
        public partial class SpecialistDetail { }
    }
}

