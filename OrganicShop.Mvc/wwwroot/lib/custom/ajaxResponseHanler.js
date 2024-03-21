let MessageTypes = [
    { Icon: 'success', Color: '#D4EBD5' },
    { Icon: 'error', Color: '#FDD6DA' },
    { Icon: 'warning', Color: '#FEFAD3' },
    { Icon: 'info', Color: '#C1EDF3' },
    { Icon: 'question', Color: '#D2DADE' }
];
let MessagePositions = ["top", "top-start", "top-end", "center", "center-start", "center-end", "bottom", "bottom-start", "bottom-end"];

let Message = {
    Title: "", Text: "", Position: 0, Type: 0, TimeMs: 0,
};

let Redirect = {
    Url: "", IsReplace: "", TimeOut: 0,
};

let Messagetype = MessageTypes[0];

let ViewContainer = document.getElementById('view-container');

var TargetElementId = null;

let ResponseDataType = '';

let MessageString = null;


function HandleResponse(data, jqxhr) {
    ShowLoading();
    if (jqxhr == null || jqxhr == undefined) {
        throw new Error("jxhr is null or undefined");
    }
    ResponseDataType = jqxhr.getResponseHeader("ResponseDataType");

    if (ResponseDataType == 'partial') {
        Partial(data, jqxhr);
    }
    else if (ResponseDataType == 'partial-toast') {
        PartialThenToast(data, jqxhr);
    }
    else if (ResponseDataType == 'redirect-toast') {
        RedirectThenToast(data, jqxhr);
    }
    else if (ResponseDataType == 'toast-redirect') {
        ToastThenRedirect(data, jqxhr);
    }
    else if (ResponseDataType == 'toast-refresh') {
        ToastThenRefresh(data, jqxhr);
    }
    else if (ResponseDataType == 'toast') {
        Message = JSON.parse(data);
        HandleMessage(Message);
    }
    HideLoading();
}



function HandleFetchResponse(response) {
    if (response.ok) {
        ResponseDataType = response.headers.get('ResponseDataType');
        if (ResponseDataType == 'partial') {
            Partial(response);
        }
        else if (ResponseDataType == 'partial-toast') {
            PartialThenToast(response);
        }
        else if (ResponseDataType == 'redirect-toast') {
            RedirectThenToast(response);
        }
        else if (ResponseDataType == 'toast-redirect') {
            ToastThenRedirect(response);
        }
        else if (ResponseDataType == 'toast-refresh') {
            ToastThenRefresh(response);
        }
        else if (ResponseDataType == 'toast') {
            response.json().then(a => { HandleMessage(a) });
        }
        else if (ResponseDataType == 'json') {
            response.json().then(a => { console.log(a); });
        }
    }
    else {
        if (response.status == 500) {
            Toast('Warning', 'Internal Server Warning', 2, 5000);
        }
        else if (response.status == 400) {
            Toast('Warning', 'Bad Request', 2, 5000);
        }
        else if (response.status == 401) {
            Toast('Warning', 'Unauthorized', 2, 5000);
        }
        else if (response.status == 403) {
            Toast('Warning', 'Forbidden', 2, 5000);
        }
        else if (response.status == 404) {
            Toast('Warning', 'Not Found', 2, 5000);
        }
        else if (response.status == 405) {
            Toast('Warning', 'Not Allowed',2, 5000);
        }
        else if (response.status == 503) {
            Toast('Warning', 'Service Unavailable', 2, 5000);
        }
        console.log(response);
    }

}




function Partial(response) {
    TargetElementId = response.headers.get('targetElementId');
    response.text().then(partial =>
    {
        if (TargetElementId) {
            document.getElementById(TargetElementId).innerHTML = partial;
        }
        else {
            ViewContainer.innerHTML = partial;

        }
    });
   
}

function PartialThenToast(response) {
    TargetElementId = response.headers.get('targetElementId');
    if (TargetElementId) {
        ViewContainer = document.getElementById(TargetElementId);
    }
    MessageString = response.headers.get("Message");
    Message = JSON.parse(MessageString);
    response.text().then(partial => {
        ViewContainer.innerHTML = partial;
    });

    HandleMessage(Message);
}

function ToastThenRedirect(response) {
    MessageString = response.headers.get("Message");
    Message = JSON.parse(MessageString);
    response.json().then(redirect =>
    {
        HandleMessage(Message);
        setTimeout(function () {
            if (redirect.IsReplace == true) {
                location.replace(redirect.Url);

            }
            else {
                location.assign(redirect.Url);
            }
        }, Message.TimeMs)
    })
  
}


function RedirectThenToast(response) {
    response.json().then(redirect => {
        if (redirect.IsReplace == true) {
            console.log("replace action");
            location.replace(redirect.Url);
        }
        else {
            location.assign(redirect.Url);
        }
    });
}

function ToastThenRefresh(response) {
    response.json().then(message =>
    {
        HandleMessage(message);
        setTimeout(function () {
            location.reload();
        }, message.TimeMs)
    });
}



























//function Partial(data, jqxhr) {
//    TargetElementId = jqxhr.getResponseHeader('targetElementId');
//    if (TargetElementId) {
//        ViewContainer = document.getElementById(TargetElementId);
//    }
//    ViewContainer.innerHTML = data;
//}



//function PartialThenToast(data, jqxhr) {
//    TargetElementId = jqxhr.getResponseHeader('targetElementId');
//    if (TargetElementId) {
//        ViewContainer = document.getElementById(TargetElementId);
//    }
//    MessageString = jqxhr.getResponseHeader("Message");
//    Message = JSON.parse(MessageString);
//    ViewContainer.innerHTML = data;
//    HandleMessage(Message);
//}



//function ToastThenRedirect(data, jqxhr) {
//    MessageString = jqxhr.getResponseHeader("Message");
//    Message = JSON.parse(MessageString);
//    Redirect = JSON.parse(data);
//    HandleMessage(Message);
//    setTimeout(function () {
//        if (Redirect.IsReplace == true) {
//            console.log("replace action");
//            location.replace(Redirect.Url);

//        }
//        else {
//            location.assign(Redirect.Url);
//        }
//    }, Message.TimeMs + 1000)
//}


//function RedirectThenToast(data, jqxhr) {
//    Redirect = JSON.parse(data);
//    if (Redirect.IsReplace == true) {
//        console.log("replace action");
//        location.replace(Redirect.Url);

//    }
//    else {
//        location.assign(Redirect.Url);
//    }
//}


//function ToastThenRefresh(data, jqxhr) {
//    Message = JSON.parse(data);
//    HandleMessage(Message);
//    setTimeout(function () {
//        location.reload();
//    }, Message.TimeMs + 1000)
//}



function HandleMessage(message) {

    var messageType = MessageTypes[message.Type];
    Swal.fire({
        toast: true,
        titleText: message.Title,
        text: message.Text,
        icon: messageType.Icon,
        timer: message.TimeMs == 0 ? undefined : message.TimeMs,
        position: MessagePositions[message.Position],
        background: messageType.Color,
        timerProgressBar: message.TimeMs == 0 ? false : true,

        showConfirmButton: false,
        showCloseButton: false,
        width: '450px',
        allowEscapeKey: false,
        //allowEnterKey: false,
        //confirmButtonText: 'Ok',
        //showCancelButton:true,
        //cancelButtonText: 'Cancel',
    });
}



function Toast(title, text, typeIndex, timeMs) {
    Messagetype = MessageTypes[typeIndex];
    console.log(Messagetype);
    Swal.fire({
        toast: true,
        titleText: title,
        text: text,
        icon: Messagetype.Icon,
        timer: timeMs == 0 ? undefined : timeMs,
        position: 'top-end',
        background: Messagetype.Color,
        timerProgressBar: timeMs == 0 ? false : true,

        showConfirmButton: false,
        showCloseButton: true,
        width: '450px',

        //confirmButtonText: 'Ok',
        //showCancelButton:true,
        //cancelButtonText: 'Cancel',
        //allowEscapeKey:true,
        //allowEnterKey:true,
    });
}












