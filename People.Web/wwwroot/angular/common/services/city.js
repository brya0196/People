(function () {
    'use strict';

    angular
        .module('app')
        .factory('CityFactory', CityFactory);

    CityFactory.$inject = ['$http', 'AuthenticationFactory'];

    function CityFactory($http, AuthenticationFactory) {
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
            return $http.get("/api/City/GetAll", {
                headers: {
                    "Authorization": AuthenticationFactory.getToken()
                }
            });
        }

        function getById(id) {
            return $http.get("/api/City/GetById/" + id, {
                headers: {
                    "Authorization": AuthenticationFactory.getToken()
                }
            });
        }

        function getByIdProvince(id) {
            return $http.get("/api/City/GetByIdProvince/" + id, {
                headers: {
                    "Authorization": AuthenticationFactory.getToken()
                }
            });
        }

        function add(city) {
            return $http.post("/api/City/Add", city, {
                headers: {
                    "Authorization": AuthenticationFactory.getToken()
                }
            });
        }

        function update(city) {
            return $http.put("/api/City/Update", city, {
                headers: {
                    "Authorization": AuthenticationFactory.getToken()
                }
            });
        }

        function remove(id) {
            return $http.delete("/api/City/Delete/" + id, {
                headers: {
                    "Authorization": AuthenticationFactory.getToken()
                }
            });
        }
    }
})();