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
                        <td class="text-danger anchornounderline" title="Delete user" onclick="deleteStudent('${index}')">X</td>
                        <td><a id="stf${index}" href="#" data-toggle="modal" data-target="#top_modal" onclick="return studentEdit(${index})" style="cursor:pointer">${item.firstName == null ? "" : item.firstName }</a></td>
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
                        <td style="display:none" id="stusnumber${index}">${item.studentNumber}</td>
                        <td style="display:none" id="sttitle${index}">${item.title}</td>
                        <td style="display:none" id="stsuffix${index}">${item.suffix}</td>
                        <td style="display:none" id="stmaiden{index}">${item.maidenName}</td>
                        <td style="display:none" id="stmiddlename{index}">${item.middleName}</td>
                        <td style="display:none" id="stnickname${index}">${item.nickName}</td>
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
    //$('#txtStMiddleInitial').val($('#sn' + index).html());
    //$('#txtMaritalStatus').val($('#sn' + index).html());
    ////ddlGender
    ////ddlCountry
    ////ddlState
    //$('#txtStPostalCode').val($('#sn' + index).html());
    ////ddlStCitizenShipStatus
    ////ddlEducationalLevel
    ////ddlEthnicGroup
    ////ddlNationality
    //$('#txtOriginalExceptedStartDate').val($('#sn' + index).html());
    //$('#txtOriginalStartDate').val($('#sn' + index).html());
    //$('#txtStartDate').val($('#sn' + index).html());
    //chkHispanic
    //chkVeteran

    $('#btnStudentCreateClose').trigger('click');

    return false;
}

