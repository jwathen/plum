'use strict';

$(function () {
    $('[data-manage-customer-id]').click(function (e) {
        var customerId = $(this).attr('data-manage-customer-id');
        $('#ManageCustomerModal .modal-content').load(window.viewData.manageCustomerModalUrl + '?customerId=' + customerId, function () {
            $('#ManageCustomerModal').modal('show');
        });
    });
});

