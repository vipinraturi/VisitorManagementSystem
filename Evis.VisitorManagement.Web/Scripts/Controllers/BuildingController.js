app.controller('buildingController', function ($scope, $http) {
    $scope.building = {};
    $scope.building.id = null;
    $scope.building.Name = '';
    $scope.building.buildingLocationId = null;
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
            url: '/Api/AccountApi/GetBuildingInfo',
            params: {
                buildingId: buildingId
            }
        }).success(function (result) {
            debugger;
            $scope.building.id = result.Id;
            $scope.building.name = result.Name;
            $scope.building.buildingLocationId = result.BuildingLocationId;
            $scope.building.description = result.Description;
            $scope.building.phoneNumber = parseInt(result.PhoneNumber);
            $scope.building.address = result.Address;
            $scope.building.email = result.Email;
            $scope.building.zipcode = parseInt(result.ZipCode);
            $('#displayBuildings').hide();
            $('#addEditSection').show();
        });
    };

    $scope.Submit = function () {
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
        debugger;
        $scope.allBuildings = result;
    });

    $scope.Delete = function (buildingId) {
        var result = confirm("Are you sure, you want to delete?");
        if (result) {
            $http({
                method: 'DELETE',
                url: '/Api/AccountApi/DeleteBuilding',
                params: {
                    buildingId: buildingId
                }
            }).success(function (result) {
                if (result) {
                    $http({
                        method: 'GET',
                        url: '/Api/AccountApi/GetAllBuildings'
                    }).success(function (result) {
                        $scope.allUsers = result;
                    });
                    toastr.success("Record is deleted successfully!")
                }
            });
        }
    };

    $scope.NewBuilding = function () {
        $scope.building.id = null;
        $scope.building.Name = '';
        $scope.building.buildingLocationId = null;
        $scope.building.description = '';
        $scope.building.phoneNumber = null;
        $scope.building.address = '';
        $scope.building.email = '';
        $scope.building.zipcode = null;

        $('#displayBuildings').hide();
        $('#addEditSection').show();
    };
});

//app.controller('manageUsercontroller', function ($scope, $http) {

//});