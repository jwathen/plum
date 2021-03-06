﻿$(function () {
    initQueueList();

    var udpateBusinessViewQueueList = function () {
        // just return if the user is sorting the list
        if ($('#businessViewQueueList .list-group').sortable('option', 'disabled') === false) {
            return;
        }

        $('#businessViewQueueList').load(window.viewData.udpateBusinessViewQueueListUrl, function () {
            initQueueList();
        });
    }

    var updateHub = $.connection.updateHub;
    updateHub.client.queueUpdated = function (customerId) {
        udpateBusinessViewQueueList();
        
        // if customer modal is opened to customer and user is on "show customer" view then update the view
        if ($('#ShowCustomerModal').data('customerId') == customerId) {
            if ($('#ShowCustomerModal').find('h5').length) {
                $('#ShowCustomerModal').load(window.viewData.showCustomerUrl + '/' + customerId);
            }
        }
    }

    $.connection.hub.start().done(function () {
        updateHub.server.subscribeToQueueAsBusiness(window.viewData.queueId);
    });

    setInterval(udpateBusinessViewQueueList, 60000);

    $('[data-command=rearrange]').click(function () {
        var $list = $('#businessViewQueueList .list-group');

        if ($list.sortable('option', 'disabled')) {
            $list.sortable('option', 'disabled', false);
            $('[data-command=rearrange] span').text('Save List Order');
            $('#RearrangeListInstructions').show();
        }
        else {
            $list.sortable('option', 'disabled', true);
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
            setLoading();
            $.post(window.viewData.sortQueueUrl, data, function () {
                $('[data-command=rearrange] span').text('Reorder List');
                $('#RearrangeListInstructions').hide();
                clearLoading();
            });
        }
    });
});

function initQueueList() {
    $('[data-show-customer-id]').click(function (e) {
        // just return if the user is sorting the list
        if ($('#businessViewQueueList .list-group').sortable('option', 'disabled') === false) {
            return;
        }

        var customerId = $(this).attr('data-show-customer-id');
        if (!isNaN(customerId)) {
            setLoading();
            $('#ShowCustomerModal').data('customerId', customerId);
            $('#ShowCustomerModal').load(window.viewData.showCustomerUrl + '/' + customerId, function () {
                clearLoading();
                $('#ShowCustomerModal').modal('show');
            });
        }
    });

    $('#businessViewQueueList .list-group').sortable({ disabled: true });
    if ($('#businessViewQueueList .list-group-item').length > 1) {
        $('[data-command=rearrange]').show();
    } else {    
        $('[data-command=rearrange]').hide();
    }
}