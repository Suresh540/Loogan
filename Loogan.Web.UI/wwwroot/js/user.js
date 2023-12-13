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
    model.State = $('#txtState').val();
    model.country = $('#txtCountry').val();
    model.fax = $('#txtFax').val();
    model.company = $('#txtCompany').val();
    model.jobTitle = $('#txtJobTitle').val();
    model.department = $('#txtDepartment').val();

    if ($('#txtFirstName').val().trim() == '') {
        alert('First Name is mandatory');
        $('#txtFirstName').focus();
        return;
    }

    if ($('#txtLastName').val().trim() == '') {
        alert('Last Name is mandatory');
        $('#txtLastName').focus();
        return;
    }

    if ($('#txtUserName').val().trim() == '') {
        alert('User name is mandatory');
        $('#txtUserName').focus();
        return;
    }

    if ($('#txtPassword').val().trim() == '') {
        alert('Password is mandatory');
        $('#txtPassword').focus();
        return;
    }

    if ($('#txtPhone').val().trim() == '') {
        alert('Phone is mandatory');
        $('#txtPhone').focus();
        return;
    }

    if ($('#txtEmailAddress').val().trim() == '') {
        alert('Email Address is mandatory');
        $('#txtEmailAddress').focus();
        return;
    }

    if ($('#txtcnfrmpassword').val().trim() == '') {
        alert('Confirm password is mandatory');
        $('#txtcnfrmpassword').focus();
        return;
    }

    if ($('#txtcnfrmpassword').val().trim() != $('#txtPassword').val().trim()) {
        alert('Confirm password, password are different');
        $('#txtcnfrmpassword').focus();
        return;
    }

    if ($('#ddlGender').val().trim() == '0') {
        alert('Gender is mandatory');
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
            alert("User saved successfully");
           
        },
        error: function (e) {
            $('#btnSaveuser').removeAttr('disabled');
            console.log(e);
           
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
    alert(msg);
}