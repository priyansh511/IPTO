using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace IPTOffering.Repository.Models
{
    [Table("PackageDetail")]
    public partial class PackageDetail
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int PackageId { get; set; }
        
        public string TreatmentPackageName { get; set; }
        public string TestDetails { get; set; }
        public decimal Cost { get; set; }
        public int TreatmentDuration { get; set; }

        public virtual ICollection<IPTreatmentPackage> IPTreatmentPackages { get; set; }
        
        
        public PackageDetail()
        {
            IPTreatmentPackages = new HashSet<IPTreatmentPackage>();
            
        }
        
    }
}
