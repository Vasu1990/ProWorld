proWorld.AjaxHelper = proWorld.AjaxHelper || {};

//Ajax Get Call
proWorld.AjaxHelper.GetCall = function (fullUrl, callbackFunction) {
    $.ajax({
        url: fullUrl,
        cache: false,
        success: function (data) {
            callbackFunction(data);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.log("error :" + XMLHttpRequest.responseText);
            alert('There was an error in performing this operation.');
        }
    });
};

//Ajax Post Call
proWorld.AjaxHelper.AjaxPostCall = function (fullUrl, dataObj, callbackFunction) {
    $.ajax({
        url: fullUrl,
        contentType: 'application/json; charset=utf-8',
        data: dataObj,
        type: 'POST',
        success: function (data) {
            callbackFunction(data);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.log("error :" + XMLHttpRequest.responseText);
            alert('There was an error in performing this operation.');
        }
    });
};
//Ajax Post Call
proWorld.AjaxHelper.AjaxPostCallNoType = function (fullUrl, dataObj, callbackFunction) {
    $.ajax({
        url: fullUrl,
        data: dataObj,
        type: 'POST',
        success: function (data) {
            callbackFunction(data);
        },
        error: function (XMLHttpRequest, textStatus, errorThrown) {
            console.log("error :" + XMLHttpRequest.responseText);
            alert('There was an error in performing this operation.');
        }
    });
};