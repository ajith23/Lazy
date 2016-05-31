$(document).ready(function () {
    $('#coverVersionSelect').change(function(){
        if ($(this).val() === 0)
        {
            $('#currentVersionNameText').val('');
            $('#coverTemplate').val($(this).val());
        }
        else
        {
            $('#currentVersionNameText').val($('#coverVersionSelect option:selected').text());
            tinymce.get('coverTemplate').getBody().innerHTML = $(this).val();
        }
    });
});

function fetchCoverTemplates(userId)
{
    $.ajax({
        url: 'cover/FetchCoverTemplates',
        data: { id: id }
    }).done(function () {
        alert('Added');
    });
}