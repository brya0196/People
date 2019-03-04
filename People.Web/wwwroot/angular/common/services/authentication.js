(function () {
    'use strict';

    angular
        .module('app')
        .factory('AuthenticationFactory', AuthenticationFactory);

    AuthenticationFactory.$inject = ['$http'];

    function AuthenticationFactory($http) {
        var service = {
            login: login
        };

        return service;

        function login(data) {
            return $http.post("/api/Authentication/Login", data);
        }
    }
})();