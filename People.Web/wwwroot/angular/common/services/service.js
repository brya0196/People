(function () {
    'use strict';

    angular
        .module('app')
        .factory('ServiceFactory', ServiceFactory);

    ServiceFactory.$inject = ['$http'];

    function ServiceFactory($http) {
        var service = {
            getAll: getAll,
            getById: getById,
            add: add,
            addAll: addAll,
            update: update,
            remove: remove
        };

        return service;

        function getAll() {
            return $http.get("/api/Service/GetAll");
        }

        function getById(id) {
            return $http.get("/api/Service/GetById/" + id);
        }

        function add(service) {
            return $http.post("/api/Service/Add", service);
        }

        function addAll(services) {
            return $http.post("/api/Service/AddAll", services);
        }

        function update(service) {
            return $http.put("/api/Service/Update", service);
        }

        function remove(id) {
            return $http.delete("/api/Service/Delete/" + id);
        }
    }
})();