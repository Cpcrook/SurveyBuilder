'use strict';
var SurveyBuilderApp = angular.module('SurveyBuilderApp');

SurveyBuilderApp.config(function($routeProvider, localStorageServiceProvider, $httpProvider) {
    //Setup routes
    $routeProvider
        .when("/", {
            templateUrl: "/Home/Home"
        })
        .when("/surveys", {
            templateUrl: "/Home/Surveys",
            controller: "SurveysController",
            resolve: {
                surveys: [
                    'SurveyService', '$route', function(surveyService, $route) {
                        return surveyService.query().$promise;
                    }
                ]
            }
        }).when("/surveys/new", {
            templateUrl: "/Home/NewSurvey",
            controller: "SurveyDetailsController",
            resolve: {
                surveyToEdit: [
                    'SurveyService', function(surveyService) {
                        return {};
                    }
                ]
            }
        }).when("/surveys/:surveyId", {
            templateUrl: "/Home/NewSurvey",
            controller: "SurveyDetailsController",
            resolve: {
                surveyToEdit: [
                    'SurveyService', '$route', function(surveyService, $route) {
                        if ($route.current.params["surveyId"]) {
                            return surveyService.get($route.current.params).$promise;
                        }
                    }
                ]
            }
        })
        .when("/take-survey/:surveyId", {
            templateUrl: "/Home/TakeSurvey",
            controller: "TakeSurveyController",
            resolve: {
                surveyToTake: [
                    'SurveyService', '$route', function(surveyService, $route) {
                        if ($route.current.params["surveyId"]) {
                            return surveyService.get($route.current.params).$promise;
                        }
                    }
                ]
            }
        })
        .when("/take-survey/:surveyId/success", {
            templateUrl: "/Home/SurveyComplete",
            controller: "TakeSurveyController",
            resolve: {
                surveyToTake: [
                    'SurveyService', '$route', function (surveyService, $route) {
                        if ($route.current.params["surveyId"]) {
                            return surveyService.get($route.current.params).$promise;
                        }
                    }
                ]
            }
        })
    
        .when("/login", {
            templateUrl: "/Account/Login",
            controller: "loginController",
        })
        .when("/register", {
            templateUrl: "/Account/Register",
            controller: "registerController",
        })
        .otherwise("/");
});