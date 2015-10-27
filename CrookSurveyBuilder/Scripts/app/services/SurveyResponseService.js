var app = angular.module('SurveyBuilderApp');
app.factory('SurveyResponseService', ['$resource', function ($resource) {
    return $resource("/api/SurveyResponses", {}, {
        'get': {
            url: "/api/Surveys/:surveyId",
            method: 'GET'
        },
        'create': {
            method: 'POST',
            isArray: true
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