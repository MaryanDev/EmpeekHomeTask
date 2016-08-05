(function (angular) {
    angular
        .module("browserModule")
        .controller("browserController", browserController);

    browserController.$inject = ["$scope", "browserService"];

    function browserController($scope, browserService) {

        $scope.browserItems = null;
        $scope.smallObjects = 0;
        $scope.mediumObjects = 0;
        $scope.largeObjects = 0;
        $scope.currentPath = "";

        activate();

        function activate() {
            browserService.getDrives()
                .then(function (response) {
                    console.log(response);

                    $scope.browserItems = response.data.BrowserItems;
                    $scope.smallObjects = 0;
                    $scope.mediumObjects = 0;
                    $scope.largeObjects = 0;
                    $scope.currentPath = response.data.CurrentPath;
                });
        };

        $scope.getObjects = function (basePath, selectedItem) {
            browserService.getObjects(basePath, selectedItem)
                .then(function (response) {
                    console.log(response.data);

                    $scope.browserItems = response.data.BrowserItems;
                    $scope.smallObjects = 0;
                    $scope.mediumObjects = 0;
                    $scope.largeObjects = 0;
                    $scope.currentPath = response.data.CurrentPath;
                }, function errorCallback(response) {
                    alert(response.data);
                });
        };
    };
})(angular);