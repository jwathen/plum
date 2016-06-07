$(function () {
    initConfirmationModals('body');
    initLoadingOverlays('body');

    $('[data-formatter=phone]').formatter({ pattern: '({{999}}) {{999}}-{{9999}}', persistent: false }).resetPattern();

    // fix for stacking modals - http://stackoverflow.com/questions/16547650/can-bootstrap-modal-dialog-overlay-another-dialog
    $(document)
      .on('show.bs.modal', '.modal', function (event) {
          $(this).appendTo($('body'));
      })
      .on('shown.bs.modal', '.modal.in', function (event) {
          setModalsAndBackdropsOrder();
      })
      .on('hidden.bs.modal', '.modal', function (event) {
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
        var prompt = $this.attr('data-confirm-prompt')
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