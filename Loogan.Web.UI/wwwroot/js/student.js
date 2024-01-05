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
                        <td id="stfulname${index}">${item.fullName == null ? "" : item.fullName}</td>
                        <td id="star${index}">${item.adminssionReprestative == null ? "" : item.adminssionReprestative}</td>
                        <td id="stg${index}">${item.gender == null ? "" : item.gender}</td>
                        <td id="stc${index}">${item.countryName == null ? "" : item.countryName}</td>
                        <td id="sts${index}">${item.stateName == null ? "" : item.stateName}</td>
                        <td id="stp${index}">${item.postalCode == null ? "" : item.postalCode}</td>
                        <td style="display:none" id="stcaid${index}">${item.campusId}</td>
                        <td style="display:none" id="stpgid${index}">${item.programId}</td>
                        <td style="display:none" id="stscid${index}">${item.schoolId}</td>
                        <td style="display:none" id="stusid${index}">${item.userId}</td>
                        <td style="display:none" id="stucntry${index}">${item.countryId == null ? "" : item.countryId}</td>
                        <td style="display:none" id="stustate${index}">${item.stateId == null ? "" : item.stateId}</td>

                        <td style="display:none" id="stuadmins${index}">${item.adminssionRepresentativeId == null ? "" : item.adminssionRepresentativeId}</td>
                        <td style="display:none" id="stusnumber${index}">${item.studentNumber == null ? "" : item.studentNumber}</td>
                        <td style="display:none" id="sttitle${index}">${item.title == null ? "" : item.title}</td>
                        <td style="display:none" id="stsuffix${index}">${item.suffix == null ? "" : item.suffix}</td>
                        <td style="display:none" id="stmaiden${index}">${item.maidenName == null ? "" : item.maidenName}</td>
                        <td style="display:none" id="stmiddlename${index}">${item.middleName == null ? "" : item.middleName}</td>
                        <td style="display:none" id="stnickname${index}">${item.nickName == null ? "" : item.nickName}</td>
                        <td style="display:none" id="snmiddleintial${index}">${item.middleInitial == null ? "" : item.middleInitial}</td>

                        <td style="display:none" id="snismaritalstatus${index}">${item.isMaritalStatus == null ? "" : item.isMaritalStatus}</td>
                        <td style="display:none" id="snhispanicInd${index}">${item.hispanicInd == null ? "" : item.hispanicInd}</td>
                        <td style="display:none" id="snveteranInd${index}">${item.veteranInd == null ? "" : item.veteranInd}</td>

                        <td style="display:none" id="snpostalcode${index}">${item.postalCode == null ? "" : item.postalCode}</td>
                        <td style="display:none" id="storiginalexceptdt${index}">${item.originalExceptedStartDate == null ? "" : item.originalExceptedStartDate}</td>
                        <td style="display:none" id="storiginalstartdt${index}">${item.originalStartDate == null ? "" : item.originalStartDate}</td>
                        <td style="display:none" id="ststartdate${index}">${item.startDate == null ? "" : item.startDate}</td>

                        <td style="display:none" id="stueducat${index}">${item.educationalLevelId == null ? "" : item.educationalLevelId}</td>
                        <td style="display:none" id="stuethnic${index}">${item.ethnicGroupId == null ? "" : item.ethnicGroupId}</td>
                        <td style="display:none" id="stnationality${index}">${item.nationalityId == null ? "" : item.nationalityId}</td>
                        <td style="display:none" id="stcitizenShip${index}">${item.citizenShipStatusId == null ? "" : item.citizenShipStatusId}</td>
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
    $('#hdnProgramId').val($('#stpgid' + index).html());
    $('#hdnSchoolId').val($('#stscid' + index).html());

    $('#txtStTitle').val($('#sttitle' + index).html());
    $('#txtStSuffix').val($('#stsuffix' + index).html());
    $('#txtStMaidenName').val($('#stmaiden' + index).html());
    $('#txtStFirstName').val($('#stf' + index).html());
    $('#txtStMiddleName').val($('#stmiddlename' + index).html());
    $('#txtStLastName').val($('#stl' + index).html());

    $('#txtStFullName').val($('#stfulname' + index).html());
    $('#ddlStAdmissionReprestative').val($('#stuadmins' + index).html());
    $('#txtStNickName').val($('#stnickname' + index).html());
    $('#txtStMiddleInitial').val($('#snmiddleintial' + index).html());
    if ($('#snismaritalstatus' + index).html() == 'true')
        $("#chkMaritalStatus").prop("checked", true);
    $('#ddlGender').val($('#stg' + index).html());
    $('#ddlCountry').val($('#stucntry' + index).html());
    $('#ddlState').val($('#stustate' + index).html());
    $('#txtStPostalCode').val($('#snpostalcode' + index).html());

    $('#ddlStCitizenShipStatus').val($('#stcitizenShip' + index).html());
    $('#ddlEducationalLevel').val($('#stueducat' + index).html());
    $('#ddlEthnicGroup').val($('#stuethnic' + index).html());
    $('#ddlNationality').val($('#stnationality' + index).html());

    $('#txtOriginalExceptedStartDate').val($('#storiginalexceptdt' + index).html());
    $('#txtOriginalStartDate').val($('#storiginalstartdt' + index).html());
    $('#txtStartDate').val($('#ststartdate' + index).html());

    if ($('#snhispanicInd' + index).html() == '1')
        $("#chkHispanic").prop("checked", true);
    if ($('#snveteranInd' + index).html() == '1')
        $("#chkVeteran").prop("checked", true);


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
    model.adminssionRepresentativeId = $('#ddlStAdmissionReprestative').val();
    model.fullName = $('#txtStFullName').val();
    model.nickName = $('#txtStNickName').val();
    model.middleInitial = $('#txtStMiddleInitial').val();
    model.genderId = $('#ddlGender').val();
    model.isMaritalStatus = $('#chkMaritalStatus').prop('checked');
    model.maritalStatus = $('#chkMaritalStatus').prop('checked');
    model.countryId = $('#ddlCountry').val();
    model.stateId = $('#ddlState').val();
    model.postalCode = $('#txtStPostalCode').val();
    model.citizenShipStatusId = $('#ddlStCitizenShipStatus').val();
    model.educationalLevelId = $('#ddlEducationalLevel').val();
    model.ethnicGroupId = $('#ddlEthnicGroup').val();
    model.nationalityId = $('#ddlNationality').val();
    model.originalExceptedStartDate = $('#txtOriginalExceptedStartDate').val();
    model.originalStartDate = $('#txtOriginalStartDate').val();
    model.startDate = $('#txtStartDate').val();
    model.hispanicInd = $('#chkHispanic').prop('checked') ? 1 : 0;
    model.veteranInd = $('#chkVeteran').prop('checked') ? 1 : 0;

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

    if ($('#txtStFullName').val().trim() == '') {
        Alert(localizationLib.getLocalizeData("FullNameMandatoryKey"), 'error');
        $('#txtStFullName').focus();
        return;
    }

    if ($('#ddlGender').val() == null || $('#ddlGender').val().trim() == '0') {
        Alert(localizationLib.getLocalizeData("GenderMandatoryKey"), 'error');
        $('#ddlGender').focus();
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

function ddlStAdmissionReprestative() {
    if (document.getElementById('ddlStAdmissionReprestative') == undefined) {
        return;
    }
    $.ajax({
        method: 'Post',
        url: "/Admin/GetAllStaff",
        data: {},
        success: function (response) {
            var dropDownListId = $('#ddlStAdmissionReprestative');
            dropDownListId.append($("<option></option>").val("").html("Please Select"));
            $.each(response, function () {
                dropDownListId.append($("<option></option>").val(this['staffId']).html(this['staffName']));
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

