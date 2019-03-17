using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyQuiz.Models;

namespace MyQuiz.Abstract
{
    interface IQuizManager
    {
        Question LoadQuiz();
        void SaveAnswer(string answers);
        bool MoveToNextQuestion();
        bool PreviosQuestion();
    }
}
