using System;

namespace CrookSurveyBuilder.Repository.Models
{
    public class Survey
    {
        public long SurveyID { get; set; }
        public string SurveyName { get; set; }
        public string CreatedBy { get; set; }
        public DateTime DateCreated { get; set; }
    }
}