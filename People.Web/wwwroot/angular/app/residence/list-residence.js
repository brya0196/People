(function () {
    'use strict';

    angular.module('app').component('listResidence', {
        templateUrl: '/angular/app/residence/list-residence.html',
        controller: ListController,
        controllerAs: 'vm'
    });

    ListController.$inject = ['$log', '$q', 'ResidenceFactory', 'PersonService', 'PersonService'];

    function ListController($log, $q, ResidenceFactory) {
        var vm = this;

        activate();


        function activate() {
            ResidenceFactory.getAll().then(function (response) {
                $log.debug(response);
                return response;
            });
        }
    }
})();