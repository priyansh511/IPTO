
using IPTreatment.Repository.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace IPT.MVC.Controllers
{
    [Authorize]
    public class PatientController : Controller
    {
        static HttpClient svc = new HttpClient();
        static string baseUrl = "http://localhost:9000/IPTreatment/Patient/";
        static string url = "http://localhost:9000/IPTreatment/InpatientService/";
        static async Task GetToken(string userName, string role, string key)
        {
            string token = await svc.GetStringAsync("http://localhost:9000/AuthService/Auth?userName=" + userName + "&role=" + role + "&key=" + key);
            svc.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
        }
        public async Task<ActionResult> Index()
        {
            string userName = User.Identity.Name;
            string role = null;
            if (User.IsInRole("Administrators"))
                role = "Administrators";
            if (User.IsInRole("Customers"))
                role = "Customers";
            string key = "My name is James Bond";
            await GetToken(userName, role, key);
            PatientDetail[] patientDetails = await svc.GetFromJsonAsync<PatientDetail[]>(baseUrl);
            return View(patientDetails);
        }
        public async Task<ActionResult> MarkAsCompleted(int id)
        { 
            PatientDetail patient = await svc.GetFromJsonAsync<PatientDetail>(baseUrl + id);
            return View(patient);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> MarkAsCompleted(int id, PatientDetail patientDetail)
        {
            try
            {
                await svc.PutAsJsonAsync(baseUrl + id, patientDetail);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
     

        public async Task<ActionResult> Create()
        {
             return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(PatientDetail patientDetail)
        {
            await svc.PostAsJsonAsync(baseUrl, patientDetail);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<ActionResult> FormulateTimetable(int id)
        {
            PatientDetail patientDetail = await svc.GetFromJsonAsync<PatientDetail>(baseUrl + id);
            return View(patientDetail);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> FormulateTimetable(int id, PatientDetail patientDetail)
        {
            patientDetail = await svc.GetFromJsonAsync<PatientDetail>(baseUrl + id);
            try
            {
                await svc.PostAsJsonAsync(url, patientDetail);

                TempData["PatientId"] = patientDetail.PatientId;
                return RedirectToAction(nameof(Details));

            }
            catch
            {
                return View();
            }
        }

        [HttpGet]
        public async Task<ActionResult<TreatmentPlan>> Details(int id)
        {
            id = (int)TempData["PatientId"];
            TempData.Keep("PatientId");

            TreatmentPlan treatmentPlan = await svc.GetFromJsonAsync<TreatmentPlan>(url + id);
            return View(treatmentPlan);
        }
        [HttpGet]
        public async Task<ActionResult<TreatmentPlan>> ViewTimeTable(int id)
        {
            TreatmentPlan treatmentPlan = await svc.GetFromJsonAsync<TreatmentPlan>(url + id);
            return View(treatmentPlan);
        }

    }
}
