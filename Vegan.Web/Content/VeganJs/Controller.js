
(function myfunction() {
    var VeganProject = angular.module("VeganProject", ['angularUtils.directives.dirPagination']);


    //============================================== VeganController =======================================================
    var productsPerCategoryUrl = "/api/CategoriesAPI";
    var VeganController = function ($scope, $http) {
        var GetData = function (sortingTitle = true, sortingPrice = true, sortedProducts = null, pageSize) {
            $http.get(productsPerCategoryUrl)
                .then(function (response) {
                    $scope.Care = response.data[0];
                    $scope.FoodHerbs = response.data[1];
                    $scope.Homes = response.data[2];
                    $scope.Supplements = response.data[3];
                    if (sortedProducts == null) {
                        $scope.AllProducts = $scope.Care.concat($scope.FoodHerbs).concat($scope.Homes).concat($scope.Supplements);
                    }
                    else {
                        $scope.AllProducts = sortedProducts;
                    }
                    $scope.NumberOfProducts = $scope.AllProducts.length;
                    $scope.PageSize = pageSize ?? 12;

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

                    //sorting-btn
                    if (sortingTitle == true) {
                        $("#sortButtonTitle").click(() => {
                            $("#applyButton").off();
                            $("#sortButtonPrice").off();
                            $("#sortButtonTitle").off();
                            $("#pageSizeAllProducts").off();
                            sortedProducts = $scope.AllProducts.sort((a, b) => {
                                var keyA = a.Title;
                                var keyB = b.Title;
                                if (keyA < keyB) return -1;
                                if (keyA > keyB) return 1;
                                return 0;
                            });
                            console.log("sortButtonTitleIf");

                            sortingTitle = false;
                            GetData(sortingTitle, sortingPrice, sortedProducts, pageSize);
                        });
                    }
                    else {
                        $("#sortButtonTitle").click(() => {
                            $("#applyButton").off();
                            $("#sortButtonPrice").off();
                            $("#sortButtonTitle").off();
                            $("#pageSizeAllProducts").off();
                            sortedProducts = $scope.AllProducts.sort((a, b) => {
                                var keyA = a.Title;
                                var keyB = b.Title;
                                if (keyA > keyB) return -1;
                                if (keyA < keyB) return 1;
                                return 0;
                            });
                            console.log("sortButtonTitleElse");

                            sortingTitle = true;
                            GetData(sortingTitle, sortingPrice, sortedProducts, pageSize);
                        });
                    }

                    if (sortingPrice == true) {
                        $("#sortButtonPrice").click(() => {
                            $("#applyButton").off();
                            $("#sortButtonPrice").off();
                            $("#sortButtonTitle").off();
                            $("#pageSizeAllProducts").off();
                            sortedProducts = $scope.AllProducts.sort((a, b) => {
                                var keyA = a.Price;
                                var keyB = b.Price;
                                if (keyA < keyB) return -1;
                                if (keyA > keyB) return 1;
                                return 0;
                            });
                            console.log("sortButtonPriceIf");

                            sortingPrice = false;
                            GetData(sortingTitle, sortingPrice, sortedProducts, pageSize);
                        });
                    }
                    else {
                        $("#sortButtonPrice").click(() => {
                            $("#applyButton").off();
                            $("#sortButtonPrice").off();
                            $("#sortButtonTitle").off();
                            $("#pageSizeAllProducts").off();
                            sortedProducts = $scope.AllProducts.sort((a, b) => {
                                var keyA = a.Price;
                                var keyB = b.Price;
                                if (keyA > keyB) return -1;
                                if (keyA < keyB) return 1;
                                return 0;
                            });
                            console.log("sortButtonPriceElse");

                            sortingPrice = true;
                            GetData(sortingTitle, sortingPrice, sortedProducts, pageSize);
                        });
                    }

                    //Price filtering btn
                    $("#applyButton").click(function ApplyButton() {
                        $("#sortButtonPrice").off();
                        $("#sortButtonTitle").off();
                        $("#pageSizeAllProducts").off();
                        var minPrice = $("#minPrice").val();
                        var maxPrice = $("#maxPrice").val();

                        var products = $scope.Care.concat($scope.FoodHerbs).concat($scope.Homes).concat($scope.Supplements);
                        var filteringProducts = [];
                        if (minPrice != "" && maxPrice != "") {
                            if (maxPrice == 0) {
                                maxPrice = 10000000;
                            }

                            if (minPrice <= maxPrice) {
                                products.forEach((product) => {
                                    if (product.Price >= minPrice && product.Price <= maxPrice) {
                                        filteringProducts.push(product);
                                    }
                                })
                                $("#applyButton").off();
                                GetData(sortingTitle, sortingPrice, filteringProducts, pageSize);
                            }
                        }
                        else if (minPrice != "") {
                            products.forEach((product) => {
                                if (product.Price >= minPrice) {
                                    filteringProducts.push(product);
                                }
                            })
                            $("#applyButton").off();
                            GetData(sortingTitle, sortingPrice, filteringProducts, pageSize);
                        }
                        else if (maxPrice != "") {
                            products.forEach((product) => {
                                if (product.Price <= maxPrice) {
                                    filteringProducts.push(product);
                                }
                            })
                            $("#applyButton").off();
                            GetData(sortingTitle, sortingPrice, filteringProducts, pageSize);
                        }
                        else {
                            $("#applyButton").off();
                            GetData(sortingTitle, sortingPrice, products, pageSize);
                        }

                        //Insert information about the price filter
                        if (filteringProducts.length > 0) {
                            if (minPrice == "") {
                                $("#priceInformation").html("Min Price: " + 0 + "&nbsp;" + "&nbsp;" + "&nbsp;" + "&nbsp;" + "Max Price: " + maxPrice +
                                    "&nbsp;" + "&nbsp;" + "&nbsp;" + "&nbsp;" +
                                    "<button class=\"btn\" id=\"btnReset\">Reset</button>"
                                );
                                $("#btnReset").click(() => {
                                    $("#applyButton").off();
                                    $("#btnReset").off();
                                    GetData(sortingTitle, sortingPrice, products, pageSize);
                                    $("#priceInformation").empty();
                                    console.log("Reset");
                                });
                            }
                            else if (maxPrice == "" || maxPrice == 10000000) {
                                $("#priceInformation").html("Min Price: " + minPrice + "&nbsp;" + "&nbsp;" + "Max Price: " + "&infin;" +
                                    "&nbsp;" + "&nbsp;" + "&nbsp;" + "&nbsp;" +
                                    "<button class=\"btn\" id=\"btnReset\">Reset</button>"
                                );
                                $("#btnReset").click(() => {
                                    $("#applyButton").off();
                                    $("#btnReset").off();
                                    GetData(sortingTitle, sortingPrice, products, pageSize);
                                    $("#priceInformation").empty();
                                    console.log("Reset");
                                });
                            }
                            else {
                                $("#priceInformation").html("Min Price: " + minPrice + "&nbsp;" + "&nbsp;" + "Max Price: " + maxPrice +
                                    "&nbsp;" + "&nbsp;" + "&nbsp;" + "&nbsp;" +
                                    "<button class=\"btn\" id=\"btnReset\">Reset</button>"
                                );
                                $("#btnReset").click(() => {
                                    $("#applyButton").off();
                                    $("#btnReset").off();
                                    GetData(sortingTitle, sortingPrice, products, pageSize);
                                    $("#priceInformation").empty();
                                    console.log("Reset");
                                });
                            }
                        }
                        else {
                            $("#priceInformation").empty();
                        }
                        console.log("applButton");
                    })

                    //Page Size
                    $("#pageSizeAllProducts").change(() => {
                        $("#applyButton").off();
                        $("#sortButtonPrice").off();
                        $("#sortButtonTitle").off();
                        $("#pageSizeAllProducts").off();
                        var value = $("#pageSizeAllProducts").val();
                        console.log("pageSize : " + value);
                        $scope.PageSize = value;
                        GetData(sortingTitle, sortingPrice, sortedProducts, value);
                    })

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