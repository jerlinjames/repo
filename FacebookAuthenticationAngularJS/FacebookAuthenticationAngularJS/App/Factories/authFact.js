myApp.factory('authFact', ['$cookies', function($cookies) {
    var authFact = {};

    authFact.setAccessToken = function(accessToken) {
        $cookies.put('accessToken', accessToken);
    }

    authFact.getAccessToken = function () {
        authFact.authToken = $cookies.get('accessToken');
        return authFact.authToken;
    }

    authFact.getUserObject = function() {
        var userObj = $cookies.get('userObj');
        if (userObj) {
            return userObj;
        } else {
            console.log('userObj not found');
        }
    }
    return authFact;
}])