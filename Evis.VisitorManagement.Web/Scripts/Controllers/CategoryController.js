app.controller("category", function ($scope, $http) {
    $scope.message = "";
    $scope.left = function () { return 100 - $scope.message.length; };
    $scope.clear = function () { $scope.message = ""; };
    $scope.save = function () { alert("Note Saved"); };

    $scope.initializeController = function () {
        console.log('loading..');

        //get all customer information
        $http.get('api/CategoryApi/').success(function (data) {
            $scope.values = data;
            console.log(data);
        })
        .error(function () {
            $scope.error = "An Error has occured";
        });

        //for insert test
        var data = { "value": "test" };
        $http.post(
            'api/CategoryApi/Post',
            JSON.stringify(data),
            {
                headers: {
                    'Content-Type': 'application/json'
                }
            }
        ).success(function (data) {
            console.log('success post');
        }).error(function () {
            $scope.error = "An Error has occured";
        });

    };

  
    $scope.Add = function () {
        var data = { "value": "test" };
        $http.post(
            'api/CategoryApi/Post',
            JSON.stringify(data),
            {
                headers: {
                    'Content-Type': 'application/json'
                }
            }
        ).success(function (data) {
            console.log('success post');
        }).error(function () {
            $scope.error = "An Error has occured";
        });
    };

    $scope.Update = function () {
        $http.put('api/CategoryApi/Put?id=1&value=2222').success(function (data) {
            console.log("Saved Successfully!!");

        }).error(function () {
            $scope.error = "An Error has occured";
        });
    };

    $scope.Delete = function () {

        $http.delete("api/CategoryApi/Delete?id=1").success(function (response) {
            console.log('Deleted');
        }).error(function () {
            $scope.error = "An Error has occured";

        });
    };

    $scope.Get = function () {
        $http.get("api/CategoryApi/Get?id=1").success(function (response) {
            console.log(response);
        }).error(function () {
            $scope.error = "An Error has occured";

        });
    };

    $scope.GetAll = function () {
       
    };
});