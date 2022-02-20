using InsuranceClaimRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaimRepository.Repos
{
    public interface IInsurerDetailRepo
    {
        Task<List<InsurerDetail>> GetAllInsurerDetailsAsync();
        Task<InsurerDetail> GetInsurerByPackageNameAsync(string packageName);
    }
}
