
function InfoMessage(message) {
    $('.ShowInfo').empty();
    $('.ShowInfo').html(message);
    $('.ShowInfo').show();
    setTimeout(function () {
        $('.ShowInfo').fadeOut();
    }, 5000);
}

//switch off autocomplete features
$('input[name="password"]').attr('autocomplete', 'off');
$('input[name="text"]').attr('autocomplete', 'off');

$(function () {
    $('#dynamicloader').addClass('hide');
});

$(document).submit(function () {
    $('#btnSubmit').hide();
    $('#dynamicloader').removeClass('hide');
    var userTime = new Date();
    var timezone = userTime.getTimezoneOffset();
    $('#browsertimeoffset').val(timezone);
});