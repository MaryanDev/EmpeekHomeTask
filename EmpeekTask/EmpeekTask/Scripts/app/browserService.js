(function (angular) {
    angular
        .module("browserModule")
        .factory("browserService", browserService);

    browserService.$inject = ["$http"];

    function browserService($http) {

        var service = {
            getDrives: getDrivesAjax,
            getObjects: getObjectsAjax
        };

        return service;

        function getDrivesAjax() {
            var promise = $http({
                method: "GET",
                url: "/api/browser"
            });

            return promise;
        };

        function getObjectsAjax(basePath, selectedItem) {
            var promise = $http({
                method: "GET",
                url: "/api/browser",
                params: {
                    basePath: basePath,
                    selectedItem: selectedItem
                }
            });

           return promise; 
        };
    }
})(angular);