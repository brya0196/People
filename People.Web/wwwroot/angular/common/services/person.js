(function () {
    'use strict';

    angular
        .module('app')
        .factory('PersonaFactory', PersonaFactory);

    PersonaFactory.$inject = ['$http'];

    function PersonaFactory($http) {
        var service = {
            getAll: getAll,
            getById: getById,
            getByIdResidence: getByIdResidence,
            add: add,
            addAll: addAll,
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

        function getByIdResidence(id) {
            return $http.get("/api/Person/GetByIdResidence/" + id);
        }

        function add(person) {
            return $http.post("/api/Person/Add", person);
        }

        function addAll(people) {
            return $http.post("/api/Person/AddAll", people);
        }

        function update(person) {
            return $http.put("/api/Person/Update", person);
        }

        function remove(id) {
            return $http.delete("/api/Person/Delete/" + id);
        }
    }
})();