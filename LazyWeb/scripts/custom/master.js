$(document).ready(function () {
    var url = $(location).attr('href');
    $(".nav").find(".active").removeClass("active");
    $("a").each(function(){
        if (url.indexOf($(this).attr('href').toLowerCase()) >= 0) {
            $(this).parent().addClass("active");
        }
    });
    
    $('#lazyLogoutLink').click(function () {
        secureLogout();
    });

});

function secureLogout() {
    var url = getBaseUrl('login', 'SecureLogout');
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: url,
        dataType: "json",
        success: function (response) {
            window.location.href = getBaseUrl('error', 'index') + '?error= You have been logged out.';
        },
        error: function (xhr, err) {
            handleAjaxError(xhr, error);
        }
    });
}
