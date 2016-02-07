app.controller('visitorController', function ($scope, $http) {


    $scope.visitor = {};
    $scope.visitor.id = 0;
    $scope.visitor.FirstName = '';
    $scope.visitor.LastName = '';
    $scope.visitor.MidName = '';
    $scope.visitor.EmailId = '';
    $scope.visitor.ContactNo = '';
    $scope.visitor.FaxNo = '';
    $scope.visitor.Image = null;
    $scope.visitor.IsActive = false;
    $scope.visitor.GenderId = 0;
    $scope.submitButtonText = 'Save';
    $scope.headerText = 'Add New Visitor';
    $scope.visitor.roleId = null;
    $scope.visitorList = [];
    $scope.allGenders = [];


    $http({
        method: 'GET',
        url: '/Api/VisitorApi/GetAllVisitors'
    }).success(function (result) {
        $scope.visitorList = result;
    });


    $http({
        method: 'GET',
        url: '/Api/AccountApi/GetAllGenders'
    }).success(function (result) {
        $scope.allGenders = result;
    });

    $scope.Edit = function (visitorId) {

        $http({
            method: 'GET',
            url: '/Api/VisitorApi/GetVisitoInfo',
            params: {
                visitorId: visitorId
            }
        }).success(function (result) {

            $scope.visitor.FirstName = result.FirstName;
            $scope.visitor.LastName = result.LastName;
            $scope.visitor.MidName = result.MidName;
            $scope.visitor.EmailId = result.EmailId;
            $scope.visitor.ContactNo = result.ContactNo;
            $scope.visitor.FaxNo = result.FaxNo;
            $scope.visitor.Image = null;
            $scope.visitor.IsActive = result.IsActive;
            $scope.visitor.GenderId = result.GenderId;
            $scope.submitButtonText = 'Update';
            $scope.headerText = 'Edit Existing User';
            $('#visitorListSection').hide();
            $('#addVisitorSection').show();
        });
    };

    $scope.Submit = function () {
        var viewModel = {

            "FirstName": $scope.visitor.FirstName,
            "LastName": $scope.visitor.LastName,
            "MidName": $scope.visitor.MidName,
            "EmailId": $scope.visitor.EmailId,
            "ContactNo": $scope.visitor.ContactNo,
            "FaxNo": $scope.visitor.FaxNo,
            "Image": null,
            "IsActive": $scope.visitor.IsActive,
            "GenderId": $scope.visitor.GenderId
        };

        $http.post(
            '/Api/VisitorApi/InsertUpdateVisitor',
            JSON.stringify(viewModel),
            {
                headers: {
                    'Content-Type': 'application/json'
                }
            }
        ).success(function (data) {
            $('#visitorListSection').show();
            $('#addVisitorSection').hide();
            console.log('success post');

            //TODO: create common methods here
            $http({
                method: 'GET',
                url: '/Api/VisitorApi/GetAllVisitors'
            }).success(function (result) {
                $scope.visitorList = result;
            });

         
        }).error(function () {
            //debugger;
            $scope.error.$invalid = "An Error has occured";
        });
    };

    $scope.Cancel = function () {
        $('#visitorListSection').show();
        $('#addVisitorSection').hide();
    }

    $scope.Delete = function (visitorId) {

        var result = confirm("Are you sure, you want to delete?");
        if (result) {
            $http({
                method: 'DELETE',
                url: '/Api/VisitorApi/DeleteVisitor',
                params: {
                    visitorId: visitorId
                }
            }).success(function (result) {
                if (result) {
                    //TODO: create common methods here
                    $http({
                        method: 'GET',
                        url: '/Api/VisitorApi/GetAllVisitors'
                    }).success(function (result) {
                        $scope.visitorList = result;
                    });
                    toastr.success("Record is deleted successfully!")
                }
            });
        }
    };

    $scope.NewVisitor = function () {
        $scope.visitor.FirstName = '';
        $scope.visitor.LastName = '';
        $scope.visitor.MidName = '';
        $scope.visitor.EmailId = '';
        $scope.visitor.ContactNo = '';
        $scope.visitor.FaxNo = '';
        $scope.visitor.Image = null;
        $scope.visitor.IsActive = false;
        $scope.visitor.GenderId = 0;
        $scope.submitButtonText = 'Save';
        $scope.headerText = 'Add New Visitor';
        $('#visitorListSection').hide();
        $('#addVisitorSection').show();
    };
});
