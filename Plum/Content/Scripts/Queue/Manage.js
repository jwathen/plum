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
        var customerId = $(this).attr('data-manage-customer-id');
        if (!isNaN(customerId)) {
            setLoading();
            $('#ManageCustomerModal').load(window.viewData.manageCustomerModalUrl + '?customerId=' + customerId, function () {
                clearLoading();
                $('#ManageCustomerModal').modal('show');
            });
        }
    });

    if ($('#businessViewQueueList .list-group-item').length > 1) {
        $('#businessViewQueueList .list-group').sortable({ delay: 100 }).on('sort', $.debounce(window.viewData.sortingDebounce, function (e, ui) {
            var customerIds = [];
            $('#businessViewQueueList li[data-manage-customer-id]').each(function () {
                var customerId = $(this).attr('data-manage-customer-id');
                if (!isNaN(customerId)) {
                    customerIds.push(parseInt(customerId));
                }
            });
            var data =  {
                customerIds: customerIds,
                '__RequestVerificationToken': $('input[name="__RequestVerificationToken"]').val()
            };
            $.post(window.viewData.sortQueueUrl, data);
        }));
    }
}