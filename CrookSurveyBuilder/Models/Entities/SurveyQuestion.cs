using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CrookSurveyBuilder.Models.Entities
{
    public class SurveyQuestion
    {
        public int SurveyQuestionId { get; set; }
        public string QuestionText { get; set; }
        public virtual IList<MultipleChoiceOption> Options { get; set; }
        public bool MutuallyExclusiveOptions { get; set; }
        public bool Required { get; set; }
        public int Order { get; set; }
    }

    public class MultipleChoiceOption
    {
        public int MultipleChoiceOptionID { get; set; }
        public string Option { get; set; }
    }
    //TODO: authentication
    //TODO: implement ordering in the Question Model (ui-sortable)
    //TODO: implement mutual exclusivity option
    //TODO: implement Required option
    //TODO: Render Survey for submissions (allow anonymous access, radio buttons if mutually exclusive, checkboxes otherwise, on submit, show Completion Message in Jumbotron)
    //TODO: SurveyResponse controller
    //TODO: Implement repository pattern
    //TODO: Autorization attributes on API
    //TODO: update site layout
    //TODO: add FluentValidation server-side for entity models?
    //TODO: dependency injection?
    //TODO: test coverage of the API?
    //TODO: add confirmations on remove
    //TODO: clean up bundles

}