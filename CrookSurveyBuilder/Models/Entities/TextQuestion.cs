using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrookSurveyBuilder.Models.Entities
{
    public class TextQuestion : SurveyQuestion
    {
        public TextQuestion()
        {
            base.Options = null;
        }
    }
}