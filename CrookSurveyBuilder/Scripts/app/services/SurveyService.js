var app = angular.module('SurveyBuilderApp');
app.factory('SurveyService', ['$resource', function ($resource) {
    return $resource("/api/Surveys", {}, {
        'get': {
            url: "/api/Surveys/:surveyId",
            method: 'GET'
        },
        'create': {
            method: 'POST',
        },
        'update': {
            method: 'PUT',
            url: "/api/Surveys/:surveyId",
            params: {
                surveyId: "@SurveyId"
            }
        },
        'query': {
            method: 'GET',
            isArray: true
        },
        'remove': { method: 'DELETE' },
        'delete': {
            url: "/api/Surveys/:surveyId",
            method: 'DELETE'
        }
    });
}]);