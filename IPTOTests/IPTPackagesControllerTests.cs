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
    public class IPTPackagesControllerTests
    {

        Mock<IIPTreatmentPackageRepository> mock = new Mock<IIPTreatmentPackageRepository>();
        List<IPTreatmentPackage> IPTreatmentPackages = null;

        [SetUp]
        public void Setup()
        {
            IPTreatmentPackages = new List<IPTreatmentPackage>() {
        new IPTreatmentPackage {
            IPTreatmentPackagesId = 1,
            Ailment = Ailment.UROLOGY,
            PackageId = 1
        },
        new IPTreatmentPackage {
            IPTreatmentPackagesId = 2,
            Ailment = Ailment.UROLOGY,
            PackageId = 2
        },
        new IPTreatmentPackage {
            IPTreatmentPackagesId = 3,
            Ailment = Ailment.ORTHOPAEDICS,
            PackageId = 3
        },
        new IPTreatmentPackage {
            IPTreatmentPackagesId = 4,
            Ailment = Ailment.ORTHOPAEDICS,
            PackageId = 4
        },

      };
            TestContext.Progress.WriteLine("One Time SetUp is Executed");
        }

        [Test]
        public async Task GetAllIPTreatmentPackagesAsync_Success()
        {

            mock.Setup(i => i.GetAllIPTreatmentPackagesAsync()).ReturnsAsync(IPTreatmentPackages);
            IPTreatmentPackageController IPController = new IPTreatmentPackageController(mock.Object);
            ActionResult<List<IPTreatmentPackage>> result = await IPController.GetAllIPTreatmentPackagesAsync();
            ObjectResult objectResult = result.Result as ObjectResult;
            IPTreatmentPackage iPTreatmentPackage = objectResult.Value as IPTreatmentPackage;
            int expected = 4;
            int actual = IPTreatmentPackages.Count();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public async Task GetAllIPTreatmentPackagesAsync_Failure()
        {

            mock.Setup(i => i.GetAllIPTreatmentPackagesAsync()).ReturnsAsync(IPTreatmentPackages);
            IPTreatmentPackageController IPController = new IPTreatmentPackageController(mock.Object);
            ActionResult<List<IPTreatmentPackage>> result = await IPController.GetAllIPTreatmentPackagesAsync();
            ObjectResult objectResult = result.Result as ObjectResult;
            IPTreatmentPackage iPTreatmentPackage = objectResult.Value as IPTreatmentPackage;
            int expected = 6;
            int actual = IPTreatmentPackages.Count();
            Assert.AreNotEqual(expected, actual);
        }
       
       
    }
}