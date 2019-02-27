(function () {
    'use strict';

    angular
        .module('app')
        .factory('ProvinceFactory', ProvinceFactory);

    ProvinceFactory.$inject = ['$http'];

    function ProvinceFactory($http) {
        var service = {
            getAll: getAll,
            getById: getById,
            add: add,
            update: update,
            remove: remove
        };

        return service;

        function getAll() {
            return $http.get("/api/Province/GetAll");
        }

        function getById(id) {
            return $http.get("/api/Province/GetById/" + id);
        }

        function add(province) {
            return $http.post("/api/Province/Add", province);
        }

        function update(province) {
            return $http.put("/api/Province/Update", province);
        }

        function remove(id) {
            return $http.delete("/api/Province/Delete/" + id);
        }
    }
})();