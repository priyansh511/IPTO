using IPTOffering.Repository.Models;
using IPTOffering.Repository.Repos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPTOTests
{
    public class IPTORepoTest
    {
        private IPTreatmentPackageRepository iPTPackageRepo = new IPTreatmentPackageRepository();
        private SpecialistRepository specialistRepository = new SpecialistRepository();



        [SetUp]
        public void Setup()
        {
        }



        [Test]
        public async Task GetAllIPTreatmentPackages_Success()
        {
            var expected = 4;
            var Details = await iPTPackageRepo.GetAllIPTreatmentPackagesAsync();
            var actual = Details.Count();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public async Task GetAllIPTreatmentPackages_Failure()
        {
            var expected = 0;
            var Details = await iPTPackageRepo.GetAllIPTreatmentPackagesAsync();
            var actual = Details.Count();
            Assert.AreNotEqual(expected, actual);
        }

        [Test]
        public async Task GetTreatmentPackageByNameAsync_Success()
        {
            List<IPTreatmentPackage> res = await iPTPackageRepo.GetTreatmentPackageByNameAsync("Package 1");
            foreach (IPTreatmentPackage ip in res)
            {
                Assert.AreEqual("Package 1", ip.PackageDetail.TreatmentPackageName);
            }
        }

        [Test]
        public async Task GetAllSpecialists_Success()
        {
            var expected = 4;
            var Details = await specialistRepository.GetAllSpecialistsAsync();
            var actual = Details.Count();
            Assert.AreEqual(expected, actual);
        }
        [Test]
        public async Task GetAllSpecialists_Failure()
        {
            var expected = 0;
            var Details = await specialistRepository.GetAllSpecialistsAsync();
            var actual = Details.Count();
            Assert.AreNotEqual(expected, actual);
        }

    }
}
