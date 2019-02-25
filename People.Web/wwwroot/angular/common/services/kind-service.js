(function () {
    'use strict';

    angular
        .module('app')
        .factory('kindService', kindService);

    kindService.$inject = ['$http'];

    function kindService($http) {
        var service = {
            getAll: getAll,
            getById: getById,
            add: add,
            update: update,
            remove: remove
        };

        return service;

        function getAll() {
            return $http.get("/api/KindService/GetAll");
        }

        function getById(id) {
            return $http.get("/api/KindService/GetById/" + id);
        }

        function add(kindService) {
            return $http.post("/api/KindService/Add", kindService);
        }

        function update(kindService) {
            return $http.put("/api/KindService/Update", kindService);
        }

        function remove(id) {
            return $http.delete("/api/KindService/Delete", id);
        }
    }
})();