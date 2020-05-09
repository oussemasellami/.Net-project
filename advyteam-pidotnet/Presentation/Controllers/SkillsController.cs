using Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class SkillsController : Controller
    {
        // GET: Skills
        public ActionResult Index()
        {
            HttpClient Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:9080");
            Client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage reponse = Client.GetAsync("http://localhost:9080/timesheet-web/api/skills").Result;
            if (reponse.IsSuccessStatusCode)
            {
                ViewBag.result = reponse.Content.ReadAsAsync<IEnumerable<skills>>().Result;


            }
            else
            {
                ViewBag.result = "error";
            }


            return View();
        }

        // GET: Skills/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Skills/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Skills/Create
        [HttpPost]
        public ActionResult Create(skills evn)
        {

            HttpClient Client = new HttpClient();
            HttpResponseMessage response = Client.PostAsJsonAsync<skills>("http://localhost:9080/timesheet-web/api/skills/addskill", evn).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode()).Result;
            if (response.IsSuccessStatusCode)
            {
                

                return RedirectToAction("Index");
            }
        
            {
                return View();
            }
        }

        // GET: Skills/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Skills/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Skills/Delete/5
        public ActionResult Delete(int id)
        {
            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:9080/timesheet-web/");
            client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = client.GetAsync("api/skills" + id).Result;
            skills project = new skills();
            if (response.IsSuccessStatusCode)

            {

                ViewBag.result = response.Content.ReadAsAsync<skills>().Result;

            }
            else
            {
                ViewBag.result = "erreur";
            }



            return View();
        }

        // POST: Skills/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                HttpClient client = new HttpClient();
                client.BaseAddress = new Uri("http://localhost:9080/timeseet-web/");

                // TODO: Add insert logic here
                client.DeleteAsync("api/skills" + id)
                        .ContinueWith((postTask) => postTask.Result.IsSuccessStatusCode);

                return RedirectToAction("Index");

                
            }
            catch
            {
                return View();
            }
        }
    }
}
