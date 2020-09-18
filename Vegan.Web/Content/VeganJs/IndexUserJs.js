$(function () {
    //Change the min attribute of maxPrice to be equal with the current minPrice 
    $("#minPrice").change(() => {
        var minPrice = $("#minPrice").val();
        $("#maxPrice").attr("min", minPrice);
    });
});