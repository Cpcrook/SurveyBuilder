var app = angular.module('SurveyBuilderApp');

app.controller('SurveysController', ['$scope', '$resource', '$location', 'SurveyService', 'authService', 'surveys', function ($scope, $resource, $location, surveyService, authService, surveys) {
    //Use an angular resource object since we're restful
    

    MultipleChoiceQuestion.prototype.constructor = MultipleChoiceQuestion;
    $scope.surveys = surveys;

    $scope.createNewSurvey = function() {
        $location.path('/surveys/new');
    };

    $scope.deleteSurvey = function (surveyToDelete) {
        if (confirm("Are you sure you want to delete " + surveyToDelete.Name + "?")) {
            surveyService.delete({ surveyId : surveyToDelete.SurveyId }, function (successResponse) {
                toastr.success("Succesfully deleted " + surveyToDelete.Name);
                var surveyToDeleteIndex = $scope.surveys.indexOf(surveyToDelete);
                $scope.surveys.splice(surveyToDeleteIndex, 1);
            }, function (failureResponse) {
                toastr.error("Failed to delete " + surveyToDelete.Name);
            });
        }
        

    };

}]);