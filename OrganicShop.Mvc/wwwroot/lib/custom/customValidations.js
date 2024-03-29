﻿$.validator.addMethod('duplicateEmail', function (value, element, params) {
    var isExist = false;
    value = value.toLowerCase();
    $.ajax({
        url: '/Admin/User/EmailExist',
        type: 'Get',
        data: { email: value },
        async: false,
        success: function (res) {
            isExist = res;
        },
        error: function (ts) {

        },
    });
    return !isExist;
});

$.validator.unobtrusive.adapters.add('duplicateEmail', function (options) {
    options.rules['duplicateEmail'] = [];
    options.messages['duplicateEmail'] = options.message;
});


//------------------------------------------------------------------------------------------------------------------------


$.validator.addMethod('maxsize', function (value, element, params) {
    var image = element.files[0];
    if (image != null) {
        var imageSize = image.size / 1024;
        if (imageSize > params.max) {
            return false;
        }
    }
    return true;
});


$.validator.unobtrusive.adapters.add(
    'maxsize',
    ['max'],
    function (options) {
        options.rules['maxsize'] = options.params;
        options.messages['maxsize'] = options.message;
    }
);


//------------------------------------------------------------------------------------------------------------------------



$.validator.addMethod('fileFormat', function (value, element, params) {
    var file = element.files[0];
    if (file != null) {
        let fileExtension = file.name.split('.').pop();
        //console.log(params.formats.split('/'));
        return params.formats.split('/').some(a => a == fileExtension);
    }
    return true;
});



$.validator.unobtrusive.adapters.add(
    'fileFormat',
    ['formats'],
    function (options) {
        options.rules['fileFormat'] = options.params;
        options.messages['fileFormat'] = options.message;
    }
);
