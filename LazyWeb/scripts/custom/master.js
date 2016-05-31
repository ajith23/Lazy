$(document).ready(function () {
    var url = $(location).attr('href');
    $(".nav").find(".active").removeClass("active");
    $("a").each(function(){
        if (url.indexOf($(this).attr('href').toLowerCase()) >= 0) {
            $(this).parent().addClass("active");
        }
    });
    
});
