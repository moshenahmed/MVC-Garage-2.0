$(document).ready(function () {

    var createAutocomplete = function () {
        var $input = $(this);

        var options = {
            source: $input.attr("data-garage-autocomplete")
        };

        $input.autocomplete(options);
    }

    $("input[data-garage-autocomplete]").each(createAutocomplete);
})