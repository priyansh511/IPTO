using IPTOffering.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPTOffering.Repository.Repos
{
    public interface IIPTreatmentPackageRepository
    {
        Task<List<IPTreatmentPackage>> GetAllIPTreatmentPackagesAsync();
        Task<List<IPTreatmentPackage>> GetTreatmentPackageByNameAsync(string name);

    }
}
