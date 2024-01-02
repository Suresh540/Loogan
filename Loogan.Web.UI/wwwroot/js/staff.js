function createStaff() {
    var model = {}
    model.staffId = $('#hdnStaffId').val();
    model.staffName = $('#txtStaffName').val();
    model.firstName = $('#txtStaffFirstName').val();
    model.lastName = $('#txtStaffLastName').val();
    model.code = $('#hdnStaffCode').val();
    model.userId = $('#hdnUserId').val();
    

    if ($('#txtStaffFirstName').val().trim() == '') {
        Alert(localizationLib.getLocalizeData("FirstNameMandatoryKey"), 'error');
        $('#txtStaffFirstName').focus();
        return;
    }

    if ($('#txtStaffLastName').val().trim() == '') {
        Alert(localizationLib.getLocalizeData("LastNameMandatoryKey"), 'error');
        $('#txtStaffLastName').focus();
        return;
    }

    if ($('#txtStaffName').val().trim() == '') {
        Alert(localizationLib.getLocalizeData("StaffNameMandatoryKey"), 'error');
        $('#txtStaffName').focus();
        return;
    }

    $('#btnSavestaff').prop('disabled', 'disabled');

    $.ajax({
        method: 'Post',
        url: model.staffId == 0 ? "/Admin/CreateStaff" : "/Admin/UpdateStaff",
        data: { staff: model },
        success: function (e) {
            $('#btnSavestaff').removeAttr('disabled');
            Alert(localizationLib.getLocalizeData("StaffUpdateSuccessKey"), 'Success');
            clearUserData();
            $('#btntopclose').trigger('click');
        },
        error: function (e) {
            $('#btnSavestaff').removeAttr('disabled');
            console.log(e);
            Alert(localizationLib.getLocalizeData("FailedToCreateStaffKey"), 'error');
        }
    })
}

function showStaffs(pageIndex, pageSize) {
    setTimeout(() => {
        var model = {};
        model.pagesize = pageSize == undefined ? 10 : pageSize;
        model.pageIndex = pageIndex == undefined ? 1 : pageIndex;
        model.totalRecords = getTotalRecords();
        $.ajax({
            method: 'Post',
            url: "/Admin/GetAllStaff",
            data: { pageModel: model },
            success: function (data) {
                $('#tdBody').empty();

                if (data != null && data != undefined && data.length > 0)
                    setTotalRecords(data[0].totalRecords);

                for (var item of data) {
                    let index = item.staffId
                    $('#tdBody').append(`<tr>
                        <td class="text-danger anchornounderline" title="Delete user" onclick="deleteStaff('${index}')">X</td>
                        <td><a id="f${index}" href="#" data-toggle="modal" data-target="#top_modal" onclick="return staffEdit(${index})" style="cursor:pointer">${item.firstName}</a></td>
                        <td id="l${index}">${item.lastName}</td>
                        <td id="sn${index}">${item.staffName}</td>
                        <td style="display:none" id="stc${index}">${item.code}</td>
                         <td style="display:none" id="uid${index}">${item.userId}</td>
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

function staffEdit(index) {
    $('#hdnStaffId').val(index);

    $('#hdnUserId').val($('#uid' + index).html());
    $('#hdnStaffCode').val($('#stc' + index).html());
    $('#txtStaffFirstName').val($('#f' + index).html());
    $('#txtStaffLastName').val($('#l' + index).html());
    $('#txtStaffName').val($('#sn' + index).html());

    $('#btnCreateClose').trigger('click');

    return false;
}

function deleteStaff(id) {
    if (confirm('Are you sure, you want delete Staff')) {
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

function clearStaffData() {
    $('#hdnStaffId').val(0);
    $('#txtStaffFirstName').val('');
    $('#txtStaffLastName').val('');
    $('#txtStaffName').val('');
}



