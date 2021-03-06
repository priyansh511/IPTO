using InsuranceClaimRepository.Models;
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
    public class InitiateClaimController : Controller
    {
        static HttpClient svc = new HttpClient();
        static string baseUrl = "http://localhost:9000/InsuranceClaim/InitiateClaim/";
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

            InitiateClaim[] initiateClaims = await svc.GetFromJsonAsync<InitiateClaim[]>(baseUrl);
            return View(initiateClaims);
        }

        public async Task<ActionResult> Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(InitiateClaim initiateClaim)
        {
            await svc.PostAsJsonAsync(baseUrl, initiateClaim);
            return RedirectToAction(nameof(Index));
        }

        
    }
}
