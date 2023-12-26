/*Login script*/
let localizationLib = (function () {
    let langFunc = {};
    let msgs = [];
    langFunc.setLanguageData = function (messages) {
        sessionStorage.setItem("messages", messages);
    },
        langFunc.getLocalizeData = function (key) {
            msgs = JSON.parse(sessionStorage.getItem("messages"));
            var data = msgs.filter(function (item) {
                return item.name === key;
            });
            return data.length > 0 ? data[0].value : "";
        }
    return langFunc;
})();

window.onKeyClick = function (id) {
    $("label[for='" + id + "']").addClass('float-above');
}
window.normalState = function (id) {
    if ($('#' + id).val().trim() == "") {
        $("label[for='" + id + "']").removeClass('float-above');
    }
}

window.triggerSignIn = function () {
    if ($('#user_id').val().trim() == "") {
        Alert(localizationLib.getLocalizeData("ErrorMessageUserPasswordKey"), 'error');
        $('#user_id').focus();
        return;
    }

    if ($('#password').val().trim() == "") {
        Alert(localizationLib.getLocalizeData("ErrorMessageUserPasswordKey"), 'error');
        $('#password').focus();
        return;
    }
    document.getElementById('loginForm').submit();
}

window.onload = function () {
    var pathArray = window.location.pathname.split('/');
    var index = pathArray.length;
    if (index > 2) {
        document.getElementById('learn-oe-body').setAttribute('class', 'default ms-Fabric hide-focus-outline help-page-visible');
        document.getElementById('learn-oe-body').style.overflowY = 'hidden';
    } else {
        document.getElementById('learn-oe-body').removeAttribute('class');
        document.getElementById('learn-oe-body').removeAttribute('style');
        document.getElementById('learn-oe-body').setAttribute('class', 'bb-login hide-focus-outline');
    }
}

mousetabOver = function (id) {
    document.getElementById(id).style.visibility = 'visible';
}

mouseOut = function (id) {
    document.getElementById(id).style.visibility = 'hidden';
}

function fnForgot() {
    setTimeout(() => {
        $('#txtForgotPwd').focus();
    }, 1000);
}

function ddlMasterLookup(controlId, lookUpTypeValue, selectedValue) {
    $.ajax({
        method: 'Post',
        url: "/Common/GetMasterLookupValues",
        data: { lookUpType: lookUpTypeValue },
        success: function (response) {
            var dropDownListId = $('#' + controlId);
            setInitialValue(selectedValue, dropDownListId);
            $.each(response, function () {
                if (this['id'] == selectedValue || this['name'] == selectedValue) {
                    dropDownListId.append($("<option selected='selected'></option>").val(this['id']).html(this['name']));
                } else {
                    dropDownListId.append($("<option></option>").val(this['id']).html(this['name']));
                }
            });
        },
        failure: function (response) {
            Alert(response.responseText, 'error');
        },
        error: function (response) {
            Alert(response.responseText, 'error');
        }
    });
}

function setInitialValue(selectedValue, dropDownListId) {
    if (selectedValue == '')
        dropDownListId.empty().append(`<option selected="selected" value="0">${localizationLib.getLocalizeData("PleaseSelectKey")}</option>`);
    else
        dropDownListId.empty().append(`<option value="0">${localizationLib.getLocalizeData("PleaseSelectKey")}</option>`);
}

function Alert(msg, type) {
    $.toast({
        heading: type,
        text: msg,
        icon: type,
        hideAfter: 5000
    });
}

function liTabClick(tabname) {
    setTimeout(() => {
        $('.ulspace').find('li').removeClass('btnactivetab');
        $('.ulspace').find('a[href="' + tabname + '"]').parent('li').addClass('btnactivetab');
    }, 600);
}

function showCourses() {
    var top = document.getElementById('downArrow').offsetLeft - 180;
    $('#ddlCourse').toggle();
    $('#ddlCourse').css('left', top);
}
function courseout() {
    $('#ddlCourse').css('display', 'none');
}
function courseover() {
    $('#ddlCourse').css('display', 'block');
}

function showListView(index, ctrl) {
    if (index == 1) {
        $('#imgPic').css('display', 'none');
        $('#imgList').css('display', 'block');
        $('#divList').css('display', 'block');
        showhidepic('none');
    } else {
        $('#imgPic').css('display', 'block');
        $('#imgList').css('display', 'none');
        $('#divList').css('display', 'none');
        showhidepic('block');
    }
}
function showhidepic(flag) {
    $('.pichide').css('display', flag);
}

function imageFocusIn(c) {
    $(c).parent('div').css("border", "3px solid blue");
}
function imageBlur(c) {
    $(c).parent('div').css("border", "1px solid gray");
}

function coursechange() {
    var val = $("#ddlCourse option:selected").val();
    if (val == 0 || val == -1) {
        $('#leftarrowtext').html($('#ddlCourse option').eq(2).text())
    } else {
        var index = $("#ddlCourse option:selected").index();
        var tot = $('#ddlCourse option').length;
        selectcoursevalues(index, tot);
    }
    $('#courseType').val($('#ddlCourse option:selected').text());
    document.forms['frmCourse'].submit();
}
function selectcoursevalues(index, tot) {
    if (index + 1 < tot) {
        $('#leftarrowtext').html($('#ddlCourse option').eq(index + 1).text());
    } else {
        $('#leftarrowtext').html($('#ddlCourse option').eq(2).text());
    }
}
