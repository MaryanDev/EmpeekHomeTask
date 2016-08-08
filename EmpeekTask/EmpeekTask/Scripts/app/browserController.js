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
        $scope.itemsErrorMessage = "";
        $scope.fileSizeErrorMessage = "";
        $scope.isLoading = false;

        activate();

        function activate() {

            browserService.getDrives()
                .then(function (response) {
                    $scope.browserItems = response.data.BrowserItems;
                    $scope.currentPath = response.data.CurrentPath;
                });
            

        };

        $scope.getData = function (basePath, selectedItem) {
            getObjects(basePath, selectedItem);
            sortFilesBySize(basePath, selectedItem);
        };

        function getObjects(basePath, selectedItem) {
            browserService.getObjects(basePath, selectedItem)
                .then(function (response) {
                    $scope.browserItems = response.data.BrowserItems;
                    $scope.currentPath = response.data.CurrentPath;
                    $scope.itemsErrorMessage = "";
                    //localStorage.setItem("browserItems", $scope.browserItems);
                    //localStorage.setItem("currentPath", $scope.currentPath);
                }, function errorCallback(response) {
                    $scope.itemsErrorMessage = response.data;
                    resetSizeFiles();
                });
        };

        function sortFilesBySize(basePath, selectedItem) {
            $scope.isLoading = true;
            $scope.fileSizeErrorMessage = "";
            $scope.itemsErrorMessage = "";
            browserService.sortFilesBySize(basePath, selectedItem)
                .then(function (response) {
                    $scope.smallFiles = response.data.SmallFiles;
                    $scope.mediumFiles = response.data.MediumFiles;
                    $scope.largeFiles = response.data.LargeFiles;
                    $scope.fileSizeErrorMessage = "";
                    $scope.isLoading = false;
                    //localStorage.setItem("smallFiles", $scope.smallFiles);
                    //localStorage.setItem("mediumFiles", $scope.mediumFiles);
                    //localStorage.setItem("largeFiles", $scope.largeFiles);
                }, function errorCallback(response) {
                    $scope.fileSizeErrorMessage = response.data;
                    resetSizeFiles();
                    $scope.isLoading = false;
                });
        }

        function resetSizeFiles() {
            $scope.smallFiles = 0;
            $scope.mediumFiles = 0;
            $scope.largeFiles = 0;
            localStorage.setItem("")
        };
    };
})(angular);