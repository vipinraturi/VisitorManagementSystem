app.controller('buildingController', function ($scope, $http) {
    $scope.building = {};
    $scope.building.id = '';
    $scope.building.Name = '';
    $scope.building.buildingLocationId = '';
    $scope.building.description = '';
    $scope.building.phoneNumber = null;
    $scope.building.address = '';
    $scope.building.email = '';
    $scope.building.zipcode = null;

    $scope.allBuildingLocations = [];
    $http({
        method: 'GET',
        url: '/Api/AccountApi/GetAllBuildingLocations'
    }).success(function (result) {
        $scope.allBuildingLocations = result;
    });

    $scope.OnChange = function () {

    }

    $scope.Edit = function (buildingId) {
        //window.location.href = '/Account/Users?userId=' + userId;
        debugger;
        $http({
            method: 'GET',
            url: '/Api/AccountApi/GetBuilding',
            params: {
                buildingId: buildingId
            }
        }).success(function (result) {
            $scope.building.firstName = result.FirstName;
            $scope.building.lastName = result.LastName;
            $scope.building.email = result.Email;
            $scope.building.address = result.Address;
            $scope.building.phoneNumber = parseInt(result.PhoneNumber);
            $scope.building.roleId = result.Roles[0].RoleId;
            $scope.building.genderId = result.Gender.Id;
            $scope.building.id = userId;
            $('#displayBuildings').hide();
            $('#addEditSection').show();
        });
    };

    $scope.Submit = function () {
        debugger;
        var viewModel = {
            "Id": $scope.building.id,
            "Name": $scope.building.name,
            "Description": $scope.building.description,
            "PhoneNumber": $scope.building.phoneNumber,
            "ZipCode": $scope.building.zipcode,
            "Address": $scope.building.address,
            "Email": $scope.building.email,
            "BuildingLocationId": $scope.building.buildingLocationId
        };

        $http.post(
            '/Api/AccountApi/InsertBuilding',
            JSON.stringify(viewModel),
            {
                headers: {
                    'Content-Type': 'application/json'
                }
            }
        ).success(function (data) {
            $('#displayBuildings').show();
            $('#addEditSection').hide();
            console.log('success post');

            $http({
                method: 'GET',
                url: '/Api/AccountApi/GetAllBuildings'
            }).success(function (result) {
                console.log(result);
                $scope.allBuildings = result;
            });
        }).error(function () {
            //$scope.error.$invalid = "An Error has occured";
            toastr.error("Oops!! Looks like there is an issue while saving")
        });
    };

    $scope.Cancel = function () {
        $('#displayBuildings').show();
        $('#addEditSection').hide();
    }

    $scope.allBuildings = [];
    $http({
        method: 'GET',
        url: '/Api/AccountApi/GetAllBuildings'
    }).success(function (result) {
        //debugger;
        $scope.allBuildings = result;
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
                    toastr.success("Record is deleted successfully!")
                }
            });
        }
    };

    $scope.NewUser = function () {
        $scope.building.firstName = '';
        $scope.building.lastName = '';
        $scope.building.email = '';
        $scope.building.address = '';
        $scope.building.phoneNumber = '';
        $scope.building.roleId = '';
        $scope.building.genderId = '';
        $scope.building.id = '';

        $('#displayBuildings').hide();
        $('#addEditSection').show();
    };
});

//app.controller('manageUsercontroller', function ($scope, $http) {

//});