(function () {
    'use strict';

    angular
        .module('app')
        .factory('CityFactory', CityFactory);

    CityFactory.$inject = ['$http'];

    function CityFactory($http) {
        var service = {
            getAll: getAll,
            getById: getById,
            getByIdProvince: getByIdProvince,
            add: add,
            update: update,
            remove: remove
        };

        return service;

        function getAll() {
            return $http.get("/api/City/GetAll");
        }

        function getById(id) {
            return $http.get("/api/City/GetById/" + id);
        }

        function getByIdProvince(id) {
            return $http.get("/api/City/GetByIdProvince/" + id);
        }

        function add(city) {
            return $http.post("/api/City/Add", city);
        }

        function update(city) {
            return $http.put("/api/City/Update", city);
        }

        function remove(id) {
            return $http.delete("/api/City/Delete/" + id);
        }
    }
})();