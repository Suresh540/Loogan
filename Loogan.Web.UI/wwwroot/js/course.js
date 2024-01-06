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
                        <td class="text-danger anchornounderline" title="Delete Course" onclick="deleteCourse('${index}')">X</td>
                        <td><a id="coursecode${index}" href="#" data-toggle="modal" data-target="#top_modal" onclick="return course.courseEdit(${index})" style="cursor:pointer">${item.courseCode}</a></td>
                        <td id="coursename${index}">${item.courseName}</td>
                        <td id="coursgroupname${index}">${item.courseGroupName}</td>
                        <td id="cousedesc${index}">${item.courseDesc == null ? "" : item.courseDesc}</td>
                         <td style="display:none" id="courselevelid${index}">${item.courseLevelSourceId}</td>
                        <td style="display:none" id="coursegroupid${index}">${item.courseGroupId}</td>
                        <td style="display:none" id="credithours${index}">${item.creditHours}</td>
                        <td style="display:none" id="credits${index}">${item.credits$}</td>
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
        $('#hdnCourseGroupId').val($('#coursegroupid' + index).html());
        $('#hdnCourseLevelSourceId').val($('#courselevelid' + index).html());

        $('#txtCourseName').val($('#coursename' + index).html());
        $('#txtCourseCode').val($('#coursecode' + index).html());
        $('#txtCourseDesc').val($('#cousedesc' + index).html());
        $('#txtCreditHours').val($('#credithours' + index).html());
        $('#txtCredits').val($('#credits' + index).html());

        $('#btnCreateClose').trigger('click');

        return false;
    }
    return public;
})();
