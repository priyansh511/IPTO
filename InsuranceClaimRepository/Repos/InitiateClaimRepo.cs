using InsuranceClaimRepository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace InsuranceClaimRepository.Repos
{
    public class InitiateClaimRepo : IInitiateClaimRepo
    {
        private readonly log4net.ILog _log = log4net.LogManager.GetLogger(typeof(InitiateClaimRepo)); 
        private readonly InsuranceClaimDbContext _context;
       
        public InitiateClaimRepo()
        {
            _context = new InsuranceClaimDbContext();
        }


        public async Task InsertInitiateClaim(InitiateClaim initiateClaim)
        {
            await _context.InitiateClaims.AddAsync(initiateClaim);
            _log.Info("Claim added to Initate Claim table");
            await _context.SaveChangesAsync();
        }

        public async Task<List<InitiateClaim>> GetAllClaims()
        {
            _log.Info("All claims sent to web api");
            return await _context.InitiateClaims.Include(p => p.PatientDetail).Include(p => p.TreatmentPlan).Include(p => p.InsurerDetail).ToListAsync();
        }

    }
}
