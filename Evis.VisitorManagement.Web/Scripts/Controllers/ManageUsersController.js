
app.controller('manageUsercontroller', function ($scope, $http) {

    $scope.register = {};
    $scope.register.id = '';
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

    $scope.Edit = function (userId) {
        //window.location.href = '/Account/Users?userId=' + userId;
        debugger;
        $http({
            method: 'GET',
            url: '/Api/AccountApi/GetUser',
            params: {
                userId: userId
            }
        }).success(function (result) {
            $scope.register.firstName = result.FirstName;
            $scope.register.lastName = result.LastName;
            $scope.register.email = result.Email;
            $scope.register.address = result.Address;
            $scope.register.phoneNumber = parseInt(result.PhoneNumber);
            $scope.register.roleId = result.Roles[0].RoleId;
            $scope.register.genderId = result.Gender.Id;
            $scope.register.id = userId;
            $('#displayUsers').hide();
            $('#addEditSection').show();
        });
    };

    $scope.Submit = function () {
        var viewModel = {
            "FirstName": $scope.register.firstName,
            "LastName": $scope.register.lastName,
            "Email": $scope.register.email,
            "PhoneNumber": $scope.register.phoneNumber,
            "RoleId": $scope.register.roleId,
            "Address": $scope.register.address,
            "GenderId": $scope.register.genderId,
            "UserId": $scope.register.id
        };

        $http.post(
            '/Api/AccountApi/Register',
            JSON.stringify(viewModel),
            {
                headers: {
                    'Content-Type': 'application/json'
                }
            }
        ).success(function (data) {
            $('#displayUsers').show();
            $('#addEditSection').hide();
            console.log('success post');

            $http({
                method: 'GET',
                url: '/Api/AccountApi/GetAllUsers'
            }).success(function (result) {
                //debugger;
                $scope.allUsers = result;
            });

            //$scope.$apply();

        }).error(function () {
            //debugger;
            $scope.error.$invalid = "An Error has occured";
        });
    };

    $scope.Cancel = function () {
        $('#displayUsers').show();
        $('#addEditSection').hide();
    }

    $scope.allUsers = [];
    $http({
        method: 'GET',
        url: '/Api/AccountApi/GetAllUsers'
    }).success(function (result) {
        //debugger;
        $scope.allUsers = result;
    });

    $scope.Delete = function (userId) {

        var result = confirm("Are you sure, you want to delete?");
        if (result) {
            $http({
                method: 'DELETE',
                url: '/Api/AccountApi/DeleteUser',
                params: {
                    userId: userId
                }
            }).success(function (result) {
                if (result) {
                    $http({
                        method: 'GET',
                        url: '/Api/AccountApi/GetAllUsers'
                    }).success(function (result) {
                        $scope.allUsers = result;
                    });
                }
            });
        }
    };

    $scope.NewUser = function () {
        $scope.register.firstName = '';
        $scope.register.lastName = '';
        $scope.register.email = '';
        $scope.register.address = '';
        $scope.register.phoneNumber = '';
        $scope.register.roleId = '';
        $scope.register.genderId = '';
        $scope.register.id = '';

        $('#displayUsers').hide();
        $('#addEditSection').show();
    };
});

//app.controller('manageUsercontroller', function ($scope, $http) {

//});