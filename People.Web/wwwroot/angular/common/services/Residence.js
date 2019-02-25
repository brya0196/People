(function () {
    'use strict';

    angular
        .module('app')
        .factory('residence', residence);

    residence.$inject = ['$http'];

    function residence($http) {
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
            return $http.post("/api/Residence/Add", Residence);
        }

        function update(residence) {
            return $http.put("/api/Residence/Update", Residence);
        }

        function remove(id) {
            return $http.delete("/api/Residence/Delete", id);
        }
    }
})();