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
        fetchCoverTemplates($('#coverVersionSelect').val());
    
    $('#coverVersionSelect').change(function() {
        if ($(this).val() === 0)
            $('#currentVersionNameText').val('');
        else
            $('#currentVersionNameText').val($('#coverVersionSelect option:selected').text());
        fetchCoverTemplates($(this).val());
    });

    $('#editTemplateButton').click(function () {
        var selectedTempelateId = $('#coverVersionSelect').val();
        window.location.href = getBaseUrl('cover', 'edit') + '?id=' + selectedTempelateId;
    });
    $('#createTemplateButton').click(function () {
        window.location.href = getBaseUrl('cover', 'edit') + '?id=0';
    });

    $('#cancelEditCoverButton').click(function () {
        if (confirm("Are you sure you would like to cancel? All your unsaved data will be lost.")) {
            window.location.href = getBaseUrl('cover', 'index');
        }
    });
    $('#saveEditCoverButton').click(function () {
        //validate form
        if ($('#currentVersionNameText').val().trim() === '') {
            alert('Ener a template version name. This is required so that you can identify your template using this name. Be very specific.');
            return;
        }
        saveEditCoverTemplate($('#coverVersionSelect').val());
    });

    $('#saveCoverButton').click(function () {
        var fieldEmpty = false;
        $('#coverFieldsPanelBody :input').each(function () {
            if($(this).val() === '') {
                fieldEmpty = true; 
            }
        });
        if (fieldEmpty) {
            if (confirm("Are you sure to download? Looks like some of the fields are empty. It would not look good in your cover letter !")) {
                savePdf($('#coverVersionSelect').val());
            }
        }
        else {
            savePdf($('#coverVersionSelect').val());
        }
    });
});

function fetchCoverTemplates(id)
{
    var url = getBaseUrl('cover', 'FetchCoverTemplate') + '?id=' + id;
    $.ajax({
        type: "GET",
        contentType: "application/json; charset=utf-8",
        url: url,
        dataType: "json",
        success: function(response){
            var decodedData = htmlDecode(response.Template);
            if (window.location.pathname.toLowerCase().indexOf('edit') > -1)
                tinymce.get('coverTemplate').getBody().innerHTML = decodedData;
            $('#coverTemplateDiv').html(decodedData);
            updateFields(decodedData);
        },
        error: function (xhr, err) {
            handleAjaxError(xhr, error);
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
    $('.coverField').focusout(function () {
        var spanId = $(this).attr('id').replace('TextBox', 'Span');
        $('.' + spanId).removeClass('coverfieldHighlight');
    });
    $('.coverField').focusin(function () {
        var spanId = $(this).attr('id').replace('TextBox', 'Span');
        //alert(spanId);
        $('.' + spanId).addClass('coverfieldHighlight');
    });
}

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

function saveEditCoverTemplate(id)
{
    var url = getBaseUrl('cover', 'SaveEditCoverTemplate') + '?id=' + id;
    var versionName = $('#currentVersionNameText').val();
    var template = htmlEncode(tinyMCE.get('coverTemplate').getContent());
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify({ id: id, version: versionName, template : template }),
        url: url,
        dataType: "json",
        success: function (response) {
            alert(response);
            window.location.href = getBaseUrl('cover', 'index');
        },
        error: function (xhr, error) {
            handleAjaxError(xhr, error);
        }
    });
}

function savePdf(id) {
    //alert('in progress');
    var cover = htmlEncode($('#coverTemplateDiv').html());
    var url = getBaseUrl('cover', 'GeneratePDF');
    $.ajax({
        type: "POST",
        contentType: "application/json; charset=utf-8",
        url: url,
        data: JSON.stringify({cover: cover}),
        //dataType: "application/pdf",
        success: function (response) {
            //alert(response);
            var downloadWindow = window.open("data:application/pdf;base64, " + response, '', 'height=650,width=840');
        },
        error: function (xhr, error) {
            handleAjaxError(xhr, error);
        }
    });
}