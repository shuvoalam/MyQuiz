using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MyQuiz.Models
{
    public class AnswerChoice
    {
        public int AnswerChoiceId { get; set; }
        public string Choice { get; set; }
        public int QuestionId { get; set; }

        public Question Question { get; set; }
    }
}