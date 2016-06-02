function getBaseUrl(controller, method)
{
    return '/' + controller + '/' + method;
}

function handleAjaxError(xhr, error)
{
    alert("readyState: " + xhr.readyState + "\nstatus: " + xhr.status);
    alert("responseText: " + xhr.responseText);
}

function htmlEncode(value) {
    return $('<div/>').text(value).html();
}

function htmlDecode(value) {
    return $('<div/>').html(value).text();
}