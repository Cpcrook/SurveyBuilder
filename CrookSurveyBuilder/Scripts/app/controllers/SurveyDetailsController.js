var app = angular.module('SurveyBuilderApp');

function Question(questionText, required, order) {
    var self = this;
    self.QuestionText = questionText;
    self.Required = required;
    self.Order = order;
};

//JS inheritance
function MultipleChoiceQuestion(questionText, options, mutuallyExclusive, required, order) {
    var self = this;
    Question.call(this, questionText, required, order);
    self.Options = options || [];
    self.MutuallyExclusiveOptions = mutuallyExclusive;

};

function Option(optionText) {
    this.Option = optionText;
};

MultipleChoiceQuestion.prototype.constructor = MultipleChoiceQuestion;

app.controller('SurveyDetailsController', ['$scope', '$resource', '$location', 'SurveyService', 'authService', 'surveyToEdit', function ($scope, $resource, $location, surveyService, authService, surveyToEdit) {
    //Use an angular resource object since we're restful
    $scope.Survey = {
        SurveyId: surveyToEdit.SurveyId,
        Name: surveyToEdit.Name,
        Description: surveyToEdit.Description,
        CompletionMessage: surveyToEdit.CompletionMessage,
        Questions: []
    };
    
    if (surveyToEdit && surveyToEdit.Questions && surveyToEdit.Questions.length) {
        for (var i = 0; i < surveyToEdit.Questions.length; i++) {
            var question = surveyToEdit.Questions[i];
            if (question.Options && question.Options.length > 0) {
                $scope.Survey.Questions.push(new MultipleChoiceQuestion(question.QuestionText, question.Options, question.MutuallyExclusiveOptions, question.Required, question.Order));
            } else {
                $scope.Survey.Questions.push(new Question(question.QuestionText, question.Required, question.Order));
            }
        
        }
    }
    

    $scope.isSubmitted = false;

    $scope.save = function () {
        console.log($scope.SurveyForm.$valid);
        if ($scope.SurveyForm.$valid) {
            $scope.isSubmitted = true;

            if (typeof ($scope.Survey.SurveyId) != "undefined") {
                surveyService.update($scope.Survey, function (data) {
                    toastr.success("Successfully updated survey: " + data.Name + '. \n You will be redirected to the survey listing page in 5 seconds.');

                    //redirect to list of user surveys after 5 seconds
                    setTimeout(function () {
                        $location.path("/surveys");
                    }, 5000);

                }, function (response) {
                    toastr.error("Failed to update survey: " + response.data.Message);
                    $scope.isSubmitted = false;
                });
                
            } else {
                surveyService.create($scope.Survey, function (data) {
                    toastr.success("Successfully created survey: " + data.Name + '. \n You will be redirected to the survey listing page in 5 seconds.');

                    //redirect to list of user surveys after 5 seconds
                    setTimeout(function () {
                        $location.path("/surveys");
                    }, 5000);

                }, function (response) {

                    toastr.error("Failed to create survey: " + response.data.Message);
                });
            }
           
           
       } else {
            toastr.error("Please fill in all required fields.");
            $scope.isSubmitted = false;
       }
    };


    $scope.addMultipleChoiceQuestion = function () {
        console.log("adding multi choice");
        $scope.Survey.Questions.push(new MultipleChoiceQuestion(undefined, undefined, undefined, undefined, $scope.Survey.Questions.length + 1));
    };

    $scope.addTextQuestion = function () {
        console.log("adding text");
        $scope.Survey.Questions.push (new Question(undefined, undefined, $scope.Survey.Questions.length + 1));
    };

    $scope.removeQuestion = function(question) {
        var index = $scope.Survey.Questions.indexOf(question);
        $scope.Survey.Questions.splice(index, 1);
    };

    $scope.addOption = function(question) {
        question.Options.push(new Option(question.optionToAdd));
        question.optionToAdd = "";
    };

    $scope.removeOption = function(options, optionToRemove) {
        var index = options.indexOf(optionToRemove);
        options.splice(index, 1);
    };

    $scope.isMultipleChoice = function(question) {
        return (question instanceof MultipleChoiceQuestion);
    };

    //Allow drag and drop re-ordering
    $scope.sortableOptions = {
        stop: function (e, ui) {
            // this callback has the changed model
            for (var index in $scope.Survey.Questions) {
                $scope.Survey.Questions[index].Order = parseInt(index) + 1;
            }
        },
        axis: 'y'
    };
}]);