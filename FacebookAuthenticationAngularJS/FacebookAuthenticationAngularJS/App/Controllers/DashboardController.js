myApp.controller('DashboardController', ['$scope', 'authFact', function ($scope, authfact) {
    var userObj = JSON.parse(authfact.getUserObject());
    
    $scope.name = userObj.name;
    console.log($scope.name);

}]);