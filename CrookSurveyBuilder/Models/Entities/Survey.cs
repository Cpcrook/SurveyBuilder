using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CrookSurveyBuilder.Models;
using CrookSurveyBuilder.Models.Entities;

namespace CrookSurveyBuilder.DAL.Entities
{
    public class Survey
    {
        public int SurveyId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string CompletionMessage { get; set; }

        public virtual string UserId { get; set; }
        public virtual IList<SurveyQuestion> Questions { get; set; }
        public virtual IList<SurveyResponse> Responses { get; set; } 
    }
}
