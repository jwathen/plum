$(function () {
    $('[data-confirm]').click(function (e) {
        var prompt = $(this).attr('data-confirm');
        $('#ConfirmModal .modal-title').text(prompt);
        $('#ConfirmModal').modal('show');
        e.preventDefault();
    });
});