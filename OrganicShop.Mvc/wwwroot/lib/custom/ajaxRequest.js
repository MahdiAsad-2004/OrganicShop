


let Forms = Array.from(document.getElementsByClassName('ajax-request'));

let As = Array.from(document.getElementsByClassName('ajax-load-partial'));


var elem = document.getElementById('sdfs');

var formData = new FormData();


var fff = document.createElement('form');

let element = document.createElement('form')

 let loadingBackground = document.getElementById('loading-background');
 let loadingSvg = document.getElementById('loading-svg');

function ShowLoading() {
    loadingBackground.style.height = '' + document.body.clientHeight + 'px';
    loadingBackground.style.display = 'block';
    loadingSvg.style.display = 'block';
    console.log('show');
}

function HideLoading() {
    loadingBackground.style.display = 'none';
    loadingSvg.style.display = 'none';
    console.log('hide');
}

//let myPromise = new Promise(ShowLoading);

Forms.forEach(function (elem) {
    if (elem.tagName === 'FORM') {
        elem.addEventListener('submit', function (e) {
            element = elem;
            e.preventDefault();
            ShowLoading();
            OnSubmit();
            HideLoading();
        });


        function OnSubmit() {
            if ($(element).valid()) {
                formData = new FormData(element);
                $.ajax({
                    url: element.getAttribute('href'),
                    method: element.getAttribute('method'),
                    data: formData,
                    async: false,
                    processData: false,
                    contentType: false,
                    success: function (result, textStatus, jqxhr) {
                        HandleResponse(result, jqxhr);
                    },
                    error: function (x, y, z) {
                        console.log(x);
                        console.log(y);
                        console.log(z);
                    },
                });
                element.reset();
            }
            else {
                console.log('form is invalid');
            }
        }


        //element.onsubmit = function (e) {
        //    e.preventDefault();
        //    console.log('target: ' + e.target);
        //    if ($(element).valid()) {
        //        formData = new FormData(element);
        //        $.ajax({
        //            url: element.getAttribute('href'),
        //            method: element.getAttribute('method'),
        //            data: formData,
        //            async: false,
        //            processData: false,
        //            contentType: false,
        //            success: function (result, textStatus, jqxhr) {
        //                HandleResponse(result, jqxhr);
        //            },
        //            error: function (x, y, z) {
        //                console.log(x);
        //                console.log(y);
        //                console.log(z);
        //            },
        //        });
        //        element.reset();
        //    }
        //    else {
        //        console.log('form is invalid');
        //    }
        //};
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



let invalid_inputs;
function IsInValidInput() {
    return document.getElementsByClassName('input-validation-error').length;
}




