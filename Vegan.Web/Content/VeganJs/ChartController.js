(function myfunction() {
    var ChartProject = angular.module("ChartProject", []);
    var ordersURL = "https://localhost:44304/api/OrdersAPI";
    var ChartController = function ($scope, $http) {
        var GetData = function () {
            $http.get(ordersURL)
                .then(function (response) {

                    //Declare the arrays
                    var yearArray = [];
                    //var totalArray = [];
                   
                    for (var i = 0; i < response.data.length; i++) {
                        $scope.Orders = response.data;

                        //Make year into an int
                        var year = yearArray.push(parseInt(response.data[i].OrderStamp.split("-")[0]));
                    }

                    //Find the unique years, put them in an array and sort them
                    function onlyUnique(value, index, self) {
                        return self.indexOf(value) === index;
                    }

                    var unique = yearArray.filter(onlyUnique);
                    unique.sort();
                    $scope.years = unique;

                    var yearlyTotalArray = [];
                    var yearlyTaxTotalArray = [];
                    var taxArray = [];
                    var priceArray = [];
                    var ordersIDArray = [];

                    //Check the orders for every year
                    for (var t = 0; t < unique.length; t++) {

                        //Calculate the total for every year
                        var yearlyTotal = 0;
                        var taxYearlyTotal = 0;
                        for (var i = 0; i < response.data.length; i++) {
                            //Find the total
                            if (unique[t] === parseInt(response.data[i].OrderStamp.split("-")[0])) {
                                //Yearly total
                                yearlyTotal = yearlyTotal + response.data[i].Total;
                                //Tax Total
                                taxYearlyTotal = taxYearlyTotal + response.data[i].Tax;
                                //Price array
                                priceArray.push(response.data[i].Price);
                               
                            }
                            

                            //Calculate tax
                            taxArray.push(taxYearlyTotal)
                            //Collect orders
                            ordersIDArray.push(response.data[i].OrderId)
                           

                        }
                        //Create an array with the totals
                        yearlyTotalArray.push(yearlyTotal);
                        yearlyTaxTotalArray.push(taxYearlyTotal)
                       
                    }
                   
                    //Total
                    $scope.totalsPerYear = yearlyTotalArray;
                    //TaxTotal
                    $scope.taxTotalsPerYear = yearlyTaxTotalArray;
                    //Price
                    $scope.price = priceArray;
                    //Orders
                    $scope.orders = ordersIDArray;

                    demo.initDashboardPageCharts($scope.years, $scope.totalsPerYear, $scope.taxTotalsPerYear, $scope.price, $scope.orders);


                });
        }
        GetData();
    };
  ChartProject.controller("ChartController", ChartController);
})();