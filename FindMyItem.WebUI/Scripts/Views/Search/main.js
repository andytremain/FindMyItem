$(document).ready(function () {
    $('#chkAdvancedSearch').click(function () {
        var elem = $('#advancedSearchWarning');

        if (elem.is(':visible'))
            $('#advancedSearchWarning').hide();
        else
            $('#advancedSearchWarning').show();
    });
});

function search(category, item) {

}