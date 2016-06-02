'use strict';

$(function () {
    $('[data-manage-customer-id]').click(function (e) {
        setLoading();
        var customerId = $(this).attr('data-manage-customer-id');
        $('#ManageCustomerModal').load(window.viewData.manageCustomerModalUrl + '?customerId=' + customerId, function () {
            clearLoading();
            $('#ManageCustomerModal').modal('show');
        });
    });
});

