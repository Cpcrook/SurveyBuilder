using System.Collections.Generic;

namespace CrookSurveyBuilder.Repository.Models
{
    public class MultipleChoiceQuestion : SurveyQuestion
    {
        public virtual Dictionary<string, object> Options { get; set; }
    }
}