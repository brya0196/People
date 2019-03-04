(function () {
    'use strict';

    angular
        .module('app')
        .factory('AuthenticationFactory', AuthenticationFactory);

    AuthenticationFactory.$inject = ['$http', '$q'];

    function AuthenticationFactory($http, $q) {
        window.localStorage.setItem('authenticated', false);
        var service = {
            login: login,
            getToken: getToken,
            getUserInfo: getUserInfo,
            logout: logout,
            authenticated: window.localStorage.getItem('authenticated') == "true" ? true : false
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

                    window.localStorage.setItem('authenticated', true);

                    deferred.resolve(response);
                })
                .catch(function (error) {
                    deferred.reject(error);
                });

            return deferred.promise;
        }

        function getToken() {
            var user = JSON.parse(window.localStorage.getItem('userData'));

            return "Bearer " + user.token;
        }

        function getUserInfo() {
            var user = JSON.parse(window.localStorage.getItem('userData'));

            return user;
        }

        function logout() {
            window.localStorage.removeItem('userData');
            window.localStorage.setItem('authenticated', false);
            return true;
        }
    }
})();