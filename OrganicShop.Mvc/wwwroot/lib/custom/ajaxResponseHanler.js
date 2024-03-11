let MessageTypes = [
    { Icon: 'success', Color: '#D4EBD5' },
    { Icon: 'error', Color: '#FDD6DA' },
    { Icon: 'warning', Color: '#FEFAD3' },
    { Icon: 'info', Color: '#C1EDF3' },
    { Icon: 'question', Color: '#D2DADE' }
];
let MessagePositions = ["top", "top-start", "top-end", "center", "center-start", "center-end", "bottom", "bottom-start", "bottom-end"];

let Message = {
    Title: "", Text: "", Position: 0, Type: 0,TimeMs: 0,
};

let Redirect = {
    Url: "",IsReplace: "",TimeOut: 0,
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


function Partial(data, jqxhr) {
    TargetElementId = jqxhr.getResponseHeader('targetElementId');
    if (TargetElementId) {
        ViewContainer = document.getElementById(TargetElementId);
    }
    MessageString = jqxhr.getResponseHeader("Message");
    Message = JSON.parse(MessageString);
    ViewContainer.innerHTML = data;
    HandleMessage(Message);
}



function ToastThenRedirect(data, jqxhr) {
    MessageString = jqxhr.getResponseHeader("Message");
    Message = JSON.parse(MessageString);
    Redirect = JSON.parse(data);
    HandleMessage(Message);
    setTimeout(function () {
        if (Redirect.IsReplace == true) {
            console.log("replace action");
            location.replace(Redirect.Url);

        }
        else {
            location.assign(Redirect.Url);
        }
    }, Message.TimeMs+1000)
}


function RedirectThenToast(data, jqxhr) {
    Redirect = JSON.parse(data);
    if (Redirect.IsReplace == true) {
        console.log("replace action");
        location.replace(Redirect.Url);

    }
    else {
        location.assign(Redirect.Url);
    }
}


function ToastThenRefresh(data,jqxhr) {
    MessageString = jqxhr.getResponseHeader("Message");
    Message = JSON.parse(MessageString);
    Redirect = JSON.parse(data);
    HandleMessage(Message);
    setTimeout(function () {
        location.reload();
    }, Message.TimeMs + 1000)
}



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