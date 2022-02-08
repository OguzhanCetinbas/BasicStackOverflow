using Raklet.Models.EntityDataModel;
using Raklet.Models.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Raklet.Controllers
{
    public class StackOverflowController : Controller
    {
        StackOverflowEntities db = new StackOverflowEntities();

        public ActionResult Index() {

            return View(db.SUBJECT.ToList());
        }
        public ActionResult Create() {


            return View();

        }
        [HttpPost]
        public ActionResult Create(string problem) {

            SUBJECT s = new SUBJECT();
            s.PROBLEM = problem;
            db.SUBJECT.Add(s);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult Details(int id) {
            List<SOLUTION> value = db.SOLUTION.Where(x => x.SUBID == id).ToList();
            return View(value.ToList());
        }
        public ActionResult Search(string q)
        {
            var value = from d in db.SUBJECT select d;
            if (!string.IsNullOrEmpty("q")) {
                value = value.Where(x => x.PROBLEM.Contains(q));
            }
            return View(value.ToList());
        }

        //[HttpPost]

        //public ActionResult CreateDetail(SOLUTION solution)
        //{
        //    db.SOLUTION.Add(solution);
        //    db.SaveChanges();
        //    return RedirectToAction("Details");


        //    return View();

        //}
    }
    }