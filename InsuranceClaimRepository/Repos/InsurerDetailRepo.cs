using InsuranceClaimRepository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InsuranceClaimRepository.Repos
{
    public class InsurerDetailRepo : IInsurerDetailRepo
    {
        private readonly log4net.ILog _log = log4net.LogManager.GetLogger(typeof(InsurerDetailRepo));
        private readonly InsuranceClaimDbContext _context;

        public InsurerDetailRepo()
        {
            _context = new InsuranceClaimDbContext();
        }
        public async Task<List<InsurerDetail>> GetAllInsurerDetailsAsync()
        {
            _log.Info("Insurer details obtained");
            return await _context.InsurerDetails.ToListAsync();
            
        }

        public async Task<InsurerDetail> GetInsurerByPackageNameAsync(string packageName)
        {
            try
            {
                InsurerDetail insurerDetail = await (from i in _context.InsurerDetails where i.InsurerPackageName == packageName select i).FirstAsync();
                _log.Info("Insurer details obtained by Package Name");
                return insurerDetail;
            }
            catch (Exception)
            {
                _log.Info("Invalid Package Name given");
                throw new Exception("No such Insurer detail found");
            }
        }
    }
}
