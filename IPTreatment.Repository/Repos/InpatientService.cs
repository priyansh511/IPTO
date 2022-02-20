using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IPTreatment.Repository.Models;
using Microsoft.EntityFrameworkCore;

namespace IPTreatment.Repository.Repos
{
    public class InpatientService : IInpatientService
    {
        private readonly log4net.ILog _log = log4net.LogManager.GetLogger(typeof(InpatientService));
        private readonly IPTreatmentContext _context;
        IPTreatmentContext dc;
        public InpatientService()
        {
            dc = new IPTreatmentContext();
        }

        public async Task<TreatmentPlan> FormulateTreatmentTimetable(PatientDetail patientDetail)
        {
            if (CheckIfPatientAlreadyRegistered(patientDetail.Name).Result)
            {
                _log.Info("Patient is already registered ");
                throw new Exception("Patient is Alreagy Registered for treatment");
            }
            else
            {

                //await dc.PatientDetail.AddAsync(patientDetail);
                //await dc.SaveChangesAsync();
                TreatmentPlan treatmentPlan = new TreatmentPlan();
                treatmentPlan.PackageName = patientDetail.TreatmentPackageName;
                treatmentPlan.PatientId = patientDetail.PatientId;
                
                IPTreatmentPackage details = await GetPackageByName(patientDetail.Ailment, patientDetail.TreatmentPackageName);
                treatmentPlan.Cost = details.PackageDetail.Cost;
                treatmentPlan.TestDetails = details.PackageDetail.TestDetails;
                treatmentPlan.TreatmentCommencementDate = patientDetail.TreatmentCommencementDate;
                treatmentPlan.TreatmentEndDate =
                    CalculateEndDate(patientDetail.TreatmentCommencementDate, details.PackageDetail.TreatmentDuration);
                SpecialistDetail specialist = await SetSpecialist(patientDetail.TreatmentPackageName, patientDetail.Ailment.ToString());
                //treatmentPlan.PatientDetail = patientDetail;
                treatmentPlan.SpecialistId = specialist.SpecialistId;
                PatientDetail patient = await dc.PatientDetail.FindAsync(patientDetail.PatientId);
                patient.TreatmentStatus = "In-Progress";

                await dc.TreatmentPlan.AddAsync(treatmentPlan);
                await dc.SaveChangesAsync();
                _log.Info("Treatment plan is formulated ");
                return treatmentPlan;

            }

        }

        private async Task<SpecialistDetail> SetSpecialist(string treatmentPackageName, string ailment)
        {
            SpecialistDetail specialist = new SpecialistDetail();
            List<SpecialistDetail> specialistDetails = await (from f in dc.SpecialistDetail where f.AreaOfExpertise == ailment select f).ToListAsync();
            if(treatmentPackageName == "Package 1")
            {
                
                specialist.ExperienceInYears = Int32.MaxValue;
                foreach (SpecialistDetail item in specialistDetails)
                {
                    if(item.ExperienceInYears < specialist.ExperienceInYears)
                    {
                        specialist = item;
                    }
                }
            }
            else
            {
                specialist.ExperienceInYears = Int32.MinValue;
                foreach (SpecialistDetail item in specialistDetails)
                {
                    if (item.ExperienceInYears > specialist.ExperienceInYears)
                    {
                        specialist = item;
                    }
                }
            }
            _log.Info("Specialist has been assigned");
            return specialist;
        }

        private DateTime CalculateEndDate(DateTime treatmentCommencementDate, int treatmentDuration)
        {
            _log.Info("End date has been calculated");
            return treatmentCommencementDate.AddDays(treatmentDuration);
        }

        private async Task<IPTreatmentPackage> GetPackageByName(Ailment ailment, string treatmentPackageName)
        {
            try
            {
                List<PackageDetail> packages = await (from f in dc.PackageDetail where f.TreatmentPackageName == treatmentPackageName select f).ToListAsync();
                List<IPTreatmentPackage> iPTreatmentPackages = await dc.IPTreatmentPackages.Where(f => f.Ailment == ailment).ToListAsync();
                IPTreatmentPackage iPTreatmentPackage=new IPTreatmentPackage();
                foreach (IPTreatmentPackage iP in iPTreatmentPackages)
                {
                    foreach (PackageDetail pd in packages)
                    {
                        if(iP.PackageId == pd.PackageId)
                        {
                            iPTreatmentPackage = iP;
                        }
                    }
                }
                _log.Info("Package received by name");
                return iPTreatmentPackage;
            }
            catch (Exception)
            {
                _log.Info("Package name not found");
                throw new Exception("No such package name");
            }
            
            //}
            //catch (exception)
            //{
            //    throw new exception("no such package name");
            //}
        }

        private async Task<bool> CheckIfPatientAlreadyRegistered(string name)
        {
            try
            {
                 TreatmentPlan treatment = await(from f in dc.TreatmentPlan where f.PatientDetail.Name == name select f).FirstAsync();
                _log.Info("Patient already registered");
                return true;
            }
            catch (Exception)
            {
                _log.Info("Patient is not registered");
                return false;
            }
        }

        public async Task<TreatmentPlan> GetTreatmentPlanByPatientIdAsync(int id)
        {
            TreatmentPlan treatmentPlan = await dc.TreatmentPlan.Where(tp => tp.PatientId == id).Include(p=> p.PatientDetail).Include(p => p.SpecialistDetail).FirstAsync();
            _log.Info("Treatment plan by patient id is obtained");
            return treatmentPlan;
        }

        public async Task<List<TreatmentPlan>> GetTreatmentPlans()
        {
            return await dc.TreatmentPlan.ToListAsync();
        }
    }
}
