using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MyQuiz.Models;
using System.Data.Entity;

namespace MyQuiz.DAL
{
    public class QuizContext : DbContext

    {
        public DbSet<Quiz> Quizs { get; set; }

        public DbSet<Question> Questions { get; set; }

        public DbSet<AnswerChoice> AnswerChoices { get; set; }

        public DbSet<Answer> Answers { get; set; }
    }
}