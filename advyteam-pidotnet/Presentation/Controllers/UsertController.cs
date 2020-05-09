using Presentation.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Web.Mvc;


namespace Presentation.Controllers
{
    public class UsertController : Controller
    {
        // GET: Usert
        public ActionResult Index()
        {

            HttpClient Client = new System.Net.Http.HttpClient();
            //Client.BaseAddress = new Uri("http://localhost:9080");
            Client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            HttpResponseMessage response = Client.GetAsync("http://localhost:9080/pidev-web/api/users").Result;
            if (response.IsSuccessStatusCode)

            {
                ViewBag.result = response.Content.ReadAsAsync<IEnumerable<Usert>>().Result;


            }
            else
            {
                ViewBag.result = "error";
            }

            return View();
        }

        // GET: Usert/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Usert/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Usert/Create
        [HttpPost]
        public ActionResult Create(Usert us)
        {
            

                HttpClient Client = new HttpClient();
                HttpResponseMessage response = Client.PostAsJsonAsync<Usert>(" http://localhost:9080/pidev-web/api/users/addUser", us).ContinueWith((postTask) => postTask.Result.EnsureSuccessStatusCode()).Result;
                if (response.IsSuccessStatusCode)
                {
                    return RedirectToAction("Index");
                }
            
            
            {
                return View();
            }
        }
        // GET: Usert/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Usert/Edit/5
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

        // GET: Usert/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Usert/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
