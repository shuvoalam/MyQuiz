using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MyQuiz.DAL;
using MyQuiz.Models;

namespace MyQuiz.Controllers
{
    public class AnswerChoiceController : Controller
    {
        private QuizContext db = new QuizContext();

        // GET: AnswerChoice
        public ActionResult Index()
        {
            var answerChoice = db.AnswerChoices.Include(m => m.Question);
            return View(answerChoice.ToList());
        }


        // GET: AnswerChoice/Details/5
        public ActionResult Details(int id)
        {
            AnswerChoice answerChoice = db.AnswerChoices.Find(id);
            return View(answerChoice);
        }

       
        // GET: AnswerChoice/Create
        public ActionResult Create()
        {
            ViewBag.QuestionId = new SelectList(db.Questions, "QuestionId", "QuestionText");
            return View();
        }

        // POST: AnswerChoice/Create
        [HttpPost]
        public ActionResult Create(AnswerChoice answerChoice)
        {
            if (ModelState.IsValid)
            {
                db.AnswerChoices.Add(answerChoice);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuestionId = new SelectList(db.Questions, "QuestionId", "QuestionText");
            return View(answerChoice);
        }

        // GET: AnswerChoice/Edit/5
        public ActionResult Edit(int id)
        {
            AnswerChoice answerChoice = db.AnswerChoices.Find(id);
            ViewBag.QuestionId = new SelectList(db.Questions, "QuestionId", "QuestionText", answerChoice.QuestionId);
            return View(answerChoice);
        }

        // POST: AnswerChoice/Edit/5
        [HttpPost]
        public ActionResult Edit(AnswerChoice answerChoice)
        {
            if(ModelState.IsValid)
            {
                db.Entry(answerChoice).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.QuestionId = new SelectList(db.Questions, "QuestionId", "QuestionText", answerChoice.QuestionId);
            return View(answerChoice);
        }

        // GET: AnswerChoice/Delete/5
        public ActionResult Delete(int id)
        {
            AnswerChoice answerChoice = db.AnswerChoices.Find(id);
            return View(answerChoice);
        }

        // POST: AnswerChoice/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            AnswerChoice answerChoice = db.AnswerChoices.Find(id);
            db.AnswerChoices.Remove(answerChoice);
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
