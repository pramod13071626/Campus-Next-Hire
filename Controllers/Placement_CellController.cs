using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using CampusCraft.Models;

namespace CampusCraft.Controllers
{
    public class Placement_CellController : Controller
    {
        CC cmpobj = new CC();
        adminModel adm = new adminModel();

        // GET: placement_cell
        public ActionResult placement_cell()
        {
            return View();
        }

        // GET: comp_list
        public ActionResult comp_list()
        {
            ViewBag.Companies = cmpobj.companies.ToList() ?? new List<CampusCraft.Models.company>();
            ViewBag.Admins = adm.admins.ToList() ?? new List<CampusCraft.Models.admin>();
            return View();
        }

        // GET: Placement_Cell/Add
        public ActionResult Add()
        {
            return View();
        }

        // POST: Placement_Cell/Add
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(company model)
        {
            if (ModelState.IsValid)
            {
                cmpobj.companies.Add(model);
                cmpobj.SaveChanges();
                return RedirectToAction("comp_list");
            }
            return View(model);
        }

        // GET: Placement_Cell/Edit/5
        public ActionResult Edit(int id)
        {
            var company = cmpobj.companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Placement_Cell/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(company model)
        {
            if (ModelState.IsValid)
            {
                cmpobj.Entry(model).State = System.Data.Entity.EntityState.Modified;
                cmpobj.SaveChanges();
                return RedirectToAction("comp_list");
            }
            return View(model);
        }

        // GET: Placement_Cell/Delete/5
        public ActionResult Delete(int id)
        {
            var company = cmpobj.companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }
            return View(company);
        }

        // POST: Placement_Cell/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var company = cmpobj.companies.Find(id);
            cmpobj.companies.Remove(company);
            cmpobj.SaveChanges();
            return RedirectToAction("comp_list");
        }

        // GET: Placement_Cell/Apply/5
        public ActionResult Apply(int id)
        {
            var company = cmpobj.companies.Find(id);
            if (company == null)
            {
                return HttpNotFound();
            }

            var student = cmpobj.students.FirstOrDefault(s => s.email == User.Identity.Name);
            if (student == null)
            {
                return HttpNotFound();
            }

            var model = new ApplyViewModel
            {
                CompanyID = company.compID,
                CompanyName = company.cmpname,
                StudentID = student.stdID,
                Name = student.name,
                Email = student.email,
                Course = student.course,
                Year = student.year,
                Mobile = student.mobile,
                Resume = student.add_resume
            };

            return View("ApplyForm", model);
        }

        // POST: Placement_Cell/Apply
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ApplyForm(ApplyViewModel model)
        {
            if (ModelState.IsValid)
            {
                var application = new appliedstudentlist
                {
                    studentinfo = model.StudentID,
                    companyinfo = model.CompanyID
                };

                cmpobj.appliedstudentlists.Add(application);
                cmpobj.SaveChanges();

                TempData["Success"] = "Application submitted successfully!";
                return RedirectToAction("comp_list");
            }

            return View(model);
        }
        public ActionResult appliedStudentList()
        {
            return View();
        }

        }



    }

