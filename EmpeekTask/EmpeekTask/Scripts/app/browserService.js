(function (angular) {
    angular
        .module("browserModule")
        .factory("browserService", browserService);

    browserService.$inject = ["$http"];

    function browserService($http) {

        var service = {

        };

        return service;
    }
})(angular);