(function (angular) {
    angular
        .module("browserModule")
        .factory("browserService", browserService);

    browserService.$inject = ["$http"];

    function browserService($http) {

        var service = {
            getDrives: getDrivesAjax,
            getDirectoryItems: getDirectoryItemsAjax,
            sortFilesBySize: sortFilesBySizeAjax
        };

        return service;

        function getDrivesAjax() {
            var promise = $http({
                method: "GET",
                url: "/api/browser"
            });

            return promise;
        };

        function getDirectoryItemsAjax(basePath, selectedItem) {
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

        function sortFilesBySizeAjax(basePath, selectedItem) {
            var promise = $http({
                method: "GET",
                url: "api/filesize",
                params: {
                    basePath: basePath,
                    selectedItem: selectedItem
                }
            });

            return promise;
        };
    }
})(angular);