'use strict';

$(function () {
    $('[data-help-for]').each(function () {
        var $helpContent = $(this);
        var inputId = '#' + $helpContent.attr('data-help-for');
        $(inputId).focus(function () {
            $('[data-help-for]').hide();
            $helpContent.show();
        });
    });

    $('[data-colorbox-for]').each(function () {
        var $colorBox = $(this);
        var inputId = '#' + $colorBox.attr('data-colorbox-for');
        $(inputId).change(function () {
            $colorBox.css('background-color', $(inputId).val());
        });
        $(inputId).change();
    });
});

