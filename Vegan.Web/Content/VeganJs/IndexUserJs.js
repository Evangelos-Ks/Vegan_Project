$(function () {
    //Add eventListener -> Change the min attribute of maxPrice to be equal with the current minPrice 
    $("#minPrice").change(() => {
        var minPrice = $("#minPrice").val();
        if (minPrice === "") {
            $("#maxPrice").attr("min", 1);
        }
        else if (minPrice == 0) {
            $("#maxPrice").attr("min", 1);
        }
        else {
            $("#maxPrice").attr("min", minPrice);
        }
    });

    //Add eventListener -> Submit
    $("#pageSize").change(() => {
        $("#form").submit();
    })
});