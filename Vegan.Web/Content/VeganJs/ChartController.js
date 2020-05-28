(function myfunction() {
    var ChartProject = angular.module("ChartProject", []);
    var ordersURL = "https://localhost:44332/api/Orders";
    var ChartController = function ($scope, $http) {
        var GetData = function () {
            $http.get(ordersURL)
                .then(function (response) {

                    //Declare the arrays
                    var yearArray = [];
                    var totalArray = [];
                   
                    for (var i = 0; i < response.data.length; i++) {
                        $scope.Orders = response.data;
                        console.log(response.data);
                        console.log(response.data[i].Total);

                        //Make year into an int
                        var year = yearArray.push(parseInt(response.data[i].OrderStamp.split("-")[0]));
                    }
                    console.log(yearArray);

                    //Find the unique years, put them in an array and sort them
                    function onlyUnique(value, index, self) {
                        return self.indexOf(value) === index;
                    }
                    var unique = yearArray.filter(onlyUnique);
                    unique.sort();
                    $scope.years = unique;

                    var yearlyTotalArray = [];
                    //Check the orders for every year
                    for (var t = 0; t < unique.length; t++) {
                        //Calculate the total for every year
                        var yearlyTotal = 0;
                        for (var i = 0; i < response.data.length; i++) {
                            if (unique[t] === parseInt(response.data[i].OrderStamp.split("-")[0])) {
                                yearlyTotal = yearlyTotal + response.data[i].Total;
                            }
                        }
                        //Create an array with the totals
                        yearlyTotalArray.push(yearlyTotal);
                    }
                    $scope.totalsPerYear = yearlyTotalArray;
                });
        }
        GetData();
    };
  ChartProject.controller("ChartController", ChartController);
})();