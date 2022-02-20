using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using IPTreatment.Repository.Repos;
using IPTreatment.Repository.Models;
using Microsoft.AspNetCore.Authorization;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;

namespace IPTreatment.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "Administrators")]
    public class InpatientServiceController : ControllerBase
    {
        private readonly log4net.ILog _log = log4net.LogManager.GetLogger(typeof(InpatientServiceController));
        IInpatientService inpatientService;
        private void PublishToMessageQueue(string integrationEvent, string eventData)
        {
            var factory = new ConnectionFactory();
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            var body = Encoding.UTF8.GetBytes(eventData);
            channel.BasicPublish(exchange: "TreatmentPlan", routingKey: integrationEvent, basicProperties: null, body: body);
        }
        public InpatientServiceController(IInpatientService inpatientService)
        {
            this.inpatientService = inpatientService;
        }

        [HttpPost]
        [ProducesResponseType(201)]
        [ProducesResponseType(404)]
        public async Task<ActionResult> FormulateTreatmentTimetable(PatientDetail patientDetail)
        {
            try
            {
                TreatmentPlan treatmentPlan = await inpatientService.FormulateTreatmentTimetable(patientDetail);
                var integrationEventData = JsonConvert.SerializeObject(new { TreatmentPlanId = treatmentPlan.TreatmentPlanId, PackageName = treatmentPlan.PackageName, TestDetails = treatmentPlan.TestDetails, Cost = treatmentPlan.Cost, TreatmentCommencementDate = treatmentPlan.TreatmentCommencementDate, TreatmentEndDate = treatmentPlan.TreatmentEndDate, SpecialistId = treatmentPlan.SpecialistId, PatientId = treatmentPlan.PatientId });
                PublishToMessageQueue("TreatmentPlan.add", integrationEventData);
                _log.Info("Timetable formulated");
                return Ok();
            }
            catch (Exception ex)
            {
                return NotFound(ex.Message);
            }
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<TreatmentPlan>> GetTreatmentPlanByPatientId(int id)
        {
            TreatmentPlan treatmentPlan = await inpatientService.GetTreatmentPlanByPatientIdAsync(id);
            _log.Info("returned treatment plan to mvc");
            return treatmentPlan;
        }
    }
}
