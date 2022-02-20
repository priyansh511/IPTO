
using InsuranceClaimRepository.Models;
using InsuranceClaimRepository.Repos;
using IPTreatment.Repository.Repos;
using IPTreatment.Repository.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IPT.MVC.Helpers
{
    public class RepoHelper
    {
        public static List<SelectListItem> GetAllAilments()
        {
            List<SelectListItem> ailments = new List<SelectListItem>();
            
            ailments.Add(new SelectListItem { Text = "Orthopaedics", Value = InsuranceClaimRepository.Models.Ailment.ORTHOPAEDICS.ToString() });
            ailments.Add(new SelectListItem { Text = "Urology", Value = InsuranceClaimRepository.Models.Ailment.UROLOGY.ToString() });

            return ailments;
        }

        public static List<SelectListItem> GetAllTreatmentPackages()
        {
            List<SelectListItem> treatmentPackages = new List<SelectListItem>();

            treatmentPackages.Add(new SelectListItem { Text = "Package 1 : Junior Specialist", Value = "Package 1" });
            treatmentPackages.Add(new SelectListItem { Text = "Package 2 : Senior Specialist", Value = "Package 2" });

            return treatmentPackages;
        }

        
        public async static Task<List<SelectListItem>> GetAllInsurers()
        {
            List<SelectListItem> insurerList = new List<SelectListItem>();
            InsurerDetailRepo insurerRepo = new InsurerDetailRepo();
            List<InsurerDetail> insurers = await insurerRepo.GetAllInsurerDetailsAsync();
            foreach (InsurerDetail i in insurers)
            {
                insurerList.Add(new SelectListItem { Text = i.InsurerId +" - "+ i.InsurerName + " - " + i.InsurerPackageName, Value = i.InsurerId.ToString() });
            }
            return insurerList;
        }

        public async static Task<List<SelectListItem>> GetAllTreatmentPlans()
        {
            List<SelectListItem> treatmentPlanList = new List<SelectListItem>();
            InpatientService inpatientRepo = new InpatientService();
            List<IPTreatment.Repository.Models.TreatmentPlan> treatmentPlans = await inpatientRepo.GetTreatmentPlans();
            foreach (IPTreatment.Repository.Models.TreatmentPlan t in treatmentPlans)
            {
                treatmentPlanList.Add(new SelectListItem { Text = t.TreatmentPlanId + " - " + t.PackageName, Value = t.TreatmentPlanId.ToString() });
            }
            return treatmentPlanList;
        }

        public async static Task<List<SelectListItem>> GetAllPatients()
        {
            List<SelectListItem> patientList = new List<SelectListItem>();
            PatientService patientRepo = new PatientService();
            List<IPTreatment.Repository.Models.PatientDetail> patients = await patientRepo.GetAllPatientDetails();
            foreach (IPTreatment.Repository.Models.PatientDetail p in patients)
            {
                patientList.Add(new SelectListItem { Text = p.PatientId + " - " + p.Name, Value = p.PatientId.ToString() });
            }
            return patientList;
        }


    }
}
