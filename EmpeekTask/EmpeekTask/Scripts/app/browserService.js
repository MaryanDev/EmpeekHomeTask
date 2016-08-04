(function (angular) {
    angular
        .module("browserModule")
        .factory("browserService", browserService);

    browserService.$inject = ["$http"];

    function browserService($http) {

        var service = {
            getDrives: getDrivesAjax
        };

        return service;

        function getDrivesAjax() {
            var promise = $http({
                method: "GET",
                url: "/api/browser"
            });

            return promise;
        };
    }
})(angular);