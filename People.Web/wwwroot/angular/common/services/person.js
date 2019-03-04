(function () {
    'use strict';

    angular
        .module('app')
        .factory('PersonaFactory', PersonaFactory);

    PersonaFactory.$inject = ['$http', 'AuthenticationFactory'];

    function PersonaFactory($http, AuthenticationFactory) {
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
            return $http.get("/api/Person/GetAll", {
                headers: {
                    "Authorization": AuthenticationFactory.getToken()
                }
            });
        }

        function getById(id) {
            return $http.get("/api/Person/GetById/" + id, {
                headers: {
                    "Authorization": AuthenticationFactory.getToken()
                }
            });
        }

        function getByIdResidence(id) {
            return $http.get("/api/Person/GetByIdResidence/" + id, {
                headers: {
                    "Authorization": AuthenticationFactory.getToken()
                }
            });
        }

        function add(person) {
            return $http.post("/api/Person/Add", person, {
                headers: {
                    "Authorization": AuthenticationFactory.getToken()
                }
            });
        }

        function addAll(people) {
            return $http.post("/api/Person/AddAll", people, {
                headers: {
                    "Authorization": AuthenticationFactory.getToken()
                }
            });
        }

        function update(person) {
            return $http.put("/api/Person/Update", person, {
                headers: {
                    "Authorization": AuthenticationFactory.getToken()
                }
            });
        }

        function remove(id) {
            return $http.delete("/api/Person/Delete/" + id, {
                headers: {
                    "Authorization": AuthenticationFactory.getToken()
                }
            });
        }
    }
})();