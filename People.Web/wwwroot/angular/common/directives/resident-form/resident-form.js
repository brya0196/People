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
            templeteUrl: '/angular/common/directives/resident-form.html'
        };
        return directive;

        function link(scope, element, attrs) {
        }
    }

})();