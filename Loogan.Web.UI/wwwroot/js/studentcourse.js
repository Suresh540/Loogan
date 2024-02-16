var studentcourse = (function () {
    var public = {};

    public.showStudentCourses = function (pageIndex, pageSize) {
        setTimeout(() => {
            var model = {};
            model.pagesize = pageSize == undefined ? 10 : pageSize;
            model.pageIndex = pageIndex == undefined ? 1 : pageIndex;
            model.totalRecords = getTotalRecords();
            $.ajax({
                method: 'Post',
                url: "/StudentCourse/GetAllStudentCourseMapping",
                data: { pageModel: model },
                success: function (data) {
                    $('#tdBody').empty();

                    if (data != null && data != undefined && data.length > 0) {
                        setTotalRecords(data[0].totalRecords);

                        for (var item of data) {
                            let index = item.studentCourseMappingId
                            $('#tdBody').append(`<tr>
                        <td class="text-danger anchornounderline" title="Delete student course" onclick="studentcourse.deleteStudentCourse('${index}')">X</td>
                        <td><a id="coursecode${index}" href="#" data-toggle="modal" data-target="#top_modal" onclick="return studentcourse.studentCourseEdit(${index})" style="cursor:pointer">${item.courseCode}</a></td>
                        <td id="coursename${index}">${item.courseName}</td>
                        <td id="coursetype${index}">${item.courseType}</td>
                        <td id="studentname${index}">${item.studentName}</td>
                        <td id="Staffname${index}">${item.staffName}</td>
                        <td id="studentcoursestatus${index}">${item.studentCourseStatus == null ? "" : item.studentCourseStatus}</td>
                        <td id="coursecredithours${index}">${item.courseCreditHours == null ? "" : item.courseCreditHours}</td>
                        <td id="coursecredit${index}">${item.courseCredit == null ? "" : item.courseCredit}</td>
                        <td style="display:none" id="studentCourseMappingId${index}">${item.studentCourseMappingId == null ? "" : item.studentCourseMappingId}</td>
                        <td style="display:none" id="courseid${index}">${item.courseId == null ? "" : item.courseId}</td>
                        <td style="display:none" id="studentid${index}">${item.studentId == null ? "" : item.studentId}</td>
                        <td style="display:none" id="staffId${index}">${item.staffId == null ? "" : item.staffId}</td>
                        <td style="display:none" id="minusabsent${index}">${item.minusAbsent == null ? "" : item.minusAbsent}</td>
                        <td style="display:none" id="minusattended${index}">${item.minusAttended == null ? "" : item.minusAttended}</td>
                        <td style="display:none" id="numericgradeobtained${index}">${item.numericGradeObtained == null ? "" : item.numericGradeObtained}</td>
                        <td style="display:none" id="totalgradeattempted${index}">${item.totalGradeAttempted == null ? "" : item.totalGradeAttempted}</td>
                        <td style="display:none" id="totalcreditsearned${index}">${item.totalCreditsEarned == null ? "" : item.totalCreditsEarned}</td>
                        <td style="display:none" id="totalhoursattempted${index}">${item.totalHoursAttempted == null ? "" : item.totalHoursAttempted}</td>
                        <td style="display:none" id="gradelettercodeobtained${index}">${item.gradeLetterCodeObtained == null ? "" : item.gradeLetterCodeObtained}</td>
                        <td style="display:none" id="gradenote${index}">${item.gradeNote == null ? "" : item.gradeNote}</td>
                        <td style="display:none" id="coursecompleteddate${index}">${item.courseCompletedDate == null ? "" : item.courseCompletedDate}</td>
                        <td style="display:none" id="coursedropdate${index}">${item.courseDropDate == null ? "" : item.courseDropDate}</td>
                        <td style="display:none" id="courselastattendeddate${index}">${item.courseLastAttendedDate == null ? "" : item.courseLastAttendedDate}</td>
                        <td style="display:none" id="courseregistereddate${index}">${item.courseRegisteredDate == null ? "" : item.courseRegisteredDate}</td>
                        <td style="display:none" id="coursestartdate${index}">${item.courseStartDate == null ? "" : item.courseStartDate}</td>
                        <td style="display:none" id="expectedcourseenddate${index}">${item.expectedCourseEndDate == null ? "" : item.expectedCourseEndDate}</td>
                        <td style="display:none" id="gradeposteddate${index}">${item.gradePostedDate == null ? "" : item.gradePostedDate}</td>
                        <td style="display:none" id="coursecompletedstatusind${index}">${item.courseCompletedStatusInd == null ? "" : item.courseCompletedStatusInd}</td>
                        <td style="display:none" id="coursedroppedstatusind${index}">${item.courseDroppedStatusInd == null ? "" : item.courseDroppedStatusInd}</td>
                        <td style="display:none" id="coursefuturestatusind${index}">${item.courseFutureStatusInd == null ? "" : item.courseFutureStatusInd}</td>
                        <td style="display:none" id="coursecurrentstatusind${index}">${item.courseCurrentStatusInd == null ? "" : item.courseCurrentStatusInd}</td>
                        <td style="display:none" id="courseleaveofabsencestatusind${index}">${item.courseLeaveOfAbsenceStatusInd == null ? "" : item.courseLeaveOfAbsenceStatusInd}</td>
                        <td style="display:none" id="coursescheduledstatusind${index}">${item.courseScheduledStatusInd == null ? "" : item.courseScheduledStatusInd}</td>
                        <td style="display:none" id="courseretakeind${index}">${item.courseRetakeInd == null ? "" : item.courseRetakeInd}</td>
                        <td style="display:none" id="studentCourseStatusId${index}">${item.studentCourseStatusId == null ? "" : item.studentCourseStatusId}</td>
                    </tr>`)
                            index++;
                        }
                    }
                },
                error: function (e) {
                    console.log(e);
                }
            })

        }, 1000)
    }

    public.studentCourseEdit = function (index) {
        $('#hdnStudentCourseMappingId').val(index);
        $('#ddlStudentCourse').val($('#courseid' + index).html());
        $('#ddlStudent').val($('#studentid' + index).html());
        $('#ddlStaff').val($('#staffId' + index).html());
        $('#ddlStudentCourseStatus').val($('#studentCourseStatusId' + index).html());
        $('#txtCourseCredit').val($('#coursecredithours' + index).html());
        $('#txtCourseCredit').val($('#coursecredit' + index).html());
        $('#txtMinusAbsent').val($('#minusabsent' + index).html());
        $('#txtMinusAttended').val($('#minusattended' + index).html());
        $('#txtCourseCreditHours').val($('#coursecredithours' + index).html());
        $('#txtNumericGradeObtained').val($('#numericgradeobtained' + index).html());
        $('#txtTotalGradeAttempted').val($('#totalgradeattempted' + index).html());
        $('#txtTotalCreditsEarned').val($('#totalcreditsearned' + index).html());
        $('#txtTotalHoursAttempted').val($('#totalhoursattempted' + index).html());
        $('#txtTotalHoursEarned').val($('#totalcreditsearned' + index).html());
        $('#txtGradeLetterCodeObtained').val($('#gradelettercodeobtained' + index).html());
        $('#txtGradeNote').val($('#gradenote' + index).html());
        $('#txtCourseCompletedDate').val($('#coursecompleteddate' + index).html());
        $('#txtCourseDropDate').val($('#coursedropdate' + index).html());
        $('#txtCourseLastAttendedDate').val($('#courselastattendeddate' + index).html());
        $('#txtCourseRegisteredDate').val($('#courseregistereddate' + index).html());
        $('#txtCourseStartDate').val($('#coursestartdate' + index).html());
        $('#txtExpectedCourseEndDate').val($('#expectedcourseenddate' + index).html());
        $('#txtGradePostedDate').val($('#gradeposteddate' + index).html());

        if ($('#coursecompletedstatusind' + index).html() == 'true')
            $("#chkCourseCompletedStatusInd").prop("checked", true);

        if ($('#coursecurrentstatusind' + index).html() == 'true')
            $("#chkCourseCurrentStatusInd").prop("checked", true);

        if ($('#coursedroppedstatusind' + index).html() == 'true')
            $("#chkCourseDroppedStatusInd").prop("checked", true);

        if ($('#coursefuturestatusind' + index).html() == 'true')
            $("#chkCourseFutureStatusInd").prop("checked", true);

        if ($('#courseleaveofabsencestatusind' + index).html() == 'true')
            $("#chkCourseLeaveOfAbsenceStatusInd").prop("checked", true);

        if ($('#coursescheduledstatusind' + index).html() == 'true')
            $("#chkCourseScheduledStatusInd").prop("checked", true);

        if ($('#courseretakeind' + index).html() == 'true')
            $("#chkCourseRetakeInd").prop("checked", true);


        $('#btnCreateClose').trigger('click');

        return false;
    }

    public.createStudentCourse = function () {
        var model = {}
        model.studentCourseMappingId = $('#hdnStudentCourseMappingId').val();
        model.courseId = $('#ddlStudentCourse').val();
        model.studentId = $('#ddlStudent').val();
        model.staffId = $('#ddlStaff').val();
        model.studentCourseStatusId = $('#ddlStudentCourseStatus').val();
        model.courseCreditHours = $('#txtCourseCreditHours').val();
        model.courseCredit = $('#txtCourseCredit').val();
        model.minusAttended = $('#txtMinusAttended').val();
        model.minusAbsent = $('#txtMinusAbsent').val();
        model.numericGradeObtained = $('#txtNumericGradeObtained').val();
        model.totalGradeAttempted = $('#txtTotalGradeAttempted').val();
        model.totalCreditsEarned = $('#txtTotalCreditsEarned').val();
        model.totalHoursAttempted = $('#txtTotalHoursAttempted').val();
        model.totalHoursEarned = $('#txtTotalHoursEarned').val();
        model.gradeLetterCodeObtained = $('#txtGradeLetterCodeObtained').val();
        model.gradeNote = $('#txtGradeNote').val();
        model.courseCompletedDate = $('#txtCourseCompletedDate').val();
        model.courseDropDate = $('#txtCourseDropDate').val();
        model.courseLastAttendedDate = $('#txtCourseLastAttendedDate').val();
        model.courseRegisteredDate = $('#txtCourseRegisteredDate').val();
        model.courseStartDate = $('#txtCourseStartDate').val();
        model.expectedCourseEndDate = $('#txtExpectedCourseEndDate').val();
        model.gradePostedDate = $('#txtGradePostedDate').val();
        model.courseCompletedStatusInd = $('#chkCourseCompletedStatusInd').prop('checked');
        model.courseCurrentStatusInd = $('#chkCourseCurrentStatusInd').prop('checked');
        model.courseDroppedStatusInd = $('#chkCourseDroppedStatusInd').prop('checked');
        model.courseFutureStatusInd = $('#chkCourseFutureStatusInd').prop('checked');
        model.courseLeaveOfAbsenceStatusInd = $('#chkCourseLeaveOfAbsenceStatusInd').prop('checked');
        model.courseScheduledStatusInd = $('#chkCourseScheduledStatusInd').prop('checked');
        model.courseRetakeInd = $('#chkCourseRetakeInd').prop('checked');

        if ($('#ddlStudentCourse').val().trim() == '') {
            Alert(localizationLib.getLocalizeData("CourseMandatoryKey"), 'error');
            $('#ddlStudentCourse').focus();
            return;
        }

        if ($('#ddlStudent').val().trim() == '') {
            Alert(localizationLib.getLocalizeData("StudentMandatoryKey"), 'error');
            $('#ddlStudent').focus();
            return;
        }

        if ($('#ddlStaff').val().trim() == '') {
            Alert(localizationLib.getLocalizeData("StaffMandatoryKey"), 'error');
            $('#ddlStaff').focus();
            return;
        }

        if ($('#ddlStudentCourseStatus').val().trim() == '') {
            Alert(localizationLib.getLocalizeData("StudentCourseStatusMandatoryKey"), 'error');
            $('#ddlStudentCourseStatus').focus();
            return;
        }

        $('#btnSaveStudentCourse').prop('disabled', 'disabled');

        $.ajax({
            method: 'Post',
            url: model.studentCourseMappingId == 0 ? "/StudentCourse/CreateStudentCourseMapping" : "/StudentCourse/UpdateStudentCourseMapping",
            data: { studentCourseMapping: model },
            success: function (e) {
                $('#btnSaveStudentCourse').removeAttr('disabled');
                Alert(localizationLib.getLocalizeData("StudentCourseUpdateSuccessKey"), 'Success');
                course.clearCourseStudentData();
                $('#btntopclose').trigger('click');
            },
            error: function (e) {
                $('#btnSaveStudentCourse').removeAttr('disabled');
                var msg = JSON.parse(e.responseText);
                Alert(msg.detail, 'error');
                Alert(localizationLib.getLocalizeData("FailedToStudenCoursetKey"), 'error');
            }
        })
    }

    public.ddlStudentCourse = function () {
        if (document.getElementById('ddlStudentCourse') == undefined) {
            return;
        }
        $.ajax({
            method: 'Post',
            url: "/Common/GetAllCourses",
            data: {},
            success: function (response) {
                var dropDownListId = $('#ddlStudentCourse');
                dropDownListId.append($("<option></option>").val("").html("Please Select"));
                $.each(response, function () {
                    dropDownListId.append($("<option></option>").val(this['courseId']).html(this['courseName']));
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

    public.ddlStudents = function () {
        if (document.getElementById('ddlStudent') == undefined) {
            return;
        }
        $.ajax({
            method: 'Post',
            url: "/Common/GetAllStudents",
            data: {},
            success: function (response) {
                var dropDownListId = $('#ddlStudent');
                dropDownListId.append($("<option></option>").val("").html("Please Select"));
                $.each(response, function () {
                    dropDownListId.append($("<option></option>").val(this['studentId']).html(this['fullName']));
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

    public.ddlStaff = function () {
        if (document.getElementById('ddlStaff') == undefined) {
            return;
        }
        $.ajax({
            method: 'Post',
            url: "/Common/GetAllStaff",
            data: {},
            success: function (response) {
                var dropDownListId = $('#ddlStaff');
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

    public.ddlStudentCourseStatus = function (statusTypeValue) {
        if (document.getElementById('ddlStudentCourseStatus') == undefined) {
            return;
        }
        $.ajax({
            method: 'Post',
            url: "/Common/GetStatusLookUpValues",
            data: { statusLookUpType: statusTypeValue },
            success: function (response) {
                var dropDownListId = $('#ddlStudentCourseStatus');
                dropDownListId.append($("<option></option>").val("").html("Please Select"));
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

    public.deleteStudentCourse = function (id) {
        if (confirm('Are you sure, you want delete Student Course')) {
            $.ajax({
                method: 'Post',
                url: "/StudentCourse/DeleteStudentCourseMapping",
                data: { studentCourseMappingId: id },
                success: function (e) {
                    Alert(localizationLib.getLocalizeData("StudentCourseDeleteMsgKey"), 'Success');
                    course.showStudentCourses();
                },
                error: function (e) {
                    var msg = JSON.parse(e.responseText);
                    Alert(msg.detail, 'error');
                    Alert(localizationLib.getLocalizeData("StudentCourseFailedDeleteKey"), 'error');
                }
            })
        }
    }

    public.clearCourseStudentData = function () {
        $('#hdnStudentCourseMappingId').val(0);
        $('#ddlStudentCourse').val(0);
        $('#ddlStudent').val(0);
        $('#ddlStaff').val(0);
        $('#txtCourseCreditHours').val('');
        $('#txtCourseCredit').val('');
        $('#txtMinusAbsent').val('');
        $('#txtMinusAttended').val('');
        $('#txtNumericGradeObtained').val('');
        $('#txtTotalGradeAttempted').val('');
        $('#txtTotalCreditsEarned').val('');
        $('#txtTotalHoursAttempted').val('');
        $('#txtTotalHoursEarned').val('');
        $('#txtGradeLetterCodeObtained').val('');
        $('#txtGradeNote').val('');
        $('#txtCourseCompletedDate').val('');
        $('#txtCourseDropDate').val('');
        $('#txtCourseLastAttendedDate').val('');
        $('#txtCourseRegisteredDate').val('');
        $('#txtCourseStartDate').val('');
        $('#txtExpectedCourseEndDate').val('');
        $('#txtGradePostedDate').val('');
        $('#chkCourseCompletedStatusInd').prop('checked', false);
        $('#chkCourseCurrentStatusInd').prop('checked', false);
        $('#chkCourseDroppedStatusInd').prop('checked', false);
        $('#chkCourseFutureStatusInd').prop('checked', false);
        $('#chkCourseLeaveOfAbsenceStatusInd').prop('checked', false);;
        $('#chkCourseScheduledStatusInd').prop('checked', false);
        $('#chkCourseRetakeInd').prop('checked', false);
    },

    public.studentGradeMapping = function () {
            var rows = document.getElementById('tblGrades').rows;
            let list = [];
            let rowIndex = 0;
            for (var item of rows) {
                let model = {};
                if (rowIndex == 0) {
                    rowIndex++;
                    continue;
                }

                model.GradeStudentMappingId = $.trim(item.cells[0].innerHTML) == '' ? 0 : $.trim(item.cells[0].innerHTML);
                model.StudentCourseMappingId = $.trim(item.cells[1].innerHTML);
                model.MasterGradeId = $(item).find('select')[0].value;
                model.Remarks = $(item).find("input[type='text']")[0].value;
                model.IsDeleted = 0;
                model.CreatedBy = 0;
                model.CreatedDate = null;
                model.ModifyBy = 0;
                model.ModifyDate = null;
                list.push(model);
            }

            $.ajax({
                method: 'Post',
                url: "/Admin/SaveStudentGradeMapping",
                data: { request: JSON.stringify(list) },
                success: function (e) {
                    Alert(localizationLib.getLocalizeData("StudentCourseDeleteMsgKey"), 'Success');
                    course.showStudentCourses();
                },
                error: function (e) {
                    var msg = JSON.parse(e.responseText);
                    Alert(msg.detail, 'error');
                    Alert(localizationLib.getLocalizeData("StudentCourseFailedDeleteKey"), 'error');
                }
            });
        }

    return public;
})();