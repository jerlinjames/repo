myApp.controller('dashboardController', ['$scope', 'authFact', '$location', function ($scope, authfact, $location) {
    var userObj = JSON.parse(authfact.getUserObject());

    $scope.name = userObj.name;
    $scope.pic = userObj.picture.data.url;
// get which tab is active
    $scope.$watch(function () { return $location.path(); }, function (val) {

        switch (val) {
            case "/addNew":
                $scope.addNew = true;
                $scope.categories = false;
                break;
            case "/categories":
                $scope.addNew = false;
                $scope.categories = true;
                break;
            default:
                $scope.addNew = false;
                $scope.categories = true;
                break;
        }
    });


}]);