var course = (function () {
    var public = {};
    public.showCourses = function (pageIndex, pageSize) {
        setTimeout(() => {
            var model = {};
            model.pagesize = pageSize == undefined ? 10 : pageSize;
            model.pageIndex = pageIndex == undefined ? 1 : pageIndex;
            model.totalRecords = getTotalRecords();
            $.ajax({
                method: 'Post',
                url: "/Admin/GetAllCourses",
                data: { pageModel: model },
                success: function (data) {
                    $('#tdBody').empty();

                    if (data != null && data != undefined && data.length > 0) {
                        setTotalRecords(data[0].totalRecords);

                        for (var item of data) {
                            let index = item.courseId
                            $('#tdBody').append(`<tr>
                        <td class="text-danger anchornounderline" title="Delete Course" onclick="course.deleteCourse('${index}')">X</td>
                        <td><a id="coursecode${index}" href="#" data-toggle="modal" data-target="#top_modal" onclick="return course.courseEdit(${index})" style="cursor:pointer">${item.courseCode}</a></td>
                        <td id="coursename${index}">${item.courseName}</td>
                        <td id="coursgroupname${index}">${item.courseGroupName}</td>
                        <td id="cousedesc${index}">${item.courseDesc == null ? "" : item.courseDesc}</td>
                         <td style="display:none" id="courselevelid${index}">${item.courseLevelSourceId == null ? "" : item.courseLevelSourceId}</td>
                        <td style="display:none" id="coursegroupid${index}">${item.courseGroupId == null ? "" : item.courseGroupId}</td>
                        <td style="display:none" id="credithours${index}">${item.creditHours == null ? "" : item.creditHours}</td>
                        <td style="display:none" id="credits${index}">${item.credits == null ? "" : item.credits}</td>
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

    public.courseEdit = function (index) {
        $('#hdnCourseId').val(index);

        $('#ddlCourseGroup').val($('#coursegroupid' + index).html());
        $('#ddlCourseLevel').val($('#courselevelid' + index).html());
        
        $('#txtCourseName').val($('#coursename' + index).html());
        $('#txtCourseCode').val($('#coursecode' + index).html());
        $('#txtCourseDesc').val($('#cousedesc' + index).html());
        $('#txtCreditHours').val($('#credithours' + index).html());
        $('#txtCredits').val($('#credits' + index).html());

        $('#btnCreateClose').trigger('click');

        return false;
    }

    public.deleteCourse = function(id) {
        if (confirm('Are you sure, you want delete Course')) {
            $.ajax({
                method: 'Post',
                url: "/Admin/DeleteCourse",
                data: { courseId: id },
                success: function (e) {
                    Alert(localizationLib.getLocalizeData("CourseDeleteMsgKey"), 'Success');
                    course.showCourses();
                },
                error: function (e) {
                    Alert(localizationLib.getLocalizeData("CourseFailedDeleteKey"), 'error');
                }
            })
        }
    }

    public.createCourse = function() {
        var model = {}
        model.courseId = $('#hdnCourseId').val();
        model.courseGroupId = $('#ddlCourseGroup').val();
        model.courseLevelSourceId = $('#ddlCourseLevel').val();
        model.courseCode = $('#txtCourseCode').val();
        model.courseName = $('#txtCourseName').val();
        model.courseDesc = $('#txtCourseDesc').val();
        model.creditHours = $('#txtCreditHours').val();
        model.credits = $('#txtCredits').val();

        if ($('#txtCourseCode').val().trim() == '') {
            Alert(localizationLib.getLocalizeData("CourseCodeMandatoryKey"), 'error');
            $('#txtCourseCode').focus();
            return;
        }

        if ($('#txtCourseName').val().trim() == '') {
            Alert(localizationLib.getLocalizeData("CourseNameMandatoryKey"), 'error');
            $('#txtCourseName').focus();
            return;
        }

        if ($('#ddlCourseGroup').val().trim() == '') {
            Alert(localizationLib.getLocalizeData("CourseGroupMandatoryKey"), 'error');
            $('#ddlCourseGroup').focus();
            return;
        }

        $('#btnSaveCourse').prop('disabled', 'disabled');

        $.ajax({
            method: 'Post',
            url: model.courseId == 0 ? "/Admin/CreateCourse" : "/Admin/UpdateCourse",
            data: { course: model },
            success: function (e) {
                $('#btnSaveCourse').removeAttr('disabled');
                Alert(localizationLib.getLocalizeData("CourseUpdateSuccessKey"), 'Success');
                course.clearCourseData();
                $('#btntopclose').trigger('click');
            },
            error: function (e) {
                $('#btnSaveCourse').removeAttr('disabled');
                console.log(e);
                Alert(localizationLib.getLocalizeData("FailedToCourseKey"), 'error');
            }
        })
    }


    public.ddlCourseCourseCategory = function(courseRelatedLookUpType) {
        if (document.getElementById('ddlCourseGroup') == undefined) {
            return;
        }
        $.ajax({
            method: 'Post',
            url: "/StudentCourse/GetCourseCategory",
            data: { lookUpType: courseRelatedLookUpType },
            success: function (response) {
                var dropDownListId = $('#ddlCourseGroup');
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

    public.clearCourseData = function() {
        $('#hdnCourseId').val(0);
        $('#ddlCourseGroup').val(0);
        $('#ddlCourseLevel').val(0);
        $('#txtCourseCode').val('');
        $('#txtCourseCode').val('');
        $('#txtCourseName').val('');
        $('#txtCourseDesc').val('');
        $('#txtCreditHours').val('');
        $('#txtCredits').val('');
    }


    return public;
})();
