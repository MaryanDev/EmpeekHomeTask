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
                    $scope.smallObjects = response.data.SmallObjects;
                    $scope.mediumObjects = response.data.MediumObjects;
                    $scope.largeObjects = response.data.LargeObjects;
                    $scope.currentPath = response.data.CurrentPath;
                });
        };
    };
})(angular);