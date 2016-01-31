﻿var app = angular.module('loginApp', []);
app.controller('loginController', function ($scope, $http) {

    $scope.user = '';//username@domain.com
    $scope.password = '';//********

    $scope.SignIn = function () {

        var viewModel = {
            "Username": $scope.user,
            "Password": $scope.password
        };

        $http.post(
            '/Api/AccountApi/Login',
            JSON.stringify(viewModel),
            {
                headers: {
                    'Content-Type': 'application/json'
                }
            }
        ).success(function (data) {
            window.location.href = '@Url.Action("Index", "Dashboard")';
            console.log('success post');
        }).error(function () {
            //debugger;
            $scope.error.$invalid = "An Error has occured";
        });
    };
});


jQuery(document).ready(function () {
    $.backstretch("../Content/assets/img/backgrounds/1.jpg");
});