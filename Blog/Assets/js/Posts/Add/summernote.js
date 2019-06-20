(function () {

    var form = $('#post-add-form');
    var inputBody = form.find('[name=body]');


    inputBody.summernote({
        lang: 'ru_RU',
        height: 200,
        minHeight: 200,
        maxHeight: 300
    });
})();