'use strict';

$(function () {
    initQueueList();

    var updateHub = $.connection.updateHub;
    updateHub.client.queueUpdated = function () {
        $('#businessViewQueueList').load(window.viewData.udpateBusinessViewQueueListUrl, function () {
            initQueueList();
        });
    };

    $.connection.hub.start().done(function () {
        updateHub.server.subscribeToQueueAsBusiness(window.viewData.queueId);
    });
});

function initQueueList() {
    $('[data-manage-customer-id]').click(function (e) {
        setLoading();
        var customerId = $(this).attr('data-manage-customer-id');
        $('#ManageCustomerModal').load(window.viewData.manageCustomerModalUrl + '?customerId=' + customerId, function () {
            clearLoading();
            $('#ManageCustomerModal').modal('show');
        });
    });
}

