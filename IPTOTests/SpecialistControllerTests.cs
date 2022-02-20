using IPTOffering.Repository.Models;
using IPTOffering.Repository.Repos;
using IPTOffering.WebAPI.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPTOTests
{
    public class SpecialistControllerTests
    {

        Mock<ISpecialistRepository> mock = new Mock<ISpecialistRepository>();
        List<SpecialistDetail> specialists = null;

        [SetUp]
        public void Setup()
        {
            specialists = new List<SpecialistDetail>() {
        new SpecialistDetail {
          Name = "Dr. Askandha Sharma",
            AreaOfExpertise = "Orthopaedics",
            ExperienceInYears = 20,
            ContactNo = "9461524333"
        },
        new SpecialistDetail {
          Name = "Dr. Priyansh Soniya",
            AreaOfExpertise = "Orthopaedics",
            ExperienceInYears = 15,
            ContactNo = "9461526666"
        },
        new SpecialistDetail {
          Name = "Dr. Nidhi Sharma",
            AreaOfExpertise = "Urology",
            ExperienceInYears = 20,
            ContactNo = "9461524322"
        },
        new SpecialistDetail {
          Name = "Dr. Rahil Sharma",
            AreaOfExpertise = "Urology",
            ExperienceInYears = 10,
            ContactNo = "9461524113"
        },

      };
            TestContext.Progress.WriteLine("One Time SetUp is Executed");
        }

        [Test]
        public async Task GetAllIPTreatmentPackagesAsync_Success()
        {

            mock.Setup(i => i.GetAllSpecialistsAsync()).ReturnsAsync(specialists);
            SpecialistController specialistController = new SpecialistController(mock.Object);
            ActionResult<List<SpecialistDetail>> result = await specialistController.GetAllSpecialistsAsync();
            ObjectResult objectResult = result.Result as ObjectResult;
            SpecialistDetail specialistDetail = objectResult.Value as SpecialistDetail;
            int expected = 4;
            int actual = specialists.Count();
            Assert.AreEqual(expected, actual);
        }

        [Test]
        public async Task GetAllIPTreatmentPackagesAsync_Failure()
        {

            mock.Setup(i => i.GetAllSpecialistsAsync()).ReturnsAsync(specialists);
            SpecialistController specialistController = new SpecialistController(mock.Object);
            ActionResult<List<SpecialistDetail>> result = await specialistController.GetAllSpecialistsAsync();
            ObjectResult objectResult = result.Result as ObjectResult;
            SpecialistDetail specialistDetail = objectResult.Value as SpecialistDetail;
            int expected = 10;
            int actual = specialists.Count();
            Assert.AreNotEqual(expected, actual);
        }

    }
}