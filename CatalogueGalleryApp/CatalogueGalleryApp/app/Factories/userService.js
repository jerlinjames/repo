myApp.factory('userService', ['$http', 'apiService', function ($http, api) {
    
    var apiUrl = api.url;

    var userService = {};
    userService.CheckIfUserExists =  function(fbId) {
            return $http(
            {
                url: apiUrl + "user/CheckIfUserExists?fbId=" + fbId,
                method: "GET",
                cache: false,
            }).success(function(response) {
                return response.data;
            });
        };
    userService.AddNewUser = function(obj) {
        var data = JSON.stringify(obj);
        return $http(
        {
            url: apiUrl + "user/AddNewUser",
            method: "Post",
            cache: false,
            data: data
        }).then(function(response) {
            return response.data;
        });
    };

    return userService;
}]);