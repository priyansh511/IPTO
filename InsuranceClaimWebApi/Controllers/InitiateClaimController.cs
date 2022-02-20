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
    public class InitiateClaimController : ControllerBase
    {
        private readonly log4net.ILog _log = log4net.LogManager.GetLogger(typeof(InitiateClaimController));

        IInitiateClaimRepo initClaimRep;
        public InitiateClaimController(IInitiateClaimRepo initClaimRep)
        {
            this.initClaimRep = initClaimRep;
        }

        [HttpGet]
        public async Task<ActionResult<List<InitiateClaim>>> GetAllClaims()
        {
            return await initClaimRep.GetAllClaims();
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult<InitiateClaim>> InsertIniiateClaim(InitiateClaim initiateClaim)
        {
            await initClaimRep.InsertInitiateClaim(initiateClaim);
            _log.Info("New claim initiated");
            return Ok(initiateClaim);
        }

        
    }
}
