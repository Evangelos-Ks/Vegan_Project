(function myfunction() {
    var VeganProject = angular.module("VeganProject", []);

    var productsPerCategoryUrl = "https://localhost:44332/api/Categories";

    var VeganController = function ($scope, $http) {
        var GetData = function () {
            $http.get(productsPerCategoryUrl)
                .then(function (response) {
                    $scope.Care = response.data[0];
                    $scope.FoodHerbs = response.data[1];
                    $scope.Homes = response.data[2];
                    $scope.Supplements = response.data[3];
                    $scope.AllProducts = $scope.Care.concat($scope.FoodHerbs).concat($scope.Homes).concat($scope.Supplements);
                    console.log($scope.Care);
                    console.log($scope.FoodHerbs);
                    console.log($scope.Homes);
                    console.log($scope.Supplements);
                    console.log($scope.AllProducts);

                    //autocomplete
                    autocomplete(document.getElementById("searchlight"), AutocompleteItems($scope.Care));

                }, function myError(response) {
                    console.log(response);
                });

           
        }

        GetData();
    };

    VeganProject.controller("VeganController", VeganController);

})();