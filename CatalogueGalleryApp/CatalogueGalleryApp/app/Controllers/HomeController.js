myApp.controller('homeController', ['$scope', 'userService', 'authFact', '$location', '$cookies',  function ($scope, userService, authfact, $location, $cookies) {
    $scope.name = 'Login with your Facebook account';
    $
    $scope.FBLogin = function () {
        FB.login(function (response) {
            if (response.authResponse) {
                console.log('Welcome!  Fetching your information.... ');
                FB.api('/me', {
                    //locale: 'en_US',
                    fields: 'name, email, about, age_range, bio, birthday, gender, cover, picture',
                    redirect: false
            }, function (response) {
                    console.log('Good to see you, ' + response.name + '.');
                    
                    var fbId = response.id;
                    
                    var userObjString = JSON.stringify(response);
                    //console.log(userObjString);

                    $cookies.put('userObj', userObjString);

                    //console.dir(JSON.parse($cookies.get('userObj')));


                    var accesstoken = FB.getAuthResponse().accessToken;

                    //console.log(accesstoken);

                    authfact.setAccessToken(accesstoken);

                    $location.path('/addNew');
                    $scope.$apply();

                    
                    var checkIfUserExits = userService.CheckIfUserExists(fbId);

                    if (!checkIfUserExits) {
                        console.log("UserDoes Not Exist!! Time to Create");
                    } else {
                        console.log("User Alredy Exists!!");
                    }


                });
            } else {
                console.log('User cancelled login or did not fully authorize.');
            }
        });
        
    };


    


}]);