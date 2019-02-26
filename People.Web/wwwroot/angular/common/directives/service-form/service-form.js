(function () {
    'use strict';

    angular
        .module('app')
        .directive('serviceForm', serviceForm);

    serviceForm.$inject = ['$window'];

    function serviceForm($window) {
        // Usage:
        //     <service-form></service-form>
        // Creates:
        // 
        var directive = {
            link: link,
            restrict: 'E',
            scope: {
                service: '='
            },
            templateUrl: '/angular/common/directives/service-form/service-form.html'
        };
        return directive;

        function link(scope, element, attrs) {
            
        }
    }

})();