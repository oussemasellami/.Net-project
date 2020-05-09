using Data;
using Domain.Entities;
using Presentation.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.ModelBinding;
using System.Web.Mvc;

namespace Presentation.Controllers
{
    public class utilisiteurController : Controller
    {
        // GET: utilisiteur
        JobService ir = new JobService();
        Iutilisateurser aa = new utilisateurser();
        public ActionResult Index()
        {
            var conge = aa.GetMany();
            return View(conge);
        }

        // GET: utilisiteur/Details/5
        public ActionResult Details(int id)
        {
            List<job> jobuser = new List<job>() ;
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            List<job> jobs = new List<job>();
            jobs = ir.GetMany().ToList();
            foreach ( var item in jobs )
            {
                //IEnumerable<job> job = ir.GetProductsByCategory(cin);
                if (item.utlisateur.cin == id)
                {
                    jobuser.Add(item);
                }
            }
            
            return View(jobuser);
        }

       

        // GET: utilisiteur/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: utilisiteur/Create
        [HttpPost]
        public ActionResult Create(utlisateurmodel pm)
        {
            try
            {
                // TODO: Add insert logic here
                utlisateur p = new utlisateur();


                p.cin = p.cin;
                p.Name = p.Name;
                



                //2eme etape
                //prods.Add(p);
                //3eme etape
                //Session["Products"] = prods;
                aa.Add(p);
                aa.Commit();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: utilisiteur/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: utilisiteur/Edit/5
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

        // GET: utilisiteur/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: utilisiteur/Delete/5
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


        //public ActionResult JobsofUser()
        //{

        //    //{
        //    //    if (id == null)
        //    //    {
        //    //        return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        //    //    }

        //    //    List<utlisateur> utlisateur = new List<utlisateur>();
        //    //    utlisateur = aa.GetMany().ToList();
        //    //    //job job = ir.GetJobByClient(id);
        //    //    foreach (var item in utlisateur)
        //    //    {
        //    //        IEnumerable<job> NombreProjetsEncours = ir.GetJobByClient(id);

        //    //    }
                
        //    //    return View();
        //    //}

        //}

    }
}
