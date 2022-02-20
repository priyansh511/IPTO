using InsuranceClaimRepository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaimRepository.Repos
{
    public interface IInitiateClaimRepo
    {
        Task InsertInitiateClaim(InitiateClaim initiateClaim);   //Insert
        Task<List<InitiateClaim>> GetAllClaims();
        
    }
}
