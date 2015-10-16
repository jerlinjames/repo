myApp.controller('addNewController', ['$scope', 'authFact', '$http', '$timeout',  function ($scope, authFact, $http, $timeout) {
    $scope.stuff = "Add Stuff here!!";
    var accessToken = authFact.getAccessToken();

    $scope.init = function() {
        $scope.getAllAlbums();
        

    };
    

    $scope.getAllAlbums = function() {
        FB.api("me/albums", {
            fields: 'id, can_upload, count, name, privacy, type, updated_time',
            access_token: accessToken
        },
           function (response) {
               if (response && !response.error) {
                   
                   $scope.allAlbums = response.data;
                   //console.dir($scope.allAlbums);
                   $scope.$apply();
                   return response.data;
               } else {
                   console.log(response);
                   
               }
           }
       );
    }


    

    $scope.upload = function () {
        var albumId = $scope.selectedAlbum.id;
        console.log(albumId);
        //hello.api("facebook:/" + albumId + "/photos", 'post', {
        hello.api("facebook:/"+albumId+"/photos", 'POST', {
            source: document.getElementById('file'),
            caption: $scope.caption,
            access_token: accessToken
        },
        function (r) {
            alert(r && !r.error ? 'Success' : 'Failed');
            $scope.caption = '';
            $scope.selectedAlbum = '';
            $('#file').val('');
            $scope.$apply();
        });
    }


    $scope.createNewAlbum = function() {
        hello.api("facebook:/me/albums", 'POST', {
                name: $scope.newAlbumName,
                message: $scope.newAlbumDescription,
                access_token: accessToken
            },
            function(response) {
                if (response && !response.error) {
                    console.log('Album Created');
                    $scope.$apply();
                } else {
                    console.log(response);
                }
            }
        );
    };

}]);