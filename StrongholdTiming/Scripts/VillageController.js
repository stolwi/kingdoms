var ngKingdom = angular.module("ngKingdom", ['ngResource'])

ngKingdom.factory("Kingdom", function ($resource) {
    return {
        village: $resource("/api/villages")
    }
});

ngKingdom.controller("VillageController", function ($scope, Kingdom) {

    $scope.villages = Kingdom.village.query({}, isArray = true);
    //$scope.villages = [{ name: "Polaris", x: 0, y: 0 }, { name: "Sol", x: 0, y: 0}];

    $scope.addVillage = function () {
        var newVillage = new Kingdom.village({ name: $scope.name, x: 0, y: 0, world: 1 });
        newVillage.$save();
        $scope.villages.push(newVillage);
    }
    $scope.removeVillage = function (village) {

        if (confirm("Removing this village will also remove any connected edge data! Are you sure?")) {
            village.$delete({ id: village.id });
            $scope.villages.splice($scope.villages.indexOf(village), 1);
        }
    }
});
