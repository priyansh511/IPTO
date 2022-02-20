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
    public class SpecialistController : ControllerBase
    {
        private readonly log4net.ILog _log = log4net.LogManager.GetLogger(typeof(SpecialistController));
        ISpecialistRepository ispRepo;
        public SpecialistController(ISpecialistRepository ispRepo)
        {
            this.ispRepo = ispRepo;
        }

        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<SpecialistDetail>>> GetAllSpecialistsAsync()
        {
            List<SpecialistDetail> specialistsList = await ispRepo.GetAllSpecialistsAsync();
            _log.Info("Specialist Details obtained");
            return Ok(specialistsList);
        }
    }
}
