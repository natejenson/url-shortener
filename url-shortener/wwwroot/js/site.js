
$(function () {
    $('#copy-button').click(function () {
        copyHrefToClipboard($('#short-url'));
    });
});

function copyHrefToClipboard(element) {
    var $temp = $('<input>');
    $('body').append($temp);
    $temp.val($(element).attr('href')).select();
    document.execCommand('copy');
    $temp.remove();
}
