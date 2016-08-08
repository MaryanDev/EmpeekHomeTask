(function (angular) {
    angular
        .module("browserModule")
        .controller("alertModalController", alertModalController);

    alertModalController.$inject = ["$scope", "$uibModalInstance", "message"];

    function alertModalController($scope, $uibModalInstance, message) {
        $scope.message = message;
        $scope.ok = function () {
            $uibModalInstance.close();
        };
    };
})(angular);