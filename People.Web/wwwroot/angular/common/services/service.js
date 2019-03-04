(function () {
    'use strict';

    angular
        .module('app')
        .factory('ServiceFactory', ServiceFactory);

    ServiceFactory.$inject = ['$http', 'AuthenticationFactory'];

    function ServiceFactory($http, AuthenticationFactory) {
        var service = {
            getAll: getAll,
            getById: getById,
            getAllByIdResidence: getAllByIdResidence,
            add: add,
            addAll: addAll,
            update: update,
            remove: remove
        };

        return service;

        function getAll() {
            return $http.get("/api/Service/GetAll", {
                headers: {
                    "Authorization": AuthenticationFactory.getToken()
                }
            });
        }

        function getById(id) {
            return $http.get("/api/Service/GetById/" + id, {
                headers: {
                    "Authorization": AuthenticationFactory.getToken()
                }
            });
        }

        function getAllByIdResidence(id) {
            return $http.get("/api/Service/GetAllByIdResidence/" + id, {
                headers: {
                    "Authorization": AuthenticationFactory.getToken()
                }
            });
        }

        function add(service) {
            return $http.post("/api/Service/Add", service, {
                headers: {
                    "Authorization": AuthenticationFactory.getToken()
                }
            });
        }

        function addAll(services) {
            return $http.post("/api/Service/AddAll", services, {
                headers: {
                    "Authorization": AuthenticationFactory.getToken()
                }
            });
        }

        function update(service) {
            return $http.put("/api/Service/Update", service, {
                headers: {
                    "Authorization": AuthenticationFactory.getToken()
                }
            });
        }

        function remove(id) {
            return $http.delete("/api/Service/Delete/" + id, {
                headers: {
                    "Authorization": AuthenticationFactory.getToken()
                }
            });
        }
    }
})();