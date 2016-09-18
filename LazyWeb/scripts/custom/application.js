$(document).ready(function () {
    $('.applicationStatusCheckBoxClass').change(function () {
        var status = $(this).is(":checked");
        var companyName = $(this).parent().parent().children().first().html();
        updateApplicationStatus(companyName, status);
    });
});

function updateApplicationStatus(companyName, applied) {
    var url = getBaseUrl('application', 'UpdateApplicationStatus') + '?companyName=' + companyName;
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ companyName: companyName, applied: applied }),
        url: url,
        dataType: "json",
        success: function (response) {
            alert(response);
            //window.location.href = getBaseUrl('application', 'index');
        },
        error: function (xhr, error) {
            handleAjaxError(xhr, error);
        }
    });
}