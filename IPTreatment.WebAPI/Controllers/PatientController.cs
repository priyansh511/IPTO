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
    public class PatientController : ControllerBase
    {
        private readonly log4net.ILog _log = log4net.LogManager.GetLogger(typeof(PatientController));
        IPatientService patientService;
        private void PublishToMessageQueue(string integrationEvent, string eventData)
        {
            var factory = new ConnectionFactory();
            var connection = factory.CreateConnection();
            var channel = connection.CreateModel();
            var body = Encoding.UTF8.GetBytes(eventData);
            channel.BasicPublish(exchange: "PatientDetail", routingKey: integrationEvent, basicProperties: null, body: body);
        }
        public PatientController(IPatientService patientService)
        {
            this.patientService = patientService;
        }
        [HttpGet]
        [ProducesResponseType(200)]
        public async Task<ActionResult<List<PatientDetail>>> GetAllPatientDetails()
        {
            List<PatientDetail> patientDetails = await patientService.GetAllPatientDetails();
            _log.Info("Patient details obtained");
            return Ok(patientDetails);
        }

        [HttpPost]
        [ProducesResponseType(201)]
        public async Task<ActionResult> InsertPatientDetails(PatientDetail patient)
        {
            await patientService.InsertPatient(patient);
            var integrationEventData = JsonConvert.SerializeObject(new { PatientId = patient.PatientId, Name = patient.Name, Ailment = patient.Ailment, Age = patient.Age, TreatmentPackageName = patient.TreatmentPackageName, TreatmentCommencementDate = patient.TreatmentCommencementDate, TreatmentStatus = patient.TreatmentStatus });
            PublishToMessageQueue("PatientDetail.add", integrationEventData);
            _log.Info("Treatment Timetable formulated");
            return Ok();
        }

        [HttpPut]
        [Route("{id}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult> MarkAsCompleted(int id, PatientDetail patientDetail)
        {
            await patientService.MarkAsCompleted(patientDetail);
            var integrationEventData = JsonConvert.SerializeObject(new { PatientId = patientDetail.PatientId , TreatmentStatus = patientDetail.TreatmentStatus });
            PublishToMessageQueue("PatientDetail.update", integrationEventData);
            _log.Info("Treatment has been completed");
            return Ok();
        }

        [HttpGet]
        [Route("{id}")]
        [ProducesResponseType(200)]
        public async Task<ActionResult<PatientDetail>> GetPatientByPatientId(int id)
        {
            PatientDetail patientDetail = await patientService.GetPatientByPatientIdAsync(id);
            _log.Info("Patient obtained by patient id");
            return Ok(patientDetail);
        }
    }
}
