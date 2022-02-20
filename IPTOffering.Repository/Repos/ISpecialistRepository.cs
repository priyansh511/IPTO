using IPTOffering.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPTOffering.Repository.Repos
{
    public interface ISpecialistRepository
    {
        Task<List<SpecialistDetail>> GetAllSpecialistsAsync();
        
    }
}
