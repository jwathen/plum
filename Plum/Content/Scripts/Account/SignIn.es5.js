'use strict';

$(function () {
    var $emailAddress = $('#EmailAddress');
    if ($emailAddress.length && !$emailAddress.val() && window.localStorage && window.localStorage.emailAddress) {
        $emailAddress.val(window.localStorage.emailAddress);
    }

    $('#signInForm').submit(function () {
        if ($emailAddress.length && window.localStorage) {
            window.localStorage.setItem('emailAddress', $emailAddress.val());
        }
    });
});

