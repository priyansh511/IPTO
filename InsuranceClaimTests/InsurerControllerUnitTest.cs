using InsuranceClaimRepository.Models;
using InsuranceClaimRepository.Repos;
using InsuranceClaimWebApi.Controllers;
using Microsoft.AspNetCore.Mvc;
using Moq;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace InsuranceClaimTests
{
    public class InsurerControllerUnitTest
    {
        Mock<IInsurerDetailRepo> mock = new Mock<IInsurerDetailRepo>();
        List<InsurerDetail> insurerDetails = null;
        [SetUp]
        public void Setup()
        {
            insurerDetails = new List<InsurerDetail>() {
        new InsurerDetail {
          InsurerName = "LIC",
            InsurerPackageName = "LIC Jeevan Policy",
            InsuranceAmountLimit = 100000,
            DisbursementDuration = 2
        },
        new InsurerDetail() {
            InsurerName = "LIC",
              InsurerPackageName = "LIC Life Policy",
              InsuranceAmountLimit = 150000,
              DisbursementDuration = 3
          },
          new InsurerDetail() {
            InsurerName = "Bajaj Allianz",
              InsurerPackageName = "Bajaj Health",
              InsuranceAmountLimit = 200000,
              DisbursementDuration = 5
          },
          new InsurerDetail() {
            InsurerName = "LIC",
              InsurerPackageName = "LIC Health",
              InsuranceAmountLimit = 175000,
              DisbursementDuration = 4
          },
          new InsurerDetail() {
            InsurerName = "ICICI Prudential",
              InsurerPackageName = "ICICI Health",
              InsuranceAmountLimit = 250000,
              DisbursementDuration = 5
          },
          new InsurerDetail() {
            InsurerName = "HDFC Standard Life Insurance",
              InsurerPackageName = "HDFC Health Pack",
              InsuranceAmountLimit = 200000,
              DisbursementDuration = 3
          }
      };
            TestContext.Progress.WriteLine("One Time SetUp is Executed");
        }

        [Test]
        public async Task GetAllInsurerDetails_Success()
        {

            mock.Setup(i => i.GetAllInsurerDetailsAsync()).ReturnsAsync(insurerDetails);
            InsurerDetailController insurerDetailController = new InsurerDetailController(mock.Object);
            ActionResult<List<InsurerDetail>> result = await insurerDetailController.GetAllInsurerDetails();
            ObjectResult objectResult = result.Result as ObjectResult;
            InsurerDetail insurerDetail = objectResult.Value as InsurerDetail;
            int expected = 6;
            int actual = insurerDetails.Count();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public async Task GetAllInsurerDetails_Failure()
        {

            mock.Setup(i => i.GetAllInsurerDetailsAsync()).ReturnsAsync(insurerDetails);
            InsurerDetailController insurerDetailController = new InsurerDetailController(mock.Object);
            ActionResult<List<InsurerDetail>> result = await insurerDetailController.GetAllInsurerDetails();
            ObjectResult objectResult = result.Result as ObjectResult;
            InsurerDetail insurerDetail = objectResult.Value as InsurerDetail;
            int expected = 8;
            int actual = insurerDetails.Count();
            Assert.AreNotEqual(expected, actual);
        }
        [Test]
        public async Task GetInsurerByPackageName_Success()
        {
            InsurerDetailController insurerDetailCont = new InsurerDetailController(new InsurerDetailRepo());
            string packageName = "LIC Jeevan Policy";
            ActionResult<InsurerDetail> result = await insurerDetailCont.GetInsurerByPackageName(packageName);
            ObjectResult objectResult = result.Result as ObjectResult;
            string expected = "LIC";
            InsurerDetail insurerDetail = objectResult.Value as InsurerDetail;
            string actual = insurerDetail.InsurerName;
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public async Task GetInsurerByPackageName_Failure()
        {
            InsurerDetailController insurerDetailCont = new InsurerDetailController(new InsurerDetailRepo());
            string packageName = "LIC Jeevan Policy";
            ActionResult<InsurerDetail> result = await insurerDetailCont.GetInsurerByPackageName(packageName);
            ObjectResult objectResult = result.Result as ObjectResult;
            string expected = "HDFC";
            InsurerDetail insurerDetail = objectResult.Value as InsurerDetail;
            string actual = insurerDetail.InsurerName;
            Assert.AreNotEqual(expected, actual);
        }
    }
}