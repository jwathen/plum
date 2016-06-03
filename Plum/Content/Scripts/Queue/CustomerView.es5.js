'use strict';

$(function () {
    var updateHub = $.connection.updateHub;
    updateHub.client.queueUpdated = function () {
        console.log('updated!');
        $('#customerViewQueueList').load(window.viewData.udpateCustomerViewQueueListUrl);
    };

    $.connection.hub.start().done(function () {
        updateHub.server.subscribeToQueueAsCustomer(window.viewData.urlToken);
    });
});

