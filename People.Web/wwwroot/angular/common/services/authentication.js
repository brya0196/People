(function () {
    'use strict';

    angular
        .module('app')
        .factory('AuthenticationFactory', AuthenticationFactory);

    AuthenticationFactory.$inject = ['$http', '$q'];

    function AuthenticationFactory($http, $q) {
        var service = {
            login: login,
            getToken: getToken,
            getUserInfo: getUserInfo,
            logout: logout
        };

        return service;

        function login(data) {
            var deferred = $q.defer();

            $http.post("/api/Authentication/Login", data)
                .then(function (response) {
                    var user = response.data;

                    window.localStorage.setItem('userData', JSON.stringify({
                        id: user.user.id,
                        email: user.user.email,
                        token: user.token,
                        username: user.user.username
                    }));

                    deferred.resolve(response);
                })
                .catch(function (error) {
                    deferred.reject(error);
                });

            return deferred.promise;
        }

        function getToken() {
            var user = JSON.parse(window.localStorage.getItem('userData'));
            console.log("Bearer " + user.token);
            return "Bearer " + user.token;
        }

        function getUserInfo() {
            var user = JSON.parse(window.localStorage.getItem('userData'));

            return user;
        }

        function logout() {
            window.localStorage.removeItem('userData');
            return true;
        }
    }
})();