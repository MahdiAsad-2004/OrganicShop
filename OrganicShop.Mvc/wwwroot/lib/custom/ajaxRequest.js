


let Forms = Array.from(document.getElementsByClassName('ajax-request'));

let As = Array.from(document.getElementsByClassName('ajax-load-partial'));


var elem = document.getElementById('sdfs');

var formData = new FormData();



Forms.forEach(function (element) {
    if (element.tagName === 'FORM') {
        element.onsubmit = function (e) {
            e.preventDefault();
            formData = new FormData(element);
            $.ajax({
                url: element.getAttribute('href'),
                method: element.getAttribute('method'),
                data: formData,
                processData: false,
                contentType: false,
                success: function (result, textStatus, jqxhr) {
                    HandleResponse(result, jqxhr);
                },
                error: function (jqXHR, textStatus, errorThrown) {
                    console.log(jqXHR);
                    console.log(textStatus);
                    console.log(errorThrown);
                },
            });
        };
    }   
});


As.forEach(function (element) {
    if (element.tagName === 'A') {
        if (element.hasAttribute('data-target-id')) {
            element.onclick = function (e) {
                e.preventDefault();
                var elementTargetId = element.getAttribute('data-target-id');
                var targetElement = document.getElementById(elementTargetId);
                $.ajax({
                    url: element.getAttribute('href'),
                    method: 'get',
                    data: {},
                    success: function (result, textStatus, jqxhr) {
                        targetElement.innerHTML = result;
                    },
                    error: function (jqXHR, textStatus, errorThrown) {
                        console.log(jqXHR);
                        console.log(textStatus);
                        console.log(errorThrown);
                    },
                });
            }
        }
    }
})








