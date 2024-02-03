var emailtemplates = (function () {
    var public = {};

    public.ddlMasterEmailTemplates = function () {
        if (document.getElementById('ddlEmailTemplate') == undefined) {
            return;
        }
        $.ajax({
            method: 'Post',
            url: "/Common/GetMasterEmailTemplates",
            data: {},
            success: function (response) {
                var dropDownListId = $('#ddlEmailTemplate');
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

    public.createEmailTemplate = function () {
        var model = {}
        model.emailTemplateId = $('#hdnemailTemplateId').val();
        model.masterEmailTemplateId = $('#ddlEmailTemplate').val();
        model.subject = $('#txtemailsubject').val();
        model.body = $('#txtemailBody').val();

        if ($('#ddlEmailTemplate').val().trim() == '' || $('#ddlEmailTemplate').val() == 0) {
            Alert(localizationLib.getLocalizeData("EmailTemplateMandatoryKey"), 'error');
            $('#ddlEmailTemplate').focus();
            return;
        }

        if ($('#txtemailsubject').val().trim() == '') {
            Alert(localizationLib.getLocalizeData("EmailSubjectMandatoryKey"), 'error');
            $('#txtemailsubject').focus();
            return;
        }

        if ($('#txtemailBody').val().trim() == '') {
            Alert(localizationLib.getLocalizeData("EmailBodyMandatoryKey"), 'error');
            $('#txtemailBody').focus();
            return;
        }

        $('#btnSaveEmailTemplate').prop('disabled', 'disabled');

        $.ajax({
            method: 'Post',
            url: model.emailTemplateId == 0 ? "/Common/CreateEmailTemplates" : "/Common/UpdateEmailTemplates",
            data: { emailTemplateModel: model },
            success: function (e) {
                $('#btnSaveEmailTemplate').removeAttr('disabled');
                Alert(localizationLib.getLocalizeData("StudentCourseUpdateSuccessKey"), 'Success');
                emailtemplates.clearEmailTemplateData();
                $('#btntopclose').trigger('click');
            },
            error: function (e) {
                $('#btnSaveEmailTemplate').removeAttr('disabled');
                var msg = JSON.parse(e.responseText);
                Alert(msg.detail, 'error');
                Alert(localizationLib.getLocalizeData("FailedToStudenCoursetKey"), 'error');
            }
        })
    }

    public.showEmailTemplates = function (pageIndex, pageSize) {
        setTimeout(() => {
            var model = {};
            model.pagesize = pageSize == undefined ? 10 : pageSize;
            model.pageIndex = pageIndex == undefined ? 1 : pageIndex;
            model.totalRecords = getTotalRecords();
            $.ajax({
                method: 'Post',
                url: "/Common/GetAllEmailTemplates",
                data: { pageModel: model },
                success: function (data) {
                    $('#tdBody').empty();

                    if (data != null && data != undefined && data.length > 0) {
                        setTotalRecords(data[0].totalRecords);

                        for (var item of data) {
                            let index = item.emailTemplateId
                            $('#tdBody').append(`<tr>
                        <td class="text-danger anchornounderline" title="Delete email template" onclick="emailtemplates.deleteEmailTemplate('${index}')">X</td>
                        <td><a id="emailtemplatename${index}" href="#" data-toggle="modal" data-target="#top_modal" onclick="return emailtemplates.emailTemplatesEdit(${index})" style="cursor:pointer">${item.emailTemplateName}</a></td>
                        <td id="emailtemplatesubject${index}">${item.subject == null ? "" : item.subject}</td>
                        <td style="display:none" id="emailtemplatebody${index}">${item.body == null ? "" : item.body}</td>
                        <td style="display:none" id="emailtemplatemasterid${index}">${item.masterEmailTemplateId == null ? "" : item.masterEmailTemplateId}</td>
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

    public.emailTemplatesEdit = function (index) {
        $('#hdnemailTemplateId').val(index);
        $('#ddlEmailTemplate').val($('#emailtemplatemasterid' + index).html());
        $('#txtemailsubject').val($('#emailtemplatesubject' + index).html());
        $('#txtemailBody').val($('#emailtemplatebody' + index).html());
        $('#btnCreateClose').trigger('click');

        return false;
    }

    public.clearEmailTemplateData = function () {
        $('#hdnemailTemplateId').val(0);
        $('#ddlEmailTemplate').val(0);
        $('#txtemailsubject').val('');
        $('#txtemailBody').val('');
    }

    public.deleteEmailTemplate = function (id) {
        if (confirm('Are you sure, you want delete EmailTemplate')) {
            $.ajax({
                method: 'Post',
                url: "/Common/DeleteEmailTemplates",
                data: { emailTemplateId: id },
                success: function (e) {
                    Alert(localizationLib.getLocalizeData("StudentCourseDeleteMsgKey"), 'Success');
                    course.showEmailTemplates();
                },
                error: function (e) {
                    var msg = JSON.parse(e.responseText);
                    Alert(msg.detail, 'error');
                    Alert(localizationLib.getLocalizeData("StudentCourseFailedDeleteKey"), 'error');
                }
            })
        }
    }

    return public;
})();