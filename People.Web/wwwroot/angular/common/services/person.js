(function () {
    'use strict';

    angular
        .module('app')
        .factory('PersonService', PersonService);

    PersonService.$inject = ['$http'];

    function PersonService($http) {
        var service = {
            getAll: getAll,
            getById: getById,
            add: add,
            update: update,
            remove: remove
        };

        return service;

        function getAll() {
            return $http.get("/api/Person/GetAll");
        }

        function getById(id) {
            return $http.get("/api/Person/GetById/" + id);
        }

        function add(person) {
            return $http.post("/api/Person/Add", person);
        }

        function update(person) {
            return $http.put("/api/Person/Update", person);
        }

        function remove(id) {
            return $http.delete("/api/Person/Delete", id);
        }
    }
})();