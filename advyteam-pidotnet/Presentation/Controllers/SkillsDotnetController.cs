using Presentation.Models;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Domain.Entities;
using Data;

namespace Presentation.Controllers
{
    public class SkillsDotnetController : Controller
    {
        ISkillsService skills = new SkillsService();
        // GET: SkillsDotnet
        public ActionResult Index()
        {
            var conge = skills.GetMany();
            return View(conge);
        }

        // GET: SkillsDotnet/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: SkillsDotnet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SkillsDotnet/Create
        [HttpPost]
        public ActionResult Create(SkillsModels ski )
        {
            try
            {
                // TODO: Add insert logic here
               skills p = new skills();
                p.skillsname = ski.skillsname;
                p.descreption = ski.descreption;
                p.note = ski.note;



                skills.Add(p);
                skills.Commit();


                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }

        }

        // GET: SkillsDotnet/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: SkillsDotnet/Edit/5
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

        // GET: SkillsDotnet/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: SkillsDotnet/Delete/5
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
