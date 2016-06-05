/* Content-Type:text/javascript
*
* A bridge between iPad and iPhone touch events and jquery draggable, 
* sortable etc. mouse interactions.
* @author Oleg Slobodskoi  
* 
* modified by John Hardy to use with any touch device
* fixed breakage caused by jquery.ui so that mouseHandled internal flag is reset 
* before each touchStart event
* 
*/
"use strict";

(function ($) {
    $.support.touch = typeof Touch === 'object';

    if (!$.support.touch) {
        return;
    }
    var proto = $.ui.mouse.prototype,
        _mouseInit2 = proto._mouseInit;
    $.extend(proto, {
        _mouseInit: function _mouseInit() {
            this.element.bind("touchstart." + this.widgetName, $.proxy(this, "_touchStart"));
            _mouseInit2.apply(this, arguments);
        },
        _touchStart: function _touchStart(event) {
            if (event.originalEvent.targetTouches.length != 1) {
                return false;
            }
            this.element.bind("touchmove." + this.widgetName, $.proxy(this, "_touchMove")).bind("touchend." + this.widgetName, $.proxy(this, "_touchEnd"));

            this._modifyEvent(event);

            $(document).trigger($.Event("mouseup")); //reset mouseHandled flag in ui.mouse
            this._mouseDown(event);

            return false;
        },
        _touchMove: function _touchMove(event) {
            this._modifyEvent(event);
            this._mouseMove(event);
        },
        _touchEnd: function _touchEnd(event) {
            this.element.unbind("touchmove." + this.widgetName).unbind("touchend." + this.widgetName);
            this._mouseUp(event);
        },
        _modifyEvent: function _modifyEvent(event) {
            event.which = 1;
            var target = event.originalEvent.targetTouches[0];
            event.pageX = target.clientX;
            event.pageY = target.clientY;
        }
    });
})(jQuery);

$(function () {
    initConfirmationModals('body');
    initLoadingOverlays('body');

    $('[data-formatter=phone]').formatter({ pattern: '({{999}}) {{999}}-{{9999}}', persistent: false });

    // fix for stacking modals - http://stackoverflow.com/questions/16547650/can-bootstrap-modal-dialog-overlay-another-dialog
    $(document).on('show.bs.modal', '.modal', function (event) {
        $(this).appendTo($('body'));
    }).on('shown.bs.modal', '.modal.in', function (event) {
        setModalsAndBackdropsOrder();
    }).on('hidden.bs.modal', '.modal', function (event) {
        setModalsAndBackdropsOrder();
    });

    function setModalsAndBackdropsOrder() {
        var modalZIndex = 1040;
        $('.modal.in').each(function (index) {
            var $modal = $(this);
            modalZIndex++;
            $modal.css('zIndex', modalZIndex);
            $modal.next('.modal-backdrop.in').addClass('hidden').css('zIndex', modalZIndex - 1);
        });
        $('.modal.in:visible:last').focus().next('.modal-backdrop.in').removeClass('hidden');
    }
});

function setLoading() {
    if ($('.loading').length === 0) {
        $('body').append('<div class="loading" />');
    }
}

function clearLoading() {
    $('.loading').remove();
}

function initConfirmationModals(container) {
    $(container + ' [data-confirm]').click(function (e) {
        var $this = $(this);
        if ($this.data('ConfirmModalYes') === true) {
            return;
        }

        e.preventDefault();
        var title = $this.attr('data-confirm');
        var prompt = $this.attr('data-confirm-prompt');
        $('#ConfirmModal .modal-title').text(title);
        if (prompt) {
            $('#ConfirmModal .modal-body p').show().text(prompt);
        } else {
            $('#ConfirmModal .modal-body p').hide();
        }
        $('#ConfirmModal-Yes').click(function () {
            $this.data('ConfirmModalYes', true);
            $('#ConfirmModal').modal('hide');
            $this.click();
        });
        $('#ConfirmModal').modal('show');
    });
}

function initLoadingOverlays(container) {
    $(container).find('form[data-loading-overlay=true]').submit(setLoading);
    $(container).find('a[data-loading-overlay=true]').click(setLoading);
}

