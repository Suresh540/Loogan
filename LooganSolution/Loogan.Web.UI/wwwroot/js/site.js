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
        alert('Enter a username and password.');
        $('#user_id').focus();
        return;
    }

    if ($('#password').val().trim() == "") {
        alert('Enter a username and password.');
        $('#password').focus();
        return;
    }
    document.forms[0].submit();
}

window.onload = function () {
    if (window.location.href.lastIndexOf('dashboard') != -1) {
        document.getElementById('learn-oe-body').setAttribute('class', 'default ms-Fabric hide-focus-outline help-page-visible');
        document.getElementById('copyright').style.display = 'none';
        document.getElementById('copyDummy').style.display = 'block';
    } else {
        document.getElementById('learn-oe-body').removeAttribute('class');
        document.getElementById('learn-oe-body').setAttribute('class', 'bb-login hide-focus-outline');
        document.getElementById('copyright').style.display = 'block';
        document.getElementById('copyDummy').style.display = 'none';
    }
}





