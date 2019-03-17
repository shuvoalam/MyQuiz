using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyQuiz.Models;
using MyQuiz.DAL;
using System.Data.Entity;

namespace MyQuiz.Controllers
{
    public class AnswerController : Controller
    {

        private QuizContext db = new QuizContext();

        // GET: Answer
        public ActionResult Index()
        {
            return View(db.Answers.ToList());
        }

        // GET: Answer/Details/5
        public ActionResult Details(int? id)
        {
            Answer answer = db.Answers.Find(id);
            return View(answer);
        }

        // GET: Answer/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Answer/Create
        [HttpPost]
        public ActionResult Create(Answer answer)
        {
            if (ModelState.IsValid)
                {
                    db.Answers.Add(answer);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(answer);
        }

        // GET: Answer/Edit/5
        public ActionResult Edit(int id)
        {
            Answer answer = db.Answers.Find(id);
            return View(answer);
        }

        // POST: Answer/Edit/5
        [HttpPost]
        public ActionResult Edit(Answer answer)
        {
           if(ModelState.IsValid)
            {
                db.Entry(answer).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
           return View(answer);
        }

        // GET: Answer/Delete/5
        public ActionResult Delete(int id)
        {
            Answer answer = db.Answers.Find(id);
            return View(answer);
        }

        // POST: Answer/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            Answer answer = db.Answers.Find(id);
            db.Answers.Remove(answer);
            db.SaveChanges();
            return RedirectToAction("Index");
       }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
