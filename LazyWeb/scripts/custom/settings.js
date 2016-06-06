$(document).ready(function () {
    loadSettings();
    $('#saveSettingsButton').click(function () {
        saveSettings();
    });
});

function loadSettings()
{
    var url = getBaseUrl('settings', 'GetSettings');
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: url,
        dataType: "json",
        success: function (response) {
            $('#pageSizeDropdown').val(response.size);
            $('#pageOrientationDropdown').val(response.orientation);
            $('#pageMarginTextBox').val(response.margin);
        },
        error: function (xhr, error) {
            handleAjaxError(xhr, error);
        }
    });
}

function saveSettings() {
    var url = getBaseUrl('settings', 'SaveSettings');
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: url,
        data: JSON.stringify({ size: $('#pageSizeDropdown option:selected').val(), orientation: $('#pageOrientationDropdown option:selected').val(), margin: $('#pageMarginTextBox').val() }),
        dataType: "json",
        success: function (response) {
            alert(response);
        },
        error: function (xhr, error) {
            handleAjaxError(xhr, error);
        }
    });
}