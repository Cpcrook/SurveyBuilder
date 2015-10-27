
'use strict';
var app = angular.module('SurveyBuilderApp');
app.controller('indexController', ['$scope', '$location', 'authService', function ($scope, $location, authService) {

    $scope.logOut = function () {
        authService.logOut();
        $location.path('/login');
    }

    $scope.authentication = authService.authentication;

}]);