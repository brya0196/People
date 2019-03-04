(function () {
    'use strict';

    angular
        .module('app')
        .factory('ResidenceFactory', ResidenceFactory);

    ResidenceFactory.$inject = ['$http', 'AuthenticationFactory'];

    function ResidenceFactory($http, AuthenticationFactory) {
        var service = {
            getAll: getAll,
            getById: getById,
            add: add,
            update: update,
            remove: remove
        };

        return service;

        function getAll() {
            return $http.get("/api/Residence/GetAll", {
                headers: {
                    "Authorization": AuthenticationFactory.getToken()
                }
            });
        }

        function getById(id) {
            return $http.get("/api/Residence/GetById/" + id, {
                headers: {
                    "Authorization": AuthenticationFactory.getToken()
                }
            });
        }

        function add(residence) {
            return $http.post("/api/Residence/Add", residence, {
                headers: {
                    "Authorization": AuthenticationFactory.getToken()
                }
            });
        }

        function update(residence) {
            return $http.put("/api/Residence/Update", residence, {
                headers: {
                    "Authorization": AuthenticationFactory.getToken()
                }
            });
        }

        function remove(id) {
            return $http.delete("/api/Residence/Delete/" + id, {
                headers: {
                    "Authorization": AuthenticationFactory.getToken()
                }
            });
        }
    }
})();