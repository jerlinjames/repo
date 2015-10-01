myApp.controller('HomeController', ['$scope', 'authFact', '$location', '$cookies', function ($scope, authfact, $location, $cookies) {
    $scope.name = 'Login Please';

    $scope.FBLogin = function () {
        FB.login(function (response) {
            if (response.authResponse) {
                console.log('Welcome!  Fetching your information.... ');
                FB.api('/me', { locale: 'en_US', fields: 'name, email' }, function (response) {
                    console.log('Good to see you, ' + response.name + '.');
                    console.log(response);
                    var userObjString = JSON.stringify(response);
                    console.log(userObjString);

                    $cookies.put('userObj', userObjString);

                    //console.dir(JSON.parse($cookies.get('userObj')));


                    var accesstoken = FB.getAuthResponse().accessToken;

                    console.log(accesstoken);

                    authfact.setAccessToken(accesstoken);

                    $location.path('/dashboard');
                    $scope.$apply();
                });
            } else {
                console.log('User cancelled login or did not fully authorize.');
            }
        });
    };


}]);