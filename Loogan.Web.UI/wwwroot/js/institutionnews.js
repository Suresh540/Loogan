﻿var institutionnews = (function () {

    var public = {};
    public.showInstitutionNews = function (pageIndex, pageSize) {
        setTimeout(() => {
            var model = {};
            model.pagesize = pageSize == undefined ? 10 : pageSize;
            model.pageIndex = pageIndex == undefined ? 1 : pageIndex;
            model.totalRecords = getTotalRecords();
            $.ajax({
                method: 'Post',
                url: "/Admin/GetAllInstitutionNews",
                data: { pageModel: model },
                success: function (data) {
                    $('#tdBody').empty();

                    if (data != null && data != undefined && data.length > 0) {
                        setTotalRecords(data[0].totalRecords);

                        for (var item of data) {
                            let index = item.institutionNewsId
                            $('#tdBody').append(`<tr>
                        <td class="text-danger anchornounderline" title="Delete institution News" onclick="institutionnews.deleteInstitutionNews('${index}')">X</td>
                        <td><a id="institutionname${index}" href="#" data-toggle="modal" data-target="#top_modal" onclick="return institutionnews.institutionNewsEdit(${index})" style="cursor:pointer">${item.institutionName}</a></td>
                        <td id="insnewstitle${index}">${item.title == null ? "" : item.title}</td>
                        <td id="insnewnews${index}">${item.news == null ? "" : item.news}</td>
                        <td id="instnewsstartDate${index}">${item.startDate == null ? "" : item.startDate}</td>
                        <td id="instnewsendate${index}">${item.endDate == null ? "" : item.endDate}</td>
                        <td style="display:none" id="instnewsdescription${index}">${item.description == null ? "" : item.description}</td>
                        <td style="display:none" id="instnewsinstitutionId${index}">${item.institutionId == null ? "" : item.institutionId}</td>
                    </tr>`)
                            index++;
                        }
                    }
                },
                error: function (e) {
                    var msg = JSON.parse(e.responseText);
                    Alert(msg.detail, 'error')
                }
            })

        }, 1000)
    }

    public.institutionNewsEdit = function (index) {
        $('#hdnInstitutionNewsId').val(index);
        $('#hdnInstitutionId').val($('#instnewsinstitutionId' + index).html());
        $('#ddlInstitutions').val($('#instnewsinstitutionId' + index).html())
        $('#txtTitle').val($('#insnewstitle' + index).html());
        $('#txtNews').val($('#insnewnews' + index).html());
        $('#txtDescription').val($('#instnewsdescription' + index).html());
        $('#txtStartDate').val($('#instnewsstartDate' + index).html());
        $('#txtEndDate').val($('#instnewsendate' + index).html());

        $('#btnCreateClose').trigger('click');

        return false;
    }

    public.createInstitutionNews = function () {
        var model = {}
        model.institutionNewsId = $('#hdnInstitutionNewsId').val();
        model.institutionId = $('#ddlInstitutions').val();
        model.title = $('#txtTitle').val();
        model.news = $('#txtNews').val();
        model.description = $('#txtDescription').val();
        model.startDate = $('#txtStartDate').val();
        model.endDate = $('#txtEndDate').val();

        
        if ($('#ddlInstitutions').val().trim() == '') {
            Alert(localizationLib.getLocalizeData("InstitutionNameMandatoryKey"), 'error');
            $('#ddlInstitutions').focus();
            return;
        }

        if ($('#txtTitle').val().trim() == '') {
            Alert(localizationLib.getLocalizeData("TitleMandatoryKey"), 'error');
            $('#txtTitle').focus();
            return;
        }

        if ($('#txtNews').val().trim() == '') {
            Alert(localizationLib.getLocalizeData("NewsMandatoryKey"), 'error');
            $('#txtNews').focus();
            return;
        }

        $('#btnSaveInstitutionNews').prop('disabled', 'disabled');

        $.ajax({
            method: 'Post',
            url: model.InstitutionNewsId == 0 ? "/Admin/CreateInstitutionNews" : "/Admin/UpdateInstitutionNews",
            data: { institutionNewsModelObj: model },
            success: function (e) {
                $('#btnSaveInstitutionNews').removeAttr('disabled');
                Alert(localizationLib.getLocalizeData("institutionNewsUpdateSuccessKey"), 'Success');
                institutionnews.clearInstitutionNews();
                $('#btntopclose').trigger('click');
            },
            error: function (e) {
                $('#btnSaveInstitutionNews').removeAttr('disabled');
                var msg = JSON.parse(e.responseText);
                Alert(msg.detail, 'error');
                Alert(localizationLib.getLocalizeData("FailedToinstitutionNewsKey"), 'error');
            }
        })
    }

    public.deleteInstitutionNews = function (id) {
        if (confirm('Are you sure, you want delete Institution News')) {
            $.ajax({
                method: 'Post',
                url: "/Admin/DeleteInstitutionNews",
                data: { institutionNewsId: id },
                success: function (e) {
                    Alert(localizationLib.getLocalizeData("InstitutionNewsDeleteMsgKey"), 'Success');
                    institutionnews.showInstitutionNews();
                },
                error: function (e) {
                    var msg = JSON.parse(e.responseText);
                    Alert(msg.detail, 'error');
                    Alert(localizationLib.getLocalizeData("InstitutionNewsFailedDeleteKey"), 'error');
                }
            })
        }
    }

    public.clearInstitutionNews = function () {
        $('#hdnInstitutionNewsId').val(0);
        $('#hdnInstitutionId').val(0);
        $('#ddlInstitutions').val(0);
        $('#txtTitle').val('');
        $('#txtNews').val('');
        $('#txtDescription').val('');
        $('#txtStartDate').val('');
        $('#txtEndDate').val('');
    }

    return public;
})();