using IPTOffering.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPTOffering.Repository.Repos
{
    public class IPTreatmentPackageRepository : IIPTreatmentPackageRepository
    {
        private readonly log4net.ILog _log = log4net.LogManager.GetLogger(typeof(IPTreatmentPackageRepository));
        IPTOContext dc;
        public IPTreatmentPackageRepository()
        {
            dc = new IPTOContext();
        }
        public async Task<List<IPTreatmentPackage>> GetAllIPTreatmentPackagesAsync()
        {

            List<IPTreatmentPackage> packages= await dc.IPTreatmentPackages.Include(p=>p.PackageDetail).ToListAsync();
            _log.Info("IP Treatment package table added");
            return packages;
        }

        public async Task<List<IPTreatmentPackage>> GetTreatmentPackageByNameAsync(string name)
        {
            try
            {
                List<PackageDetail> packages = await (from f in dc.PackageDetails where f.TreatmentPackageName == name select f).ToListAsync();
                List < IPTreatmentPackage > iptPackages= new List<IPTreatmentPackage>();
                foreach (PackageDetail pd in packages)
                {
                    IPTreatmentPackage package = await (from f in dc.IPTreatmentPackages where f.PackageId == pd.PackageId select f).Include(p => p.PackageDetail).FirstAsync();
                    iptPackages.Add(package);

                }
                _log.Info("Treatment Package By Name received");
                return iptPackages;
            }
            catch (Exception)
            {
                _log.Info("Package name not found");
                throw new Exception("No such package name");
            }
        }
    }
}
