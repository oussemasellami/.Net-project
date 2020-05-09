using Data;
using Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Linq.Expressions;
using System.Net;
using Presentation.Models;
using System.Web.UI.WebControls;
using System.IO;
using System.Web.UI;

namespace Presentation.Controllers
{
    public class JobController : Controller
    {
        IJob ir = new JobService();
        Iutilisateurser aa = new utilisateurser();
        ISkillsService skills = new SkillsService();

        // GET: Job
        public ActionResult Index()
        {
            List<skills> ski = skills.GetMany().ToList();
            List<job> jobs = ir.GetMany().ToList();
            foreach (var item in jobs)
            {

                foreach (var item1 in ski)
                {
                    if (item.idskill == item1.idskill)
                    {
                        item.skills.skillsname = item1.skillsname;
                    }
                }

            }


                return View(jobs);
        }


        [HttpPost]
        public ActionResult setJobDetail(String competencedef, String department, String description, int level , String nom, int user_id)
        {
            job e = new job();
            e.competencedef = competencedef;
            e.description = description;
            e.department = department;
            e.nom = nom;
            e.level = level;
            //  e.Condidat = 1;

            return View(e);
        }



        // GET: Job/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            job job = ir.GetById(id);
            if (job == null)
            {
                return HttpNotFound();
            }
            return View(job);
        }

        // GET: Job/Create
        public ActionResult Create()
        {
            var cat = aa.GetMany();
            var cat2 = skills.GetMany();
            JobModel pm = new JobModel();
            pm.utilisateurs = cat.Select(p => new SelectListItem
            {
                Text = p.Name,
                Value = p.cin.ToString()
            });
            pm.listSkills = cat2.Select(p => new SelectListItem
            {
                Text = p.skillsname,
                Value = p.idskill.ToString()
            });
            return View(pm);
        }

        // POST: Job/Create
        [HttpPost]
        public ActionResult Create(JobModel pm)
        {
            try
            {
                // TODO: Add insert logic here
                job p = new job();
                p.nom = pm.nom;
                p.description = pm.description;
                p.department = pm.department;
                p.competencedef = pm.competencedef;
                p.cin = pm.cin;
                p.idskill = pm.idskill;

                ir.Add(p);
                ir.Commit();
                
                
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }


        }

        // GET: Job/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Job/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, job r)
        {
            if (ModelState.IsValid)
            {
                if (id == null)
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                job recFromDB = ir.GetById(id);
                r.competencedef = recFromDB.competencedef;
                r.description = recFromDB.description;
                r.department = recFromDB.department;
                r.nom = recFromDB.nom;
                r.level = recFromDB.level;
                ir.Update(r);
                ir.Commit();


            }
            return RedirectToAction("Index");
        }

        // GET: Job/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Job/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            job r;
            r = ir.GetById(id);

            ir.Delete(r);
            ir.Commit();
            // es.Dispose();

            return RedirectToAction("Index");
        }


        [HttpPost]
        public JsonResult GetStat()
        {


            var dt = ir.GetMany().GroupBy(a => a.department)
                        .Select(g => new { g.Key, Count = g.Count() });
            return new JsonResult { Data = dt };


        }

        public ActionResult ExportData()
        {
            var datasource = ir.GetMany().ToList();

            GridView gv = new GridView();
            gv.DataSource = datasource;
            gv.DataBind();
            Response.ClearContent();
            Response.Buffer = true;
            Response.AddHeader("content-disposition", "attachment; filename=Report.xls");
            Response.ContentType = "application/ms-excel";
            Response.Charset = "";
            StringWriter sw = new StringWriter();
            HtmlTextWriter htw = new HtmlTextWriter(sw);
            gv.RenderControl(htw);
            Response.Output.Write(sw.ToString());
            Response.Flush();
            Response.End();

            return Json("Success");
        }

    }
}
