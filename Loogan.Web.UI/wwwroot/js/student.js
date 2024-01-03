var student = (function () {
    var public = {};
    public.addfavourite = function (ctrl) {
        var src = $(ctrl).prop('src');
        if (src.indexOf('starfull.png') != -1) {
            $(ctrl).removeAttr('src');
            $(ctrl).prop('src', '/images/star.png');
            $(ctrl).prop('title', localizationLib.getLocalizeData("AddFavoriteKey"));
            Alert(localizationLib.getLocalizeData("RemovedFromFavoriteKey"), 'Success');
        } else {
            $(ctrl).removeAttr('src');
            $(ctrl).prop('src', '/images/starfull.png');
            $(ctrl).prop('title', localizationLib.getLocalizeData("RemoveFavoriteKey"));
            Alert(localizationLib.getLocalizeData("AddFavoriteKey"), 'Success');
        }
    }
    return public;
})();

function showStudents(pageIndex, pageSize) {
    setTimeout(() => {
        var model = {};
        model.pagesize = pageSize == undefined ? 10 : pageSize;
        model.pageIndex = pageIndex == undefined ? 1 : pageIndex;
        model.totalRecords = getTotalRecords();
        $.ajax({
            method: 'Post',
            url: "/Admin/GetAllStudents",
            data: { pageModel: model },
            success: function (data) {
                $('#tdBody').empty();

                if (data != null && data != undefined && data.length > 0)
                    setTotalRecords(data[0].totalRecords);

                for (var item of data) {
                    let index = item.studentId
                    $('#tdBody').append(`<tr>
                        <td class="text-danger anchornounderline" title="Delete Student" onclick="deleteStudent('${index}')">X</td>
                        <td><a id="stf${index}" href="#" data-toggle="modal" data-target="#top_modal" onclick="return studentEdit(${index})" style="cursor:pointer">${item.firstName == null ? "" : item.firstName}</a></td>
                        <td id="stl${index}">${item.lastName == null ? "" : item.lastName}</td>
                        <td id="stfulname{index}">${item.fullName == null ? "" : item.fullName}</td>
                        <td id="star{index}">${item.adminssionReprestative == null ? "" : item.adminssionReprestative}</td>
                        <td id="stg{index}">${item.gender == null ? "" : item.gender}</td>
                        <td id="stc{index}">${item.countryName == null ? "" : item.countryName}</td>
                        <td id="sts{index}">${item.stateName == null ? "" : item.stateName}</td>
                        <td id="stp{index}">${item.postalCode == null ? "" : item.postalCode}</td>
                        <td style="display:none" id="stcaid${index}">${item.campusId}</td>
                        <td style="display:none" id="stpgid${index}">${item.programId}</td>
                        <td style="display:none" id="stscid${index}">${item.schoolId}</td>
                        <td style="display:none" id="stusid${index}">${item.userId}</td>
                        <td style="display:none" id="stusnumber${index}">${item.studentNumber == null ? "" : item.studentNumber}</td>
                        <td style="display:none" id="sttitle${index}">${item.title == null ? "" : item.title}</td>
                        <td style="display:none" id="stsuffix${index}">${item.suffix == null ? "" : item.suffix}</td>
                        <td style="display:none" id="stmaiden${index}">${item.maidenName == null ? "" : item.maidenName}</td>
                        <td style="display:none" id="stmiddlename${index}">${item.middleName == null ? "" : item.middleName}</td>
                        <td style="display:none" id="stnickname${index}">${item.nickName == null ? "" : item.nickName}</td>
                        <td style="display:none" id="snmiddleintial${index}">${item.middleInitial == null ? "" : item.middleInitial}</td>
                        <td style="display:none" id="snismaritalstatus${index}">${item.IsMaritalStatus == null ? "" : item.IsMaritalStatus}</td>
                        <td style="display:none" id="snpostalcode${index}">${item.postalCode == null ? "" : item.postalCode}</td>
                        <td style="display:none" id="storiginalexceptdt${index}">${item.originalExceptedStartDate == null ? "" : item.originalExceptedStartDate}</td>
                        <td style="display:none" id="storiginalstartdt${index}">${item.originalStartDate == null ? "" : item.originalStartDate}</td>
                        <td style="display:none" id="ststartdate${index}">${item.startDate == null ? "" : item.startDate}</td>
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

function studentEdit(index) {
    $('#hdnStudentId').val(index);
    $('#hdnUserId').val($('#stusid' + index).html());
    $('#hdnStudentNumber').val($('#stusnumber' + index).html());
    $('#hdnCampusId').val($('#stcaid' + index).html());
    $('#hdnprogramId').val($('#stpgid' + index).html());
    $('#hdnSchoolId').val($('#stscid' + index).html());


    $('#txtStTitle').val($('#sttitle' + index).html());
    $('#txtStSuffix').val($('#stsuffix' + index).html());
    $('#txtStMaidenName').val($('#stmaiden' + index).html());
    $('#txtStFirstName').val($('#stf' + index).html());
    $('#txtStMiddleName').val($('#stmiddlename' + index).html());
    $('#txtStLastName').val($('#stl' + index).html());
    $('#txtStFullName').val($('#stfulname' + index).html());
    //ddlStAdmissionReprestative
    $('#txtStNickName').val($('#stnickname' + index).html());
    $('#txtStMiddleInitial').val($('#snmiddleintial' + index).html());
    $('#txtMaritalStatus').val($('#snismaritalstatus' + index).html());
    ////ddlGender
    ////ddlCountry
    ////ddlState
    $('#txtStPostalCode').val($('#snpostalcode' + index).html());
    ////ddlStCitizenShipStatus
    ////ddlEducationalLevel
    ////ddlEthnicGroup
    ////ddlNationality
    $('#txtOriginalExceptedStartDate').val($('#storiginalexceptdt' + index).html());
    $('#txtOriginalStartDate').val($('#storiginalstartdt' + index).html());
    $('#txtStartDate').val($('#ststartdate' + index).html());
    //chkHispanic
    //chkVeteran

    $('#btnStudentCreateClose').trigger('click');

    return false;
}

function updateStudent() {
    var model = {}
    model.studentId = $('#hdnStudentId').val();
    model.userId = $('#hdnUserId').val();
    model.studentNumber = $('#hdnStudentNumber').val();
    model.campusId = $('#hdnCampusId').val();
    model.programId = $('#hdnprogramId').val();
    model.schoolId = $('#hdnSchoolId').val();
    model.title = $('#txtStTitle').val();
    model.suffix = $('#txtStSuffix').val();
    model.maidenName = $('#txtStMaidenName').val();
    model.firstName = $('#txtStFirstName').val();
    model.middleName = $('#txtStMiddleName').val();
    model.lastName = $('#txtStLastName').val();
    model.fullName = $('#txtStFullName').val();
    //ddlStAdmissionReprestative
    model.nickName = $('#txtStNickName').val();
    model.middleInitial = $('#txtStMiddleInitial').val();
    model.isMaritalStatus = $('#txtMaritalStatus').val();
    //ddlGender
    //ddlCountry
    //ddlState
    model.postalCode = $('#txtStPostalCode').val();
    //ddlStCitizenShipStatus
    //ddlEducationalLevel
    //ddlEthnicGroup
    //ddlNationality
    model.originalExceptedStartDate = $('#txtOriginalExceptedStartDate').val();
    model.originalStartDate = $('#txtOriginalStartDate').val();
    model.StartDate = $('#txtStartDate').val();
    //chkHispanic
    //chkVeteran

    if ($('#txtStTitle').val().trim() == '') {
        Alert(localizationLib.getLocalizeData("TitleMandatoryKey"), 'error');
        $('#txtStTitle').focus();
        return;
    }

    if ($('#txtStFirstName').val().trim() == '') {
        Alert(localizationLib.getLocalizeData("FirstNameMandatoryKey"), 'error');
        $('#txtStFirstName').focus();
        return;
    }

    if ($('#txtStLastName').val().trim() == '') {
        Alert(localizationLib.getLocalizeData("LastNameMandatoryKey"), 'error');
        $('#txtStLastName').focus();
        return;
    }

    $('#btnSavestudent').prop('disabled', 'disabled');

    $.ajax({
        method: 'Post',
        url: "/Admin/UpdateStudent",
        data: { studentObj: model },
        success: function (e) {
            $('#btnSavestudent').removeAttr('disabled');
            Alert(localizationLib.getLocalizeData("StudentUpdateSuccessKey"), 'Success');
            showStudents();
            clearUserData();
            $('#btntopclose').trigger('click');
        },
        error: function (e) {
            $('#btnSavestudent').removeAttr('disabled');
            console.log(e);
            Alert(localizationLib.getLocalizeData("FailedToCreateStudentKey"), 'error');
        }
    })
}

function deleteStudent(id) {
    if (confirm('Are you sure, you want delete Student')) {
        $.ajax({
            method: 'Post',
            url: "/Admin/DeleteStudent",
            data: { studentId: id },
            success: function (e) {
                Alert(localizationLib.getLocalizeData("StudentDeleteMsgKey"), 'Success');
                showStudents();
            },
            error: function (e) {
                Alert(localizationLib.getLocalizeData("StudentFailedDeleteKey"), 'error');
            }
        })
    }
}
function clearStudentData() {
    $('#hdnStaffId').val(0);
    $('#txtStaffFirstName').val('');
    $('#txtStaffLastName').val('');
    $('#txtStaffName').val('');
}

