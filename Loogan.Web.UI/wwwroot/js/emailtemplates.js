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

    public.clearEmailTemplateData = function () {
        $('#hdnemailTemplateId').val(0);
        $('#ddlEmailTemplate').val(0);
        $('#txtemailsubject').val('');
        $('#txtemailBody').val('');
    }

    return public;
})();