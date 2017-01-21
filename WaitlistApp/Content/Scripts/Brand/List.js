$(function () {
    $('.delete-link').click(function (e) {
        e.stopPropagation();
        if (confirm('Are you sure you want to delete this item?')) {
            $(this).parent().submit();
        }
    });

    $('.activate-link').click(function (e) {
        e.stopPropagation();
        $(this).parent().submit();
    });
});