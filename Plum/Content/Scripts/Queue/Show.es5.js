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
    $('[data-show-customer-id]').click(function (e) {
        var customerId = $(this).attr('data-show-customer-id');
        if (!isNaN(customerId)) {
            setLoading();
            $('#ShowCustomerModal').load(window.viewData.showCustomerUrl + '/' + customerId, function () {
                clearLoading();
                $('#ShowCustomerModal').modal('show');
            });
        }
    });

    return;
    if ($('#businessViewQueueList .list-group-item').length > 1) {
        $('#businessViewQueueList .list-group').sortable({ delay: 100 }).on('sort', $.debounce(window.viewData.sortingDebounce, function (e, ui) {
            var customerIds = [];
            $('#businessViewQueueList li[data-show-customer-id]').each(function () {
                var customerId = $(this).attr('data-show-customer-id');
                if (!isNaN(customerId)) {
                    customerIds.push(parseInt(customerId));
                }
            });
            var data = {
                customerIds: customerIds,
                '__RequestVerificationToken': $('input[name="__RequestVerificationToken"]').val()
            };
            $.post(window.viewData.sortQueueUrl, data);
        }));
    }
}

