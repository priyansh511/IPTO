using IPTreatment.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPTreatment.Repository.Repos
{
    public interface IPatientService
    {
        Task<List<PatientDetail>> GetAllPatientDetails();
        Task InsertPatient(PatientDetail patient);

        Task MarkAsCompleted(PatientDetail patientDetail);
        Task<PatientDetail> GetPatientByPatientIdAsync(int id);

     }
}
