myApp.controller('homeController', ['$scope', 'userService', '$timeout', '$q', 'authFact', '$location', '$cookies', function ($scope, userService, $timeout, $q, authfact, $location, $cookies) {
    $scope.name = 'Login with your Facebook account';
    var fbId;


    $scope.FBLogin = function () {
        FB.login(function (response) {

            if (response.authResponse) {
                console.log('Welcome!  Fetching your information.... ');
                FB.api('/me', {
                    //locale: 'en_US',
                    fields: 'first_name, last_name, name, email, birthday, gender, picture',
                    redirect: false
                }, function (response) {
                    console.log('Good to see you, ' + response.name + '.');
                    console.log(response);
                    fbId = response.id;
                    var userObjString = JSON.stringify(response);
                    //console.log(userObjString);

                    $cookies.put('userObj', userObjString);

                    //console.dir(JSON.parse($cookies.get('userObj')));

                    var accesstoken = FB.getAuthResponse().accessToken;


                    authfact.setAccessToken(accesstoken);

                    var checkIfUserExists = userService.CheckIfUserExists(fbId);

                    checkIfUserExists.then(function (res) {
                        console.log(res.data);
                        var userExits = res.data;

                        if (userExits) {
                            console.log("User Exits");
                        } else {
                            var user = {
                                FbId: response.id,
                                FbEmail: response.email,
                                FbFirstName: response.first_name,
                                FbLastName: response.last_name,
                                FbName: response.name,
                                FbDateOfBirth: response.birthday,
                                FbGender: response.gender
                            };
                            userService.AddNewUser(user);
                        }

                    });




                    $location.path('/addNew');
                    $scope.$apply();
                }
                );
            } else {
                console.log('User cancelled login or did not fully authorize.');
            }
        }, {
            scope: 'email,user_likes,user_photos,publish_actions',
            return_scopes: true
        });
    };

}]);