//NOTE: also borrowed for the sake of getting auth done http://bitoftech.net/2014/06/09/angularjs-token-authentication-using-asp-net-web-api-2-owin-asp-net-identity/
'use strict';
app.controller('registerController', ['$scope', '$location', 'authService', function ($scope, $location, authService) {

    $scope.registrationData = {
        email: "",
        password: "",
        confirmPassword: ""
    };

    $scope.message = "";

    $scope.register = function () {
        authService.saveRegistration($scope.registrationData).then(function (response) {
            $scope.registrationData.userName = encodeURIComponent($scope.registrationData.email);
                authService.login($scope.registrationData).then(function() {
                    $location.path('/surveys');
                });

            },
         function (err) {
             $scope.message = err.Message;
         });
    };

}]);