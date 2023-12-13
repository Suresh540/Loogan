/*Login script*/
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
        Alert('Enter a username and password.','error');
        $('#user_id').focus();
        return;
    }

    if ($('#password').val().trim() == "") {
        Alert('Enter a username and password.', 'error');
        $('#password').focus();
        return;
    }
    document.forms[0].submit();
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

mouseOver = function (id) {
    document.getElementById(id).style.visibility = 'visible';
}

mouseOut = function (id) {
    document.getElementById(id).style.visibility = 'hidden';
}

signOut = function () {
    document.forms[0].submit();
}

function fnForgot() {
    setTimeout(() => {
        $('#txtForgotPwd').focus();
    }, 1000);
}

function ddlMasterLookup(controlId, lookUpTypeValue) {
    $.ajax({
        method: 'Post',
        url: "/Common/GetMasterLookupValues",
        data: { lookUpType: lookUpTypeValue },
        success: function (response) {
            var dropDownListId = $('#' + controlId);
            dropDownListId.empty().append('<option selected="selected" value="0">Please select</option>');
            $.each(response, function () {
                dropDownListId.append($("<option></option>").val(this['id']).html(this['name']));
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

function Alert(msg, type) {
    $.toast({
        heading: type,
        text: msg,
        icon: type,
        hideAfter: 5000 
    })
}
















