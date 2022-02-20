using IPTreatment.Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPTreatment.Repository.Repos
{
    public interface IInpatientService
    {
        Task<TreatmentPlan> FormulateTreatmentTimetable(PatientDetail patientDetail);

        Task<TreatmentPlan> GetTreatmentPlanByPatientIdAsync(int id);

        Task<List<TreatmentPlan>> GetTreatmentPlans();
    }
}
