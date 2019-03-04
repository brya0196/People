(function () {
    'use strict';

    angular
        .module('app')
        .factory('kindServiceFactory', kindServiceFactory);

    kindServiceFactory.$inject = ['$http', 'AuthenticationFactory'];

    function kindServiceFactory($http, AuthenticationFactory) {
        var service = {
            getAll: getAll,
            getById: getById,
            add: add,
            update: update,
            remove: remove
        };

        return service;

        function getAll() {
            return $http.get("/api/KindService/GetAll", {
                headers: {
                    "Authorization": AuthenticationFactory.getToken()
                }
            });
        }

        function getById(id) {
            return $http.get("/api/KindService/GetById/" + id, {
                headers: {
                    "Authorization": AuthenticationFactory.getToken()
                }
            });
        }

        function add(kindService) {
            return $http.post("/api/KindService/Add", kindService, {
                headers: {
                    "Authorization": AuthenticationFactory.getToken()
                }
            });
        }

        function update(kindService) {
            return $http.put("/api/KindService/Update", kindService, {
                headers: {
                    "Authorization": AuthenticationFactory.getToken()
                }
            });
        }

        function remove(id) {
            return $http.delete("/api/KindService/Delete/" + id, {
                headers: {
                    "Authorization": AuthenticationFactory.getToken()
                }
            });
        }
    }
})();