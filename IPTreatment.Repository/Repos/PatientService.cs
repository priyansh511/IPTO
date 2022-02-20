using IPTreatment.Repository.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IPTreatment.Repository.Repos
{
    public class PatientService : IPatientService
    {
        private readonly log4net.ILog _log = log4net.LogManager.GetLogger(typeof(PatientService));

        IPTreatmentContext dc;
        public PatientService()
        {
            dc = new IPTreatmentContext();
        }
        //public PatientService(IPTreatmentContext dc)
        //{
        //    this.dc = dc;
        //}
        public async Task<List<PatientDetail>> GetAllPatientDetails()
        {
            _log.Info("Patient Details obtained");
            return await dc.PatientDetail.ToListAsync();
        }

        public async Task InsertPatient(PatientDetail patient)
        {
            
            try
            {
                patient.TreatmentStatus = "Not started";
                await dc.PatientDetail.AddAsync(patient);
                _log.Info("Patient details inserted");
                await dc.SaveChangesAsync();

            }
            catch(Exception ex)
            {
                _log.Info("Patient details not inserted ");
                throw new Exception(ex.Message);
            }
        }

        public async Task MarkAsCompleted(PatientDetail patientDetail)
        {
            PatientDetail patientInDb = await dc.PatientDetail.FindAsync(patientDetail.PatientId);
            patientInDb.TreatmentStatus = "Completed";
            _log.Info("Patient Treatment completed");
            await dc.SaveChangesAsync();
        }

        public async Task<PatientDetail> GetPatientByPatientIdAsync(int id)
        {
            PatientDetail patientDetail = await dc.PatientDetail.FindAsync(id);
            _log.Info("Patient details obtained by patient id");
            return patientDetail;
        }
    }
}
