$(document).ready(function () {
    $('#submitKeyButton').click(function () {
        if ($('#keyTextBox') == '') {
            alert('Enter a key.');
        }
        else {
            secureLogin($('#keyTextBox').val())
            //window.location.href = getBaseUrl('home', 'index') + '?key=' + $('#keyTextBox').val();
        }
    });
});

function secureLogin(key) {
    var url = getBaseUrl('login', 'SecureLogin') + '?key=' + key;
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: url,
        dataType: "json",
        success: function (response) {
            window.location.href = getBaseUrl('home', 'index');
        },
        error: function (xhr, err) {
            handleAjaxError(xhr, error);
        }
    });
}