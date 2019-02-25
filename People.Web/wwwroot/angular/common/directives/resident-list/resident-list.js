(function () {
    'use strict';

    angular
        .module('app')
        .directive('resident_list', resident_list);

    resident_list.$inject = ['$window'];

    function resident_list($window) {
        // Usage:
        //     <residents_list></residents_list>
        // Creates:
        // 
        var directive = {
            link: link,
            restrict: 'E',
            scope: {
                residents: '='
            },
            templateUrl: '/angular/common/directives/resident-list/resident-list'
        };
        return directive;

        function link(scope, element, attrs) {
        }
    }

})();