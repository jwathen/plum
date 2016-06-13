'use strict';

$(function () {
    var udpateCustomerViewQueueList = function udpateCustomerViewQueueList() {
        $('#customerViewQueueList').load(window.viewData.udpateCustomerViewQueueListUrl);
    };

    var updateHub = $.connection.updateHub;
    updateHub.client.queueUpdated = udpateCustomerViewQueueList;

    $.connection.hub.start().done(function () {
        updateHub.server.subscribeToQueueAsCustomer(window.viewData.urlToken);
    });

    setInterval(udpateCustomerViewQueueList, 60000);
});

