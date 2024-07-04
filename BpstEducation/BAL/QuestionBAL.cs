using BpstEducation.Models;
using BpstEducation.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BpstEducation.BAL
{
    public class QuestionBAL
    {
        public void GetQuestionWithFieldObjects(Question q)
        {
            q.AnswerVMs = JsonConvert.DeserializeObject<AnswerViewModel>(q.AnswerObjectJson);
        }

        public void GetQuestionWithFieldObjects(List<Question> questions)
        {
            foreach (var q in questions)
                GetQuestionWithFieldObjects(q);
        }
    }
}
