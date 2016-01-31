var app = angular.module('app', []);
app.controller('registerController', function ($scope, $http) {
    $scope.register = {};
    $scope.register.firstName = '';
    $scope.register.lastName = '';
    $scope.register.email = '';
    $scope.register.phoneNumber = null;
    $scope.register.address = '';
    $scope.register.genderId = null;

    $scope.register.roleId = null;
    $scope.allRoles = [];

    $http({
        method: 'GET',
        url: '/Api/AccountApi/GetAllRoles'
    }).success(function (result) {
        $scope.allRoles = result;
    });

    $scope.OnChange = function () {

    }

    $scope.allGenders = [];
    $http({
        method: 'GET',
        url: '/Api/AccountApi/GetAllGenders'
    }).success(function (result) {
        $scope.allGenders = result;
    });

    $scope.Submit = function () {
        var viewModel = {
            "FirstName": $scope.register.firstName,
            "LastName": $scope.register.lastName,
            "Email": $scope.register.email,
            "PhoneNumber": $scope.register.phoneNumber,
            "RoleId": $scope.register.roleId,
            "Address": $scope.register.addressId,
            "GenderId": $scope.register.genderId
        };

        //alert(JSON.stringify(viewModel));

        $http.post(
            '/Api/AccountApi/Register',
            JSON.stringify(viewModel),
            {
                headers: {
                    'Content-Type': 'application/json'
                }
            }
        ).success(function (data) {
            window.location.href = 'Account/ManageUsers'; // '@Url.Action("ManageUsers", "Account")';
            console.log('success post');
        }).error(function () {
            //debugger;
            $scope.error.$invalid = "An Error has occured";
        });
    };
});