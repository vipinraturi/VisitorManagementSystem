
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
    $scope.submitButtonText = 'Save';
    $scope.headerText = 'Add New User';
    $scope.register.roleId = null;
    $scope.allRoles = [];

    $scope.pagingInfo = {
        page: 1,
        itemsPerPage: 2,
        sortBy: 'FirstName',
        reverse: false,
        search: '',
        totalItems: 0,
    };

    var vmUsers = this;

    vmUsers.GetAll = function () {
        var pagingObj = new Object();
        pagingObj.CurrentPageNumber = $scope.pagingInfo.page;
        pagingObj.sortExpression = $scope.pagingInfo.sortBy;
        pagingObj.sortDirection = $scope.pagingInfo.reverse;
        pagingObj.PageSize = $scope.pagingInfo.itemsPerPage;
        pagingObj.TotalPages = $scope.pagingInfo.totalItems;
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

           //$scope.manageUser.CurrentPageNumber = result.CurrentPageNumber;
           //$scope.manageUser.sortExpression = result.sortExpression;
           //$scope.manageUser.sortDirection = result.sortDirection;
           //$scope.manageUser.PageSize = result.PageSize;
           //$scope.manageUser.totalUsers = result.totalUsers;
           //$scope.manageUser.TotalPages = result.TotalPages;

           $scope.pagingInfo.totalItems = result.TotalRows;

           $scope.allUsers = result.UsersList;
       });
    }

    vmUsers.GetAll();

    $scope.allGenders = [];

    $scope.search = function () {
        $scope.pagingInfo.page = 1;
        vmUsers.GetAll();
    };

    $scope.sort = function (sortBy) {
        if (sortBy === $scope.pagingInfo.sortBy) {
            $scope.pagingInfo.reverse = !$scope.pagingInfo.reverse;
        } else {
            $scope.pagingInfo.sortBy = sortBy;
            $scope.pagingInfo.reverse = false;
        }
        $scope.pagingInfo.page = 1;
        vmUsers.GetAll();
    };

    $scope.selectPage = function (page) {
        $scope.pagingInfo.page = page;
        vmUsers.GetAll();
    };

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

    $scope.ImageUpload = function (userId) {
        window.localStorage['userId'] = encodeURIComponent(userId);
        window.location.href = '/Master/ImageCrop';
    }
});

