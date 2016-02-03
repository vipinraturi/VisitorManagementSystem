app.controller('companyController', function ($scope, $http) {
    $scope.company = {};
    $scope.company.id = 0;
    $scope.company.companyName = '';
    $scope.company.companyDescription = '';
    $scope.company.mobileNumber = null;
    $scope.company.fax = null;
    $scope.company.website = '';
    $scope.company.email = '';
    $scope.company.phoneNumber = null;
    $scope.company.address = '';
    $scope.company.zipcode = null;

    $http({
        method: 'GET',
        url: '/Api/AccountApi/GetCompanyInformation'
    }).success(function (result) {
        if (result != null) {
            debugger;
            $scope.company.id = result.Id;
            $scope.company.companyName = result.CompanyName;
            $scope.company.companyDescription = result.Description;
            $scope.company.mobileNumber = parseInt(result.MobileNumber);
            $scope.company.fax = parseInt(result.Fax);
            $scope.company.website = result.WebSite;
            $scope.company.email = result.Email;
            $scope.company.phoneNumber = parseInt(result.PhoneNumber)
            $scope.company.address = result.Address;
            $scope.company.zipcode = parseInt(result.ZipCode);
        }
    });

    $scope.SaveCompany = function () {
        debugger;
        var viewModel = {
            "Id": $scope.company.id,
            "CompanyName": $scope.company.companyName,
            "Description": $scope.company.companyDescription,
            "MobileNumber": $scope.company.mobileNumber,
            "Fax": $scope.company.fax,
            "WebSite": $scope.company.website,
            "Email": $scope.company.email,
            "PhoneNumber": $scope.company.phoneNumber,
            "Address": $scope.company.address,
            "ZipCode": $scope.company.zipcode
        };
        console.log(viewModel);
        $http.post(
            '/Api/AccountApi/SaveCompany',
            JSON.stringify(viewModel),
            {
                headers:
                {
                    'Content-Type': 'application/json'
                }
            }
        ).success(function (data) {
            //window.location.href = '/Dashboard/Index';  
            toastr.success("Save Successfully!");
        }).error(function () {
            toastr.error("Please enter the valid credentials");
        });
    };
});