using InsuranceClaimRepository.Models;
using InsuranceClaimRepository.Repos;
using NuGet;
using NUnit.Framework;
using System;
using System.Linq;
using System.Threading.Tasks;



namespace InsuranceClaimTests
{
    public class InsuranceReposUnitTest
    {
        private InitiateClaimRepo initiateClaimRepo = new InitiateClaimRepo();
        private InsurerDetailRepo insurerDetailRepo = new InsurerDetailRepo();



        [SetUp]
        public void Setup()
        {
        }



        [Test]
        public async Task GetAllInsurerDetailsSuccess()
        {
            var expected = 6;
            var Details = await insurerDetailRepo.GetAllInsurerDetailsAsync();
            var actual = Details.Count();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public async Task GetAllInsurerDetailsFailure()
        {
            var expected = 0;
            var Details = await insurerDetailRepo.GetAllInsurerDetailsAsync();
            var actual = Details.Count();
            Assert.AreNotEqual(expected, actual);
        }

        [Test]
        public async Task GetInsurerByPackageNameAsyncSuccess()
        {
            var res = await insurerDetailRepo.GetInsurerByPackageNameAsync("ICICI Health");
            Assert.AreEqual("ICICI Prudential", res.InsurerName);
        }
        /*
        [Test]
        public async Task GetInsurerByPackageNameAsyncFailure()
        {
            var res = await insurerDetailRepo.GetInsurerByPackageNameAsync("ICICI Health plan");
            Assert.Throws<Exception>();
        }
        */




    }
}