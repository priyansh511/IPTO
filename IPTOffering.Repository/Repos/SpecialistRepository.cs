using IPTOffering.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPTOffering.Repository.Repos
{
    public class SpecialistRepository : ISpecialistRepository
    {
        private readonly log4net.ILog _log = log4net.LogManager.GetLogger(typeof(SpecialistRepository));
        IPTOContext dc;
        public SpecialistRepository()
        {
            dc = new IPTOContext();
        }
        public async Task<List<SpecialistDetail>> GetAllSpecialistsAsync()
        {
            _log.Info("Specialist Details received");
            return await dc.SpecialistDetails.ToListAsync();
        }
    }
}
