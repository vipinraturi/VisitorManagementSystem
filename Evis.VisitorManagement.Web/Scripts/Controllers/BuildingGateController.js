app.controller('gateController', function ($scope, $http) {
    $scope.gate = {};
    $scope.gate.id = null;
    $scope.gate.buildingId = '';
    $scope.gate.buildingName = '';
    $scope.gate.description = '';
    $scope.gate.gateNumber = null;
    $scope.gate.phoneNumber = null;
    $scope.gate.region = '';
    $scope.gate.country = '';
    $scope.gate.state = '';
    $scope.gate.city = '';
    $scope.submitButtonText = 'Save';
    $scope.headerText = 'Add New Gate';

    $scope.OnChangeBuilding = function (selectedBuildingId) {
        angular.forEach($scope.allBuildings, function (value, key) {
            if (value.Id == selectedBuildingId) {
                //Selecting the region.
                $scope.gate.region = value.Region;

                // Selecting the Country
                angular.forEach(allRegions, function (value, key) {
                    if (key == $scope.gate.region) {
                        $scope.allCountries.length = 0;
                        value = value.split('|');
                        angular.forEach(value, function (value, key) {
                            $scope.allCountries.push(value);
                        });
                    }
                });
                $scope.gate.country = value.Country;

                angular.forEach(allStates, function (value, key) {
                    if (key == $scope.gate.country) {
                        $scope.allStates.length = 0;
                        value = value.split('|');
                        angular.forEach(value, function (value, key) {
                            $scope.allStates.push(value);
                        });
                    }
                });
                $scope.gate.state = value.State;

                angular.forEach(allCities, function (value, key) {
                    if (key == $scope.gate.state) {
                        $scope.allCities.length = 0;
                        value = value.split('|');
                        angular.forEach(value, function (value, key) {
                            $scope.allCities.push(value);
                        });
                    }
                });

                $scope.gate.city = value.City;

            }
        });
    }

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

    $scope.Edit = function (gateId) {
        $http({
            method: 'GET',
            url: '/Api/AccountApi/GetBuildingGateInfo',
            params: {
                gateId: gateId
            }
        }).success(function (result) {
            debugger;
            $scope.gate.id = result.Id;
            $scope.gate.buildingId = result.BuildingId;
            $scope.gate.description = result.Description;
            $scope.gate.gateNumber = parseInt(result.GateNumber);
            $scope.gate.phoneNumber = parseInt(result.PhoneNumber);
            $scope.gate.region = result.Region;
            $scope.gate.country = result.Country;
            $scope.gate.state = result.State;
            $scope.gate.city = result.City;

            angular.forEach($scope.allRegions, function (value, key) {
                if (key == result.Region) {
                    $scope.allCountries.length = 0;
                    value = value.split('|');
                    angular.forEach(value, function (value, key) {
                        $scope.allCountries.push(value);
                    });
                }
            });
            $scope.gate.country = result.Country;

            angular.forEach(allStates, function (value, key) {
                if (key == result.Country) {
                    $scope.allStates.length = 0;
                    value = value.split('|');
                    angular.forEach(value, function (value, key) {
                        $scope.allStates.push(value);
                    });
                }
            });
            $scope.gate.state = result.State;

            angular.forEach(allCities, function (value, key) {
                if (key == result.State) {
                    $scope.allCities.length = 0;
                    value = value.split('|');
                    angular.forEach(value, function (value, key) {
                        $scope.allCities.push(value);
                    });
                }
            });
            $scope.gate.city = result.City;

            $scope.submitButtonText = 'Update';
            $scope.headerText = 'Edit Existing Gate';
            $('#displaygates').hide();
            $('#addEditSection').show();
        });
    };

    $scope.Submit = function () {
        debugger;
        var viewModel = {
            "Id": $scope.gate.id,
            "GateNumber": $scope.gate.gateNumber,
            "Description": $scope.gate.description,
            "PhoneNumber": $scope.gate.phoneNumber,
            "BuildingId": $scope.gate.buildingId,
        };

        $http.post(
            '/Api/AccountApi/InsertGate',
            JSON.stringify(viewModel),
            {
                headers: {
                    'Content-Type': 'application/json'
                }
            }
        ).success(function (data) {
            $('#displaygates').show();
            $('#addEditSection').hide();
            console.log('success post');

            $http({
                method: 'GET',
                url: '/Api/AccountApi/GetAllGates'
            }).success(function (result) {
                console.log(result);
                $scope.allGates = result;
                $('#addEditSection').hide();
                $('#displayGates').show();
            });
            toastr.success("Saved Successfully!");
        }).error(function () {
            //$scope.error.$invalid = "An Error has occured";
            toastr.error("Oops!! Looks like there is an issue while saving")
        });
    };

    $scope.Cancel = function () {
        $('#displayGates').show();
        $('#addEditSection').hide();
    }

    // To get all gates and to bind with grid
    $http({
        method: 'GET',
        url: '/Api/AccountApi/GetAllGates'
    }).success(function (result) {
        debugger;
        $scope.allGates = result;
    });

    // To get all buildings and to bind with building name dropdown
    $http({
        method: 'GET',
        url: '/Api/AccountApi/GetAllBuildings'
    }).success(function (result) {
        debugger;
        $scope.allBuildings = result;
        $scope.allBuildingName = [];
        angular.forEach(result, function (value, key) {
            $scope.allBuildingName[value.Id] = value.Name;
        });

    });

    $scope.Delete = function (gateId) {
        var result = confirm("Are you sure, you want to delete?");
        if (result) {
            $http({
                method: 'DELETE',
                url: '/Api/AccountApi/DeleteBuildingGate',
                params: {
                    gateId: gateId
                }
            }).success(function (result) {
                debugger;
                if (result) {
                    $http({
                        method: 'GET',
                        url: '/Api/AccountApi/GetAllGates'
                    }).success(function (result) {
                        $scope.allGates = result;
                    });
                    toastr.success("Record is deleted successfully!")
                }
            });
        }
    };

    $scope.NewGate = function () {
        $scope.gate.id = null;
        $scope.gate.buildingId = '';
        $scope.gate.buildingName = '';
        $scope.gate.description = '';
        $scope.gate.gateNumber = null;
        $scope.gate.phoneNumber = null;
        $scope.gate.region = '';
        $scope.gate.country = '';
        $scope.gate.state = '';
        $scope.gate.city = '';
        $scope.submitButtonText = 'Save';
        $scope.headerText = 'Add New Gate';
        $('#displayGates').hide();
        $('#addEditSection').show();
    };

    $scope.Cancel = function () {
        $('#displayGates').show();
        $('#addEditSection').hide();
    }
});