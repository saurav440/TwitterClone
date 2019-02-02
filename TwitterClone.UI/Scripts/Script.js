function disablePage() {
    $('body').css('cursor', 'progress');
    $('#page-container').fadeTo('slow', 0.5, function () {
    });
    $('#page-container :input').attr('disabled', true);
    $('button').attr('disabled', true);
}

function enablePage() {
    $('body').css('cursor', 'default');
    $('#page-container').fadeTo('slow', 1, function () {
    });
    $('#page-container :input').attr('disabled', 'disabled');
    $('button').attr('disabled', 'disabled');
}