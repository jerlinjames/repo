var myApp = angular.module('myApp', ['ngRoute', 'ngCookies', 'ui.bootstrap', 'angularModalService']);

window.fbAsyncInit = function () {
    FB.init({
        appId: '768640339929113',
        xfbml: true,
        version: 'v2.4'
    });
};

(function (d, s, id) {
    var js, fjs = d.getElementsByTagName(s)[0];
    if (d.getElementById(id)) { return; }
    js = d.createElement(s); js.id = id;
    js.src = "//connect.facebook.net/en_US/sdk.js";
    fjs.parentNode.insertBefore(js, fjs);
}(document, 'script', 'facebook-jssdk'));


myApp.controller('ModalController', function ($scope, close) {

    // when you need to close the modal, call close
    close("Success!");
});