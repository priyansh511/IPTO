using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPTOffering.Repository.Models
{
    
    [Table("IPTreatmentPackage")]
    public partial class IPTreatmentPackage
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int IPTreatmentPackagesId { get; set; }
        public Ailment Ailment { get; set; }
        [ForeignKey("PackageDetail")]
        public int PackageId { get; set; }
        public virtual PackageDetail PackageDetail { get; set; }

    }
}
