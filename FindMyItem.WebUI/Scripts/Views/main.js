$(document).ready(function () {
    if ($("#searchResults").is(":visible")) {
        $("#btnSearchAgain").show();
        $("#frmSearch").hide();
    }
    else {
        $("#btnSearchAgain").hide();
        $("#frmSearch").show();
    }    
});

function ToggleSearch() {
    if ($("#frmSearch").is(":visible")) {
        $("#btnSearchAgain").html("Search Again!");
        $("#frmSearch").slideUp("slow");
    }
    else {
        $("#btnSearchAgain").html("Hide");
        $("#frmSearch").slideDown("slow");
    }
}

function Search() {
    debugger;

    var item = $('#Item').val();

    $.ajax({
        async: true,
        type: "POST",
        url: "http://findmyitem.co.uk/Services/Service.svc/soap/Search",
        data: "{ categoryID: 1, item: '" + item + "' }",
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (result) {
            debugger;
            alert(result.d);
        },
        error: function (result) {
            debugger;
        }
    });
}

//'{"userName":"' + $get("txtName").value + '"}' processData: false,  ?categoryID=1&item=ble         crossDomain: true,