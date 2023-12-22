function createUser() {

    var model = {}
    model.userTypeId = 3;  //student
    model.firstName = $('#txtFirstName').val();
    model.middleName = $('#txtMiddleName').val();
    model.lastName = $('#txtLastName').val();
    model.additionalName = $('#txtAdditionalName').val();
    model.emailAddress = $('#txtEmailAddress').val();
    model.userName = $('#txtUserName').val();
    model.password = $('#txtPassword').val();
    model.genderId = $('#ddlGender').val();
    model.preFix = $('#txtPrefix').val();
    model.suffix = $('#txtSuffix').val();
    model.educationLevel = $("#ddlEductionLevel option:selected").text();
    model.webSite = $('#txtWebSite').val();
    model.phoneNumber = $('#txtPhone').val();
    model.city = $('#txtCity').val();
    model.state = $('#txtState').val();
    model.country = $('#txtCountry').val();
    model.fax = $('#txtFax').val();
    model.company = $('#txtCompany').val();
    model.jobTitle = $('#txtJobTitle').val();
    model.department = $('#txtDepartment').val();

    if ($('#txtFirstName').val().trim() == '') {
        Alert(localizationLib.getLocalizeData("FirstNameMandatoryKey"), 'error');
        $('#txtFirstName').focus();
        return;
    }

    if ($('#txtLastName').val().trim() == '') {
        Alert(localizationLib.getLocalizeData("LastNameMandatoryKey"), 'error');
        $('#txtLastName').focus();
        return;
    }

    if ($('#txtUserName').val().trim() == '') {
        Alert(localizationLib.getLocalizeData("UserNameMandatoryKey"), 'error');
        $('#txtUserName').focus();
        return;
    }

    if ($('#txtPassword').val().trim() == '') {
        Alert(localizationLib.getLocalizeData("PasswordMandatoryKey"), 'error');
        $('#txtPassword').focus();
        return;
    }

    if ($('#txtPhone').val().trim() == '') {
        Alert(localizationLib.getLocalizeData("PhoneMandatoryKey"), 'error');
        $('#txtPhone').focus();
        return;
    }

    if ($('#txtEmailAddress').val().trim() == '') {
        Alert(localizationLib.getLocalizeData("EmailMandatoryKey"), 'error');
        $('#txtEmailAddress').focus();
        return;
    }

    if ($('#txtcnfrmpassword').val().trim() == '') {
        Alert(localizationLib.getLocalizeData("ConfirmPwdMandatoryKey"), 'error');
        $('#txtcnfrmpassword').focus();
        return;
    }

    if ($('#txtcnfrmpassword').val().trim() != $('#txtPassword').val().trim()) {
        Alert(localizationLib.getLocalizeData("ConfirmPwdPwdDifferentKey"), 'error');
        $('#txtcnfrmpassword').focus();
        return;
    }

    if ($('#ddlGender').val().trim() == '0') {
        Alert(localizationLib.getLocalizeData("GenderMandatoryKey"),'error');
        $('#ddlGender').focus();
        return;
    }

    $('#btnSaveuser').prop('disabled', 'disabled');

    $.ajax({
        method: 'Post',
        url: "/User/CreateUser",
        data: { user: model },
        success: function (e) {
            $('#btnSaveuser').removeAttr('disabled');
            Alert(localizationLib.getLocalizeData("UserSavedSuccessKey"), 'Success');
           
        },
        error: function (e) {
            $('#btnSaveuser').removeAttr('disabled');
            console.log(e);
            Alert(localizationLib.getLocalizeData("FailedToCreateUserKey"), 'error');
           
        }
    })
}

ddlMasterLookup('ddlGender', 'gender');
ddlMasterLookup('ddlEductionLevel', 'educationlevel');

function showUsers() {
    setTimeout(() => {
        $.ajax({
            method: 'Post',
            url: "/User/GetAllUser",
            data: {},
            success: function (data) {
                for (var item of data) {
                    $('#tdBody').append(`<tr>
                        <td>${item.firstName}</td>
                        <td>${item.lastName}</td>
                        <td>${item.userName}</td>
                        <td>${item.phoneNumber == null ? "" : item.phoneNumber}</td>
                        <td>${item.emailAddress == null ? "" : item.emailAddress}</td>
                        <td>${item.city == null ? "" : item.city}</td>
                        <td>${item.state == null ? "" : item.state}</td>
                        <td>${item.country == null ? "" : item.country}</td>
                    </tr>`)
                }
            },
            error: function (e) {

            }
        })

    }, 1000)
}

function getUserEmailByUserName() {
    var loginUserName = $('#txtForgotPwd').val();
    $.ajax({
        method: 'Post',
        url: "/User/GetUserEmailByUserName",
        data: { userName: loginUserName },
        success: function (e) {

        },
        error: function (e) {

        }
    })
}

function sentMessage(msg) {
    Alert(msg, 'Success');
}