using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using MyQuiz.Abstract;
using MyQuiz.Models;

namespace MyQuiz.DAL
{
    public class QuizManager : IQuizManager
    {
        private static QuizManager instance;
        public QuizContext db = new QuizContext();
        int questionId = 1;
        public bool IsComplete = false;
        public Quiz quiz;
      //  private Quiz QuizId;

      
        private QuizManager()
        {
            quiz = new Quiz();
          //  quiz.QuizId = QuizManager.instances.quiz;
            quiz.StartTime = DateTime.Now;
           // quiz.QuizId = 1;
            //quiz.Score = 1;
        }

        public static QuizManager instances
        {
            get 
            {
                if (instance == null)
                {
                    instance = new QuizManager();
                }
                return instance;
            }
            
        }

        public Question LoadQuiz()
        {
            var question = db.Questions.Find(questionId);
            return question;
        }



        public void SaveAnswer(string answers)
        {
            var question = db.Questions.Include("Answers").Where(x => x.QuestionId == questionId).Single();
            if (question.Answers.AnswerText == answers)
            {
                quiz.Score++;
            }
        }

        public bool MovetoNextQuestion()
        {
            bool canMove = false;
            if (db.Questions.Count() > questionId)
            {
                questionId++;
                QuizManager.instances.savedata(quiz);
                canMove = true;
            }
            return canMove;
        }

        public bool PreviousQuestion()
        {
            bool canMove = false;

            if (questionId > 1)
            {
                questionId--;
                canMove = true;
            }
            return canMove;
        }



        public void savedata(Quiz quiz)
        {
  //              quiz.QuizId = this.quiz.QuizId;
                db.Quizs.Add(quiz); //her er den nye endringen
 //               db.Entry(quiz).State = EntityState.Modified;
                db.SaveChanges();            
        }


        public bool MoveToNextQuestion()
        {
            throw new NotImplementedException();
        }

        public bool PreviosQuestion()
        {
            throw new NotImplementedException();
        }
    }

    
}