(function () {
    'use strict';

    angular
        .module('app')
        .factory('ProvinceFactory', ProvinceFactory);

    ProvinceFactory.$inject = ['$http', 'AuthenticationFactory'];

    function ProvinceFactory($http, AuthenticationFactory) {
        var service = {
            getAll: getAll,
            getById: getById,
            add: add,
            update: update,
            remove: remove
        };

        return service;

        function getAll() {
            return $http.get("/api/Province/GetAll", {
                headers: {
                    "Authorization": AuthenticationFactory.getToken()
                }
            });
        }

        function getById(id) {
            return $http.get("/api/Province/GetById/" + id, {
                headers: {
                    "Authorization": AuthenticationFactory.getToken()
                }
            });
        }

        function add(province) {
            return $http.post("/api/Province/Add", province, {
                headers: {
                    "Authorization": AuthenticationFactory.getToken()
                }
            });
        }

        function update(province) {
            return $http.put("/api/Province/Update", province, {
                headers: {
                    "Authorization": AuthenticationFactory.getToken()
                }
            });
        }

        function remove(id) {
            return $http.delete("/api/Province/Delete/" + id, {
                headers: {
                    "Authorization": AuthenticationFactory.getToken()
                }
            });
        }
    }
})();