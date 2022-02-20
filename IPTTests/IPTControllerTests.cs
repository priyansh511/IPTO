using IPTreatment.Repository.Models;
using IPTreatment.Repository.Repos;
using IPTreatment.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPTTests
{
    public class IPTControllerTests
    {
        Mock<IPatientService> mock = new Mock<IPatientService>();
       
        [SetUp]
        public void Setup()
        { 
        }

        [Test]
        public async Task GetPatientByPatientId_Success()
        {
            PatientController patientController = new PatientController(new PatientService());
            int patientId = 1;
            ActionResult<PatientDetail> result = await patientController.GetPatientByPatientId(patientId);
            ObjectResult objectResult = result.Result as ObjectResult;
            string expected = "Raj";
            PatientDetail patientDetail = objectResult.Value as PatientDetail;
            string actual = patientDetail.Name;
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task GetPatientByPatientId_Failure()
        {
            PatientController patientController = new PatientController(new PatientService());
            int patientId = 1;
            ActionResult<PatientDetail> result = await patientController.GetPatientByPatientId(patientId);
            ObjectResult objectResult = result.Result as ObjectResult;
            string expected = "Seema";
            PatientDetail patientDetail = objectResult.Value as PatientDetail;
            string actual = patientDetail.Name;
            Assert.AreNotEqual(expected, actual);
        }
    }
}
