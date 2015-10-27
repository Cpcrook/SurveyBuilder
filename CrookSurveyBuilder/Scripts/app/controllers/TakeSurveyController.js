var app = angular.module('SurveyBuilderApp');

app.controller('TakeSurveyController', ['$scope', '$resource', '$location', 'SurveyService', 'authService', 'surveyToTake', 'SurveyResponseService', function ($scope, $resource, $location, surveyService, authService, surveyToTake, surveyResponseService) {
    //Use an angular resource object since we're restful

    $scope.survey = surveyToTake;
    $scope.responses = {};
    $.each($scope.survey.Questions, function (index, obj) {
        $scope.responses[obj.SurveyQuestionId] = [];
    });

    $scope.isSubmitted = false;

    $scope.goToSurveys = function () {
        $location.path("/surveys");
    }

    $scope.submitSurveyResponse = function() {
        //Do some manipulation into the format we're actually looking for
        var dataToSend = [];
        var SurveyQuestionIds = Object.keys($scope.responses);

        $.each(SurveyQuestionIds, function (index, questionId) {
            //Check if it has more than one value
            if ($scope.responses[questionId].constructor === Array) {
                $.each($scope.responses[questionId], function (idx, resp) {
                    if (typeof (resp) != "undefined") {
                        dataToSend.push({
                            SurveyId: $scope.survey.SurveyId,
                            SurveyQuestionId: questionId,
                            Response: resp
                        });
                    }
                   
                });
            } else {
                dataToSend.push({
                    SurveyId: $scope.survey.SurveyId,
                    SurveyQuestionId: questionId,
                    Response: $scope.responses[questionId]
                });
            }
            
        });
        //Actually hit the server with the data
        surveyResponseService.create(dataToSend, function (successResponse) {
            //Redirect to success message
            $location.path("/take-survey/" + $scope.survey.SurveyId + "/success");
        }, function(failureResponse) {
            toastr.error("Whoops! Something went wrong and we were unable to save your survey responses.  Please try again.");
            $scope.isSubmitted = false;
        });
    };

}]);