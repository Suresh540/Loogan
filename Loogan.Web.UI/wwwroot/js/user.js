function createUser() {
    var model = {}
    model.additionalName = $('#txtAddName').val();
    model.genderId = 4;
    model.preFix = $('#txtPrefix').val();
    //middleName
    model.suffix = $('#txtSuffix').val();
    //eduction Level
    model.webSite = $('#txtWebSite').val();
    model.city = $('#txtCity').val();
    model.State = $('#txtState').val();
    model.country = $('#txtCountry').val();
    model.phoneNumber = $('#txtPhone').val();
    model.fax = $('#txtFax').val();
    model.company = $('#txtCompany').val();
    model.jobTitle = $('#txtJobTitle').val();
    model.department = $('#txtDepartment').val();

    $.ajax({
        method: 'Post',
        url: "/User/CreateUser",
        data: { user: model },
        success: function (e) {

        },
        error: function (e) {

        }
    })
}

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
                        <td>${item.phoneNumber}</td>
                        <td>${item.emailAddress}</td>
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