var app = angular.module('app', []);
app.controller('manageUsercontroller', function ($scope, $http) {
    $scope.allUsers = [];
    $http({
        method: 'GET',
        url: '/Api/AccountApi/GetAllUsers'
    }).success(function (result) {
        $scope.allUsers = result;
    });

    $scope.GetUser = function (Id) {
        alert(Id);
        alert("Get User");
    };

    $scope.DeleteUser = function () { alert("Delete Users"); };
});