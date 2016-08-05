(function (angular) {
    angular
        .module("browserModule")
        .controller("browserController", browserController);

    browserController.$inject = ["$scope", "browserService"];

    function browserController($scope, browserService) {

        $scope.browserItems = null;
        $scope.smallFiles = 0;
        $scope.mediumFiles = 0;
        $scope.largeFiles = 0;
        $scope.currentPath = "";
        $scope.errorMessage = "";

        activate();

        function activate() {
            browserService.getDrives()
                .then(function (response) {
                    $scope.browserItems = response.data.BrowserItems;
                    $scope.currentPath = response.data.CurrentPath;
                });
        };

        $scope.getData = function(basePath, selectedItem){
            getObjects(basePath, selectedItem);
            sortFilesBySize(basePath, selectedItem);
        };

        function getObjects(basePath, selectedItem) {
            browserService.getObjects(basePath, selectedItem)
                .then(function (response) {
                    $scope.browserItems = response.data.BrowserItems;
                    $scope.currentPath = response.data.CurrentPath;
                    $scope.errorMessage = "";
                }, function errorCallback(response) {
                    $scope.errorMessage += response.data;
                    resetSizeFiles();
                });
        };

        function sortFilesBySize(basePath, selectedItem) {
            browserService.sortFilesBySize(basePath, selectedItem)
                .then(function (response) {
                    $scope.smallFiles = response.data.SmallFiles;
                    $scope.mediumFiles = response.data.MediumFiles;
                    $scope.largeFiles = response.data.LargeFiles;
                    $scope.errorMessage = "";
                }, function errorCallback(response) {
                    $scope.errorMessage += response.data;
                    resetSizeFiles();
                });
        }

        function resetSizeFiles() {
            $scope.smallFiles = 0;
            $scope.mediumFiles = 0;
            $scope.largeFiles = 0;
        };
    };
})(angular);