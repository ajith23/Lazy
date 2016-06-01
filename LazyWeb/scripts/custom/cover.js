$(document).ready(function () {

    if (window.location.pathname.toLowerCase().indexOf('edit') > -1)
    {
        var editTemplateId = getUrlParameter('id');
        if (editTemplateId != 0) {
            fetchCoverTemplates(editTemplateId);
            $('#coverVersionSelect').val(editTemplateId);
            $('#currentVersionNameText').val($('#coverVersionSelect option:selected').text());
        }
    }
    else
        fetchCoverTemplates(1);
    
    $('#coverVersionSelect').change(function() {
        if ($(this).val() === 0)
            $('#currentVersionNameText').val('');
        else
            $('#currentVersionNameText').val($('#coverVersionSelect option:selected').text());
        fetchCoverTemplates($(this).val());
    });

    $('#editTemplateButton').click(function () {
        var selectedTempelateId = $('#coverVersionSelect').val();
        window.location.href = "/cover/edit?id=" + selectedTempelateId;
    });
    $('#createTemplateButton').click(function () {
        window.location.href = "/cover/edit?id=0";
    });

});

function fetchCoverTemplates(id)
{
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: "/cover/FetchCoverTemplate?id=" + id,
        dataType: "json",
        success: function(response){
            var decodedData = $("<div/>").html(response.Template).text();
            if (window.location.pathname.toLowerCase().indexOf('edit') > -1)
                tinymce.get('coverTemplate').getBody().innerHTML = decodedData;
            $('#coverTemplateDiv').html(decodedData);
            updateFields(decodedData);
        },
        error: function (xhr, err) {
            alert("readyState: " + xhr.readyState + "\nstatus: " + xhr.status);
            alert("responseText: " + xhr.responseText);
        }
    });
}

function updateFields(decodedData)
{
    var updatedData = decodedData //str.replace(/microsoft/i, "W3Schools");
    var fields = (decodedData.match(/{([^}]*)}/gi));
    var htmlString = '';
    var fieldMap = {};
    $.map(fields, function (e, i) {
        fieldMap[e] = (fieldMap[e] || 0) + 1;
    });

    $.each(fieldMap, function (index, value) {
        var plainName = index.substring(1, index.length - 1).replace(/[^a-zA-Z0-9]/g, "_");
        if (value < 2)
            updatedData = updatedData.replace(index, '<span class="' + plainName + 'Span coverfieldEmpty">' + index + '</span>')
        else
            updatedData = updatedData.replace(new RegExp(index, "g"), '<span class="' + plainName + 'Span coverfieldEmpty">' + index + '</span>')

        htmlString += getFormGroupHtml(index.substring(1, index.length - 1), plainName);
    });

    $('#coverTemplateDiv').html(updatedData);

    $('#fieldAreaDiv').html(htmlString);
    $('.coverField').keyup(function () {
        var spanId = $(this).attr('id').replace('TextBox', 'Span');
        $('.' + spanId).html($(this).val());

        if ($(this).val()) {
            $('.' + spanId).removeClass('coverfieldEmpty');
        }
        else {
            $('.' + spanId).html('{' + spanId.replace('Span', '') + '}');
            $('.' + spanId).addClass('coverfieldEmpty');
        }
        //alert(spanId);
        //alert($(this).val());
    });
}
//var res = str.match(/{([^}]*)}/gi);

function getFormGroupHtml(fieldName, plainName)
{
    var htmlString = '';
    
    htmlString += '<div class="form-group">';
    htmlString += '  <label for="'+plainName+ 'TextBox">' + fieldName + '</label>';
    htmlString += '  <input type="text" class="form-control coverField" id="' + plainName + 'TextBox">';
    htmlString += '</div>';

    return htmlString;
}

function getUrlParameter(sParam) {
    var sPageURL = decodeURIComponent(window.location.search.substring(1)),
        sURLVariables = sPageURL.split('&'),
        sParameterName,
        i;

    for (i = 0; i < sURLVariables.length; i++) {
        sParameterName = sURLVariables[i].split('=');

        if (sParameterName[0] === sParam) {
            return sParameterName[1] === undefined ? true : sParameterName[1];
        }
    }
};