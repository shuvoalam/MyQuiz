using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MyQuiz.Models
{
    public class Answer
    {
        [Key]
        public int AnswersId { get; set; }
        public string AnswerText { get; set; }
        public virtual List<Question> Questions { get; set; }
    }
}