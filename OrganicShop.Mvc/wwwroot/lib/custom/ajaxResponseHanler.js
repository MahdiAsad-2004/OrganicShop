let MessageTypes = [
    { Icon: 'success', Color: '#D4EBD5' },
    { Icon: 'error', Color: '#FDD6DA' },
    { Icon: 'warning', Color: '#FEFAD3' },
    { Icon: 'info', Color: '#C1EDF3' },
    { Icon: 'question', Color: '#D2DADE' }
];
let MessagePositions = ["top", "top-start", "top-end", "center", "center-start", "center-end", "bottom", "bottom-start", "bottom-end"];

let Message = {
    Title: "",
    Text: "",
    Position: 0,
    Type: 0,
    TimeMs: 0,
};

let RedirectUrl = '';

let ReplaceUrl = '';

let Refresh = false;

let ViewContainer = document.getElementById('view-container');

var TargetElementId = null;

let ResponseDataType = '';

let DefaultTime = 3000;



function HandleResponse(data, jqxhr) {
    if (jqxhr == null || jqxhr == undefined) {
        throw new Error("jxhr is null or undefined");
    }
    ResponseDataType = jqxhr.getResponseHeader("ResponseDataType");
    var messageString = jqxhr.getResponseHeader("Message");
    if (messageString)
    {
        Message = JSON.parse(messageString);
        DefaultTime = Message.TimeMs;
        HandleMessage(Message);
        AfterMessage(jqxhr, DefaultTime);
    }
    TargetElementId = jqxhr.getResponseHeader("TargetElementId");
    HandleData(data, DefaultTime);
}



function HandleMessage(message) {
   
    var messageType = MessageTypes[message.Type];
    console.log(message.Type);
    console.log(messageType);
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
        showCloseButton: true,
        width: '400px',
        //confirmButtonText: 'Ok',
        //showCancelButton:true,
        //cancelButtonText: 'Cancel',
        //allowEscapeKey:true,
        //allowEnterKey:true,
    });
}


function AfterMessage(jqxhr , time) {
    RedirectUrl = jqxhr.getResponseHeader("RedirectUrl");
    ReplaceUrl = jqxhr.getResponseHeader("RefreshUrl");
    Refresh = jqxhr.getResponseHeader("Refresh");
    if (RedirectUrl) {
        setTimeout(function () {
            location.assign(RedirectUrl);
        }, time);
    }
    else if (ReplaceUrl) {
        setTimeout(function () {
            location.replace(ReplaceUrl);
        }, time)
    }
    else if (Refresh) {
        setTimeout(function () {
            location.reload();
        }, time)
    }
}



function HandleData(data , time) {
    if (ResponseDataType == 'partial') {
        if (TargetElementId) {
            TargetElementId.innerHTML = data;
        }
        else {
            ViewContainer.innerHTML = data;
        }
    }
    else if (ResponseDataType == 'redirect') {
        setTimeout(function () {
            location.assign(data);
        }, time);
    }
    else if (ResponseDataType = 'toast') {
        console.log("Data: " + data);
        HandleMessage(JSON.parse(data));
    }
    else {
        throw new Error("ResponseDataType header is not set .")
    }
}



let type = MessageTypes[0];
function Toast(title, text, typeIndex , timeMs) {
    alert(typeIndex);
    console.log(type);
    Swal.fire({
        toast: true,
        titleText: title,
        text: text,
        icon: type.Icon,
        timer: timeMs == 0 ? undefined : timeMs,
        position: 'top-end',
        background: type.Color,
        timerProgressBar: timeMs == 0 ? false : true,

        showConfirmButton: false,
        showCloseButton: true,
        width: '400px',

        //confirmButtonText: 'Ok',
        //showCancelButton:true,
        //cancelButtonText: 'Cancel',
        //allowEscapeKey:true,
        //allowEnterKey:true,
    });

}