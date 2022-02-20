using IPTOffering.Repository.Models;
using IPTOffering.Repository.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPTOffering.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrators")]
    public class IPTreatmentPackageController: ControllerBase
    {
        private readonly log4net.ILog _log = log4net.LogManager.GetLogger(typeof(IPTreatmentPackageController));
        IIPTreatmentPackageRepository iptRepo;
        public IPTreatmentPackageController(IIPTreatmentPackageRepository iptRepo)
        {
            this.iptRepo = iptRepo;
        }

        

        [HttpGet]
        [Route("{packageName}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(404)]
        public async Task<ActionResult<List<IPTreatmentPackage>>> GetTreatmentPackageByName(string packageName)
        {
            try
            {
                List<IPTreatmentPackage> iptPackages = await iptRepo.GetTreatmentPackageByNameAsync(packageName);
                _log.Info("Treatment package by name obtained");
                return Ok(iptPackages);
            }
            catch (Exception ex)
            {
                _log.Info("No such treatment package by name found");
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<IPTreatmentPackage>>> GetAllIPTreatmentPackagesAsync()
        {
            List<IPTreatmentPackage> iptPackageList = await iptRepo.GetAllIPTreatmentPackagesAsync();
            _log.Info("All IP Treatment Packages obtained");
            return Ok(iptPackageList);
        }


    }
}
