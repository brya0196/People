(function () {
    'use strict';

    angular
        .module('app')
        .factory('serviceFactory', serviceFactory);

    serviceFactory.$inject = ['$http'];

    function serviceFactory($http) {
        var service = {
            getAll: getAll,
            getById: getById,
            add: add,
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

        function update(service) {
            return $http.put("/api/Service/Update", service);
        }

        function remove(id) {
            return $http.delete("/api/Service/Delete", id);
        }
    }
})();