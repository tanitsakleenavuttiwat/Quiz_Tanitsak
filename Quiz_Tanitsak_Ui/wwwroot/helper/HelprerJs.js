function JSONNEWTONSOFT(type, data, url) {
    var result;
    if (type === 0) {
        $.ajax({
            async: false
            , type: "POST"
            , url: url
            , data: data
            , success: function (response) {
                result = response;
            }
            , error: function (xhr, status, msg) {
                var error = eval("(" + xhr.data + ")");
                console.log(error.Message);
                result = null;
            }
        });

    }
    else if (type === 1) {
        $.ajax({
            async: false
            , type: "POST"
            , url: url
            , contentType: "application/json; charset=utf-8"
            , dataType: "json"
            , data: "{data:'" + JSON.stringify(data).replace(/'/g, "\'\'") + "'}"
            , success: function (response) {
                result = response;
            }
            , error: function (xhr, status, msg) {
                var error = eval("(" + xhr.responseText + ")");
                console.log(error.Message);
                result = null;
            }
        });
    }
    else if (type === 2) {
        $.ajax({
            async: false
            , url: url
            , type: 'POST'
            , cache: false
            , contentType: false
            , processData: false
            , data: data
            , success: function (response) {
                result = response;
            }
            , error: function (xhr, status, msg) {
                var error = eval("(" + xhr.responseText + ")");
                console.log(error.Message);
                result = null;
            }
        });
    }

    return result;
}

function SubmitAjax(formContainer, strurl) {
    var result;
    $.ajax({
        async: false
        , type: "POST"
        , url: strurl
        , contentType: "application/json; charset=utf-8"
        , dataType: "json"
        , data: formContainer
        , headers: {
            'Access-Control-Allow-Origin': '*'
        }
        , success: function (response) {
            result = response;
        }
        , error: function (xhr, status, msg) {
            console.log(xhr);
            result = null;
        }
    });
    return result;
}

function DeleteSubmitAjax(formContainer, strurl) {
    var result;
    $.ajax({
        async: false
        , type: "DELETE"
        , url: strurl
        , contentType: "application/json; charset=utf-8"
        , dataType: "json"
        , data: formContainer
        , headers: {
            'Access-Control-Allow-Origin': '*'
        }
        , success: function (response) {
            result = response;
        }
        , error: function (xhr, status, msg) {
            console.log(xhr);
            result = null;
        }
    });
    return result;
}


function GetSubmitAjax(strurl) {
    var result;
    $.ajax({
        async: false
        , type: "GET"
        , url: strurl
        , contentType: "application/json; charset=utf-8"
        , dataType: "json"
        , headers: {
            'Access-Control-Allow-Origin': '*'
        }
        , success: function (response) {
            result = response;
        }
        , error: function (xhr, status, msg) {
            console.log(xhr);
            result = null;
        }
    });
    return result;
}


function getUrlParams() {
    var vars = [], hash;
    var hashes = window.location.href.slice(window.location.href.indexOf('?') + 1).split('&');
    for (var i = 0; i < hashes.length; i++) {
        hash = hashes[i].split(/=(.+)/);
        vars[hash[0]] = hash[1];
    }
    return vars;
}


function APIPostFormData(formContainer, strurl) {
    var result;
    $.ajax({
        async: false,
        url: strurl,
        type: "POST",
        data: formContainer,
        contentType: false,
        cache: false,
        processData: false,
        success: function (data) {
            result = data;
        },
        error: function (e) {
            result = e;
        }
    });
    return result;
}

function BlobPostAjax(jsonobj, apiurl, filename, fileext) {
    var res = 'error';
    $.ajax({
        method: 'POST',
        data: JSON.stringify(jsonobj),
        contentType: "application/json; charset=utf-8",
        processData: false,
        cache: false,
        url: apiurl,
        xhrFields: {
            responseType: 'blob'
        },
        headers: {
            'Access-Control-Allow-Origin': '*'
        },
        success: function (blob) {
            var link = document.createElement('a');
            link.href = window.URL.createObjectURL(blob);
            link.download = filename + fileext;
            link.click();
            res = 'success';
        },
        error: function (xhr, status, msg) {
            if (xhr.status === 404) { swal("ไม่พบข้อมูลที่ท่านต้องการ", "กรุณาเลือกตัวกรองข้อมูลด้านบนใหม่อีกครั้งหนึ่ง", "warning"); }
            else { swal("ERROR", "Error:" + xhr + "\n Message:" + msg, "error"); }

        }
    });
    return res;
}

function GetBlobPostAjax(apiurl, txtfilename) {
    return $.ajax({
        async: true,
        method: 'GET',
        contentType: "application/json; charset=utf-8",
        processData: false,
        cache: false,
        url: apiurl,
        xhrFields: {
            responseType: 'blob'
        },
        headers: {
            'Access-Control-Allow-Origin': '*'
        },
        success: function (blob) {
            var link = document.createElement('a');
            link.href = window.URL.createObjectURL(blob);
            link.download = txtfilename;//fileext

            link.click();
            res = 'success';

        },
        error: function (xhr, status, msg) {
            if (xhr.status === 404) { swal("ไม่พบข้อมูลที่ท่านต้องการ", "กรุณาเลือกตัวกรองข้อมูลด้านบนใหม่อีกครั้งหนึ่ง", "warning"); }
            else { swal("ERROR", "Error:" + xhr + "\n Message:" + msg, "error"); }

        }
    });
}

function PostBlobPostAjax(apiurl, txtfilename, formContainer) {
    return $.ajax({
        async: true,
        method: 'POST',
        contentType: "application/json; charset=utf-8",
        processData: false,
        cache: false,
        url: apiurl,
        data: formContainer,
        xhrFields: {
            responseType: 'blob'
        },
        headers: {
            'Access-Control-Allow-Origin': '*'
        },
        success: function (blob) {
            var link = document.createElement('a');
            link.href = window.URL.createObjectURL(blob);
            link.download = txtfilename;//fileext

            link.click();
            res = 'success';

        },
        error: function (xhr, status, msg) {
            if (xhr.status === 404) { swal("ไม่พบข้อมูลที่ท่านต้องการ", "กรุณาเลือกตัวกรองข้อมูลด้านบนใหม่อีกครั้งหนึ่ง", "warning"); }
            else { swal("ERROR", "Error:" + xhr + "\n Message:" + msg, "error"); }

        }
    });
}

function SetDateTime(_date, _format) {
    var result = "";
    if (_format != "" && _format == "yyyy-mm-dd") {
        var arrD = _date.split("/");
        result = arrD[2] + "-" + arrD[1] + "-" + arrD[0];
    } else if (_format != "" && _format == "dd-MM-yyyy") {
        var arrD = _date.split("/");
        result = arrD[0] + "-" + arrD[1] + "-" + arrD[2];
    } else if (_format != "" && _format == "dd/MM/yyyy") {
        var arrD = _date.split("-");
        result = arrD[2] + "/" + arrD[1] + "/" + arrD[0];
    } else if (_format != "" && _format == "MM/dd/yyyy => dd/MM/yyyy") {
        var arrD = _date.split("/");
        result = arrD[1] + "/" + arrD[0] + "/" + arrD[2];
    }
    return result;
}

function SetformatTime(_time, _format) {
    var result = "";
    if (_time != "" && _format == "HH:mm") {
        var cut = _time.split(":");
        result = ((parseInt(cut[0]) <= 9) ? "0" + cut[0] : cut[0]) + ":" + cut[1];
    }
    return result;
}


function DateDiff(_start, _end) {
    var result;
    var start = new Date(_start);
    var end = new Date(_end);
    var diff = new Date(end - start);
    result = diff / 1000 / 60 / 60 / 24;
    return result;
}

function FormtoJSON($form) {
    var jstr = JSON.stringify($form.serializeArray().reduce((acc, f) => {
        acc[f.name] = f.value;
        return acc;
    }, {}));
    return jstr;
}


function currencyFormat(num) {
    return num.toFixed(2).replace(/(\d)(?=(\d{3})+(?!\d))/g, '$1,')
}
