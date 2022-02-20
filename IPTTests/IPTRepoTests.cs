using IPTreatment.Repository.Repos;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPTTests
{
    class IPTRepoTests
    {

    
        public class InsuranceReposUnitTest
        {
            private InpatientService inpatientService = new InpatientService();
            private PatientService patientService = new PatientService();



            [SetUp]
            public void Setup()
            {
            }
            [Test]
            public async Task GetAllPatientDetails_Success()
            {
                var expected = 10;
                var Details = await patientService.GetAllPatientDetails();
                var actual = Details.Count();
                Assert.LessOrEqual(actual, expected);
            }

            [Test]
            public async Task GetPatientByPatientId_Success()
            {
                var res = await patientService.GetPatientByPatientIdAsync(1);
                Assert.AreEqual("Raj", res.Name);
            }
        }
    }

}
