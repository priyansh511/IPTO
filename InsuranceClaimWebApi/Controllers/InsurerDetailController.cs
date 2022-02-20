using InsuranceClaimRepository.Models;
using InsuranceClaimRepository.Repos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InsuranceClaimWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrators")]
    public class InsurerDetailController : ControllerBase
    {
        private readonly log4net.ILog _log = log4net.LogManager.GetLogger(typeof(InsurerDetailController));

        IInsurerDetailRepo insDetRep;
        public InsurerDetailController(IInsurerDetailRepo insDetRep)
        {
            this.insDetRep = insDetRep;
        }
        
     

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<InsurerDetail>>> GetAllInsurerDetails()
        {
            List<InsurerDetail> insurerDetails = await insDetRep.GetAllInsurerDetailsAsync();
            _log.Info("Insurer Details Sent");
            return Ok(insurerDetails);
        }


        [HttpGet]
        [Route("{packageName}")]
        [ProducesResponseType(200)]

        public async Task<ActionResult<InsurerDetail>> GetInsurerByPackageName(string packageName)
        {
            InsurerDetail insurer = await insDetRep.GetInsurerByPackageNameAsync(packageName);
            _log.Info("Insurer Details by Package Name Sent");
            return Ok(insurer);
        }
    }
}
