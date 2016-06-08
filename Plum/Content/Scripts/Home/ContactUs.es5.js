'use strict';

$(function () {
    if (!$('.alert').length) {
        if (!$('#EmailAddress').val()) {
            $('#EmailAddress').focus();
        } else if (!$('#Message').val()) {
            $('#Message').focus();
        }
    }
});

