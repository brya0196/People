(function () {
    'use strict';

    angular
        .module('app')
        .directive('residentForm', residentForm);

    residentForm.$inject = ['$window'];

    function residentForm($window) {
        // Usage:
        //     <resident_form></resident_form>
        // Creates:
        // 
        var directive = {
            link: link,
            restrict: 'E',
            scope: {
                resident: '=',
                form: '='
            },
            templateUrl: '/angular/common/directives/resident-form/resident-form.html'
        };
        return directive;

        function link(scope, element, attrs) {
            
        }
    }

})();