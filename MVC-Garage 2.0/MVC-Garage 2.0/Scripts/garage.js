$(document).ready(function () {

    var createAutocomplete = function () {
        var $input = $(this);

        var options = {
            source: $input.attr("data-garage-autocomplete")
        };

        $input.autocomplete(options);
    }

   

    var paging = function (){
        var page = parseInt($(this).html());

        $.ajax(
        {
            url: '/ParkedVehicles/Index?page=' + page,
            type: 'GET',
            data: "",
            jsonpCallback: 'callback',
            contentType: 'application/json; charset=utf-8',
            success: function (data) {
                $("#vehiclelist").html(data);
            },
            error: function () {
                alert("error");
            }
        });

        return false;
    };


    var printPage = function() {
        var printPage = window.open(document.URL, '_blank');
        setTimeout(printPage.print(), 5);        
        return true;
    }


    $("input[data-garage-autocomplete]").each(createAutocomplete);
    $(document).on("click", ".page-number", paging);
    $("#printReceipt").click(printPage);
    
})