
app.controller('manageUsercontroller', function ($scope, $http) {

    $scope.register = {};
    $scope.manageUser = {};

    $scope.register.id = '';
    $scope.register.firstName = '';
    $scope.register.lastName = '';
    $scope.register.email = '';
    $scope.register.phoneNumber = null;
    $scope.register.address = '';
    $scope.register.genderId = null;

    $scope.manageUser.CurrentPageNumber = 1;
    $scope.manageUser.sortExpression = "CompanyName";
    $scope.manageUser.sortDirection = "ASC";
    $scope.manageUser.PageSize = 5;
    $scope.manageUser.totalUsers = 0;
    $scope.manageUser.TotalPages = 2;
    
    //$scope.register = null;

    $scope.submitButtonText = 'Save';
    $scope.headerText = 'Add New User';
    $scope.register.roleId = null;
    $scope.allRoles = [];

    $scope.pageChanged = function () {
        alert('paging changes');
    }

    var vmUsers = this;
    vmUsers.GetAll = function () {
        var pagingObj = new Object();

        pagingObj.CurrentPageNumber = 1;
        pagingObj.sortExpression = 'test';
        pagingObj.sortDirection = 'test';
        pagingObj.PageSize = 5;
        pagingObj.TotalPages = 2;
        $scope.allUsers = [];

        $http.post(
       '/Api/MasterApi/GetAllUsers',
       JSON.stringify(pagingObj),
       {
           headers: {
               'Content-Type': 'application/json'
           }
       }
       ).success(function (result) {

           $scope.manageUser.CurrentPageNumber = result.CurrentPageNumber;
           $scope.manageUser.sortExpression = result.sortExpression;
           $scope.manageUser.sortDirection = result.sortDirection;
           $scope.manageUser.PageSize = result.PageSize;
           $scope.manageUser.totalUsers = result.totalUsers;
           $scope.manageUser.TotalPages = result.TotalPages;
           $scope.allUsers = result.UsersList;
       });

        //$http({
        //    method: 'GET',
        //    url: '/Api/MasterApi/GetAllUsers',
        //    pagingInformation: JSON.stringify(pagingObj)
        //})
    }

    vmUsers.GetAll();

    $scope.allGenders = [];

    $http({
        method: 'GET',
        url: '/Api/MasterApi/GetAllGenders'
    }).success(function (result) {
        $scope.allGenders = result;
    });

    $http({
        method: 'GET',
        url: '/Api/MasterApi/GetAllRoles'
    }).success(function (result) {
        $scope.allRoles = result;
    });

    $scope.OnChange = function () {

    }

    

    $scope.Edit = function (userId) {
        //window.location.href = '/Account/Users?userId=' + userId;
        $http({
            method: 'GET',
            url: '/Api/MasterApi/GetUser',
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
            $scope.submitButtonText = 'Update';
            $scope.headerText = 'Edit Existing User';
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
            '/Api/MasterApi/Register',
            JSON.stringify(viewModel),
            {
                headers: { 'Content-Type': 'application/json' }
            }
        ).success(function (data) {
            $('#displayUsers').show();
            $('#addEditSection').hide();

            vmUsers.GetAll();
            toastr.success("Saved Successfully!");
        }).error(function () {
            $scope.error.$invalid = "An Error has occured";
        });
    };

    $scope.Cancel = function () {
        $('#displayUsers').show();
        $('#addEditSection').hide();
    }


    $scope.Delete = function (userId) {

        var result = confirm("Are you sure, you want to delete?");
        if (result) {
            $http({
                method: 'DELETE',
                url: '/Api/MasterApi/DeleteUser',
                params: {
                    userId: userId
                }
            }).success(function (result) {
                if (result) {
                    vmUsers.GetAll();
                    toastr.success("Record is deleted successfully!")
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
        $scope.submitButtonText = 'Save';
        $scope.headerText = 'Add New User';
        $('#displayUsers').hide();
        $('#addEditSection').show();
    };
});

//app.controller('manageUsercontroller', function ($scope, $http) {

//});