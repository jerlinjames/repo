﻿myApp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider
        .when('/', {
            templateUrl: 'app/Views/login.html',
            controller: 'HomeController'
        })
         .when('/dashboard', {
             templateUrl: 'app/Views/dashboard.html',
             controller: 'DashboardController',
             authenticated: true
         })
        .otherwise('/', {
            templateUrl: 'app/Views/home.html',
            controller: 'HomeController'
        });
}]);

myApp.run(['$rootScope', '$location', 'authFact', function ($rootScope, $location, authFact) {
    $rootScope.$on('$routeChangeStart', function (event, next, current) {
        //console.log(event);
        //console.log(current);
        //console.log(next);

        //if route is authenticatedm the the user should access token

        if (next.$$route.authenticated) {
            var userAuth = authFact.getAccessToken();
            if (!userAuth) {
                $location.path('/');
            }
        }
    });
}]);

