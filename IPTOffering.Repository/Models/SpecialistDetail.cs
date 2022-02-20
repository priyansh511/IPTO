using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPTOffering.Repository.Models
{
    [Table("SpecialistDetails")]
    public partial class SpecialistDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SpecialistId { get; set; }
        public string Name { get; set; }
        public string AreaOfExpertise { get; set; }
        public int ExperienceInYears { get; set; } //in years
        public string ContactNo { get; set; }


    }
}
