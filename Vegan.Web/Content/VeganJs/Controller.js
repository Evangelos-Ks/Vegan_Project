(function myfunction() {
    var VeganProject = angular.module("VeganProject", ['angularUtils.directives.dirPagination']);


    //============================================== VeganController =======================================================
    var productsPerCategoryUrl = "https://localhost:44304/api/CategoriesAPI";

    var VeganController = function ($scope, $http) {
        var GetData = function () {
            $http.get(productsPerCategoryUrl)
                .then(function (response) {
                    $scope.Care = response.data[0];
                    $scope.FoodHerbs = response.data[1];
                    $scope.Homes = response.data[2];
                    $scope.Supplements = response.data[3];
                    $scope.AllProducts = $scope.Care.concat($scope.FoodHerbs).concat($scope.Homes).concat($scope.Supplements);
                    $scope.NumberOfProducts = $scope.AllProducts.length;

                    //autocomplete
                    autocomplete(document.getElementById("searchlight"), AutocompleteItems($scope.AllProducts));

                    //search-btn
                    document.getElementById("searchbutton").addEventListener("click", function () {
                        var text = document.getElementById("searchlight").value;
                        var products = [];

                        for (var i in $scope.AllProducts) {

                            if (text == $scope.AllProducts[i].Title) {
                                if ($scope.AllProducts[i].SubCategory == "FaceCream") {
                                    var controller = $scope.AllProducts[i].SubCategory + "s";
                                }
                                else {
                                    var controller = $scope.AllProducts[i].SubCategory;
                                }
                                var detailsActionMethod = "Details" + $scope.AllProducts[i].SubCategory;
                                var id = $scope.AllProducts[i].Id;
                                var url = "/" + controller + "/" + detailsActionMethod + "?" + "productId=" + id;
                                window.location.href = url;
                            }
                        }

                    });

                    $scope.UrlBuilder = function UrlBuilder(product) {
                        if (product.SubCategory == "FaceCream") {
                            var controller = product.SubCategory + "s";
                        }
                        else {
                            var controller = product.SubCategory;
                        }
                        var detailsActionMethod = "Details" + product.SubCategory;
                        var id = product.Id;
                        var url = "/" + controller + "/" + detailsActionMethod + "?" + "productId=" + id;
                        window.location.href = url;
                    }

                }, function myError(response) {
                    console.log(response);
                });
        }
        GetData();
    };

    VeganProject.controller("VeganController", VeganController);
})();