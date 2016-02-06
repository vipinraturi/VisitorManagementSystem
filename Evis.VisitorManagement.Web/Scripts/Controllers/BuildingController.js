app.controller('buildingController', function ($scope, $http) {
    $scope.building = {};
    $scope.building.id = null;
    $scope.building.Name = '';
    $scope.building.region = '';
    $scope.building.description = '';
    $scope.building.phoneNumber = null;
    $scope.building.address = '';
    $scope.building.email = '';
    $scope.building.zipcode = null;
    $scope.building.country = '';
    $scope.building.state = '';
    $scope.building.city = '';

    // Initializing all the regions.
    $scope.allRegions = allRegions;

    // Initializing all the countries based on selected region.
    $scope.allCountries = [];
    $scope.OnChangeRegion = function (selectedRegion) {
        debugger;
        if (selectedRegion != '') {
            angular.forEach($scope.allRegions, function (value, key) {
                if (key == selectedRegion) {
                    $scope.allCountries.length = 0;
                    value = value.split('|');
                    angular.forEach(value, function (value, key) {
                        $scope.allCountries.push(value);
                    });
                }
            });
        }
        else {

        }
    };

    // Initializing all the states based on selected country.
    $scope.allStates = [];
    $scope.OnChangeCountry = function (selectedCountry) {
        angular.forEach(allStates, function (value, key) {
            debugger;
            if (key == selectedCountry) {
                $scope.allStates.length = 0;
                value = value.split('|');
                angular.forEach(value, function (value, key) {
                    $scope.allStates.push(value);
                });
            }
        });
    }

    $scope.allCities = [];
    $scope.OnChangeState = function (selectedState) {
        angular.forEach(allCities, function (value, key) {
            debugger;
            if (key == selectedState) {
                $scope.allCities.length = 0;
                value = value.split('|');
                angular.forEach(value, function (value, key) {
                    $scope.allCities.push(value);
                });
            }
        });
    }

    $scope.Edit = function (buildingId) {
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
            $scope.building.region = result.Region;
            $scope.building.description = result.Description;
            $scope.building.phoneNumber = parseInt(result.PhoneNumber);
            $scope.building.address = result.Address;
            $scope.building.email = result.Email;
            $scope.building.zipcode = parseInt(result.ZipCode);

            angular.forEach($scope.allRegions, function (value, key) {
                if (key == result.Region) {
                    $scope.allCountries.length = 0;
                    value = value.split('|');
                    angular.forEach(value, function (value, key) {
                        $scope.allCountries.push(value);
                    });
                }
            });
            $scope.building.country = result.Country;

            angular.forEach(allStates, function (value, key) {
                if (key == result.Country) {
                    $scope.allStates.length = 0;
                    value = value.split('|');
                    angular.forEach(value, function (value, key) {
                        $scope.allStates.push(value);
                    });
                }
            });
            $scope.building.state = result.State;

            angular.forEach(allCities, function (value, key) {
                if (key == result.State) {
                    $scope.allCities.length = 0;
                    value = value.split('|');
                    angular.forEach(value, function (value, key) {
                        $scope.allCities.push(value);
                    });
                }
            });
            $scope.building.city = result.City;

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
            "Region": $scope.building.region,
            "State": $scope.building.state,
            "Country": $scope.building.country,
            "City": $scope.building.city
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
        $scope.building.name = '';
        $scope.building.region = '';
        $scope.building.country = '';
        $scope.building.state = '';
        $scope.building.description = '';
        $scope.building.phoneNumber = null;
        $scope.building.address = '';
        $scope.building.email = '';
        $scope.building.zipcode = null;
        $scope.building.city = '';

        $('#displayBuildings').hide();
        $('#addEditSection').show();
    };
});