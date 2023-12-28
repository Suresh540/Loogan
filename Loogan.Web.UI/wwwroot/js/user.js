let totalRecords = 0;
function createUser() {
    var model = {}
    model.userId = $('#hdnUserId').val();
    model.userTypeId = $('#hdnUserTypeId').val() == 0 ? 3 : $('#hdnUserTypeId').val(); 
    model.firstName = $('#txtFirstName').val();
    model.middleName = $('#txtMiddleName').val();
    model.lastName = $('#txtLastName').val();
    model.additionalName = $('#txtAdditionalName').val();
    model.emailAddress = $('#txtEmailAddress').val();
    model.userName = $('#txtUserName').val();
    model.password = $('#txtPassword').val();
    model.genderId = $('#ddlGender').val();
    model.preFix = $('#txtPreFix').val();
    model.suffix = $('#txtSuffix').val();
    model.educationLevel = $("#ddlEductionLevel option:selected").text();
    model.webSite = $('#txtWebsite').val();
    model.phoneNumber = $('#txtPhone').val();
    model.city = $('#txtCity').val();
    model.state = $('#txtState').val();
    model.country = $('#txtCountry').val();
    model.fax = $('#txtFaxNumber').val();
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
        url: model.userId == 0 ? "/User/CreateUser" : "/User/UpdateUser",
        data: { user: model },
        success: function (e) {
            $('#btnSaveuser').removeAttr('disabled');
            Alert(localizationLib.getLocalizeData("UserSavedSuccessKey"), 'Success');
            clearUserData();
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

function showUsers(pageIndex, pageSize) {
    setTimeout(() => {
        var model = {};
        model.pagesize = pageSize == undefined ? 10 : pageSize;
        model.pageIndex = pageIndex == undefined ? 1 : pageIndex;
        model.totalRecords = getTotalRecords();
        $.ajax({
            method: 'Post',
            url: "/User/GetAllUser",
            data: { pageModel: model },
            success: function (data) {
                $('#tdBody').empty();

                if (data != null && data != undefined && data.length > 0)
                    setTotalRecords(data[0].totalRecords);

                for (var item of data) {
                    let index = item.userId
                    $('#tdBody').append(`<tr>
                        <td class="text-danger anchornounderline" title="Delete user" onclick="deleteUser('${index}')">X</td>
                        <td><a id="f${index}" href="#" onclick="return userEdit(${index})" style="cursor:pointer">${item.firstName}</a></td>
                        <td id="l${index}">${item.lastName}</td>
                        <td id="u${index}">${item.userName}</td>
                        <td id="ph${index}">${item.phoneNumber == null ? "" : item.phoneNumber}</td>
                        <td id="e${index}">${item.emailAddress == null ? "" : item.emailAddress}</td>
                        <td id="c${index}">${item.city == null ? "" : item.city}</td>
                        <td id="s${index}">${item.state == null ? "" : item.state}</td>
                        <td id="cou${index}">${item.country == null ? "" : item.country}</td>

                        <td style="display:none" id="ut${index}">${item.userTypeId == null ? "" : item.userTypeId}</td>
                        <td style="display:none" id="pa${index}">${item.password == null ? "" : item.password}</td>
                        <td style="display:none" id="m${index}">${item.middleName == null ? "" : item.middleName}</td>
                        <td style="display:none" id="a${index}">${item.additionalName == null ? "" : item.additionalName}</td>
                        <td style="display:none" id="g${index}">${item.genderId == null ? "" : item.genderId}</td>
                        <td style="display:none" id="pr${index}">${item.preFix == null ? "" : item.preFix}</td>
                        <td style="display:none" id="su${index}">${item.suffix == null ? "" : item.suffix}</td>
                        <td style="display:none" id="ed${index}">${item.educationLevel == null ? "" : item.educationLevel}</td>
                        <td style="display:none" id="w${index}">${item.webSite == null ? "" : item.webSite}</td>

                        <td style="display:none" id="fa${index}">${item.fax == null ? "" : item.fax}</td>
                        <td style="display:none" id="com${index}">${item.company == null ? "" : item.company}</td>
                        <td style="display:none" id="jo${index}">${item.jobTitle == null ? "" : item.jobTitle}</td>
                        <td style="display:none" id="de${index}">${item.department == null ? "" : item.department}</td>
                    </tr>`)
                    index++;
                }
            },
            error: function (e) {
                console.log(e);
            }
        })

    }, 1000)
}
function deleteUser(id) {
    if (confirm('Are you sure, you want delete user')) {
        $.ajax({
            method: 'Post',
            url: "/User/DeleteUser",
            data: { userid: id },
            success: function (e) {
                Alert(localizationLib.getLocalizeData("UserDeleteMsgKey"), 'Success');
                showUsers();
            },
            error: function (e) {
                Alert(localizationLib.getLocalizeData("UserFailedDeleteKey"), 'error');
            }
        })
    }
}
function setTotalRecords(records) {
    totalRecords = records;
}

function getTotalRecords() {
    return totalRecords;
}

function getUserEmailByUserName() {
    var loginUserName = $('#txtForgotPwd').val();
    $.ajax({
        method: 'Post',
        url: "/User/GetUserEmailByUserName",
        data: { userName: loginUserName },
        success: function (e) {
            console.log(e);
        },
        error: function (e) {
            console.log(e);
        }
    })
}

function sentMessage(msg) {
    Alert(msg, 'Success');
}

function userEdit(index) {
    $('#hdnUserId').val(index);
    $('#hdnUserTypeId').val($('#ut' + index).html());

    $('#txtFirstName').val($('#f' + index).html());
    $('#txtMiddleName').val($('#m' + index).html());
    $('#txtLastName').val($('#l' + index).html());
    $('#txtAdditionalName').val($('#a' + index).html());
    $('#txtEmailAddress').val($('#e' + index).html());
    $('#txtUserName').val($('#u' + index).html());
    $('#txtPassword').val($('#pa' + index).html());
    $('#txtcnfrmpassword').val($('#pa' + index).html());
    $('#ddlGender').val($('#g' + index).html());
    $('#txtPreFix').val($('#pr' + index).html());
    $('#txtSuffix').val($('#su' + index).html());

    var etext = $('#ed' + index).html();
    var ed = $('#ddlEductionLevel option').filter(function () { return $(this).html() == etext; }).val();
    $('#ddlEductionLevel').val(ed);
    
    $('#txtWebsite').val($('#w' + index).html());
    $('#txtPhone').val($('#ph' + index).html());
    $('#txtCity').val($('#c' + index).html());
    $('#txtState').val($('#s' + index).html());
    $('#txtCountry').val($('#cou' + index).html());
    $('#txtFaxNumber').val($('#fa' + index).html());
    $('#txtCompany').val($('#com' + index).html());
    $('#txtJobTitle').val($('#jo' + index).html());
    $('#txtDepartment').val($('#de' + index).html());
    $('#btnCreateClose').trigger('click');
    return false;
}

function clearUserData() {
    $('#hdnUserId').val(0);
    $('#hdnUserTypeId').val(0);
    $('#ddlGender').val(0);
    $('#ddlEductionLevel').val('0');

    $('#txtFirstName').val('');
    $('#txtMiddleName').val('');
    $('#txtLastName').val('');
    $('#txtAdditionalName').val('');
    $('#txtEmailAddress').val('');
    $('#txtUserName').val('');
    $('#txtPassword').val('');
    $('#txtcnfrmpassword').val('');
    $('#txtPreFix').val('');
    $('#txtSuffix').val('');
    $('#txtWebsite').val('');
    $('#txtPhone').val('');
    $('#txtCity').val('');
    $('#txtState').val('');
    $('#txtCountry').val('');
    $('#txtFaxNumber').val('');
    $('#txtCompany').val('');
    $('#txtJobTitle').val('');
    $('#txtDepartment').val('');
}
