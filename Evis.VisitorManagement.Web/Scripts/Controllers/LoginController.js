var app = angular.module('loginApp', []);

app.controller('loginController', function ($scope, $http) {

    $scope.user = '';
    $scope.password = '';
    $scope.isPasswordSave = '';

    $scope.SignIn = function () {

        var viewModel = {
            "Username": $scope.user,
            "Password": $scope.password,
            "isPasswordSave": $scope.isPasswordSave
        };

        $http.post(
            '/Api/MasterApi/Login',
            JSON.stringify(viewModel),
            {
                headers:
                {
                    'Content-Type': 'application/json'
                }
            }
        ).success(function (data) {
            window.location.href ='/Dashboard/Index';
        }).error(function () {
            toastr.error("Please enter the valid credentials");
        });
    };
});

jQuery(document).ready(function () {
    $.backstretch("../Content/assets/img/backgrounds/1.jpg");
});
