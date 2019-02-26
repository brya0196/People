(function () {
    'use strict';

    angular
        .module('app')
        .factory('ResidenceFactory', ResidenceFactory);

    ResidenceFactory.$inject = ['$http'];

    function ResidenceFactory($http) {
        var service = {
            getAll: getAll,
            getById: getById,
            add: add,
            update: update,
            remove: remove
        };

        return service;

        function getAll() {
            return $http.get("/api/Residence/GetAll");
        }

        function getById(id) {
            return $http.get("/api/Residence/GetById/" + id);
        }

        function add(residence) {
            return $http.post("/api/Residence/Add", residence);
        }

        function update(residence) {
            return $http.put("/api/Residence/Update", residence);
        }

        function remove(id) {
            return $http.delete("/api/Residence/Delete", id);
        }
    }
})();