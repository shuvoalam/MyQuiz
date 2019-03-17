using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MyQuiz.Models;
using MyQuiz.DAL;
using MyQuiz.Abstract;

namespace MyQuiz.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            var question = QuizManager.instances.LoadQuiz();   
            return View(question);
        }

        [HttpPost]
        public ActionResult Index(string answer, int questionId, Quiz quiz)
        {
            if (QuizManager.instances.IsComplete)
                
                return RedirectToAction("ShowResults");

                QuizManager.instances.SaveAnswer(answer);
            if (QuizManager.instances.MovetoNextQuestion()){
                var question = QuizManager.instances.LoadQuiz();
                    return View(question);
            }
           // QuizManager.instances.savedata(quiz);
            QuizManager.instances.IsComplete = true;
            return RedirectToAction("ShowResults");
        }

        public ActionResult ShowResults()
        {
            return View(QuizManager.instances.quiz);
        }

        public ActionResult ShowAnswers()
        {
            return View(QuizManager.instances);
        }
    }
}