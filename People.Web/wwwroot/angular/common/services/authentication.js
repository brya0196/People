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

                    window.localStorage.setItem('userData', {
                        id: user.user.id,
                        email: user.user.email,
                        token: user.token
                    });

                    deferred.resolve(response);
                })
                .catch(function (error) {
                    deferred.reject(error);
                });

            return deferred.promise;
        }

        function getToken() {
            var user = window.localStorage.getItem('userData');

            return "beare " + user.token;
        }

        function getUserInfo() {
            var user = window.localStorage.getItem('userData');

            return user;
        }

        function logout() {
            $http.post("/api/Authentication/Logout", data)
                .then(function (response) {
                    var user = response.data;

                    window.localStorage.removeItem('userData');

                    deferred.resolve(response);
                })
                .catch(function (error) {
                    deferred.reject(error);
                });
        }
    }
})();