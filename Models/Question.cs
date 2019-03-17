using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyQuiz.Models
{
    public class Question
    {   
        
        public int QuestionId { get; set; }
        public string QuestionText { get; set; }
        public int AnswerId { get; set; }


        public virtual List<AnswerChoice> AnswerChoices { get; set; }
        public virtual Answer Answers { get; set; }
    }
}