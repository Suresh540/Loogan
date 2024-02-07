var institutionannouncement = (function () {

    var public = {};
    public.showInstitutionAnnouncements = function (pageIndex, pageSize) {
        setTimeout(() => {
            var model = {};
            model.pagesize = pageSize == undefined ? 10 : pageSize;
            model.pageIndex = pageIndex == undefined ? 1 : pageIndex;
            model.totalRecords = getTotalRecords();
            $.ajax({
                method: 'Post',
                url: "/Admin/GetAllInstitutionAnnouncement",
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
                        <td id="insnewannouncement1${index}">${item.announcement == null ? "" : item.announcement}</td>
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
                    console.log(e);
                }
            })

        }, 1000)
    }

    public.institutionAnnouncementEdit = function (index) {
        $('#hdnInstitutionNewsId').val(index);
        $('#hdnInstitutionId').val($('#instnewsinstitutionId' + index).html());
        $('#ddlInstitutions').val($('#instnewsinstitutionId' + index).html())
        $('#txtTitle').val($('#insnewstitle' + index).html());
        $('#txtAnnouncement').val($('#insnewannouncement1' + index).html());
        $('#txtDescription').val($('#instnewsdescription' + index).html());
        $('#txtStartDate').val($('#instnewsstartDate' + index).html());
        $('#txtEndDate').val($('#instnewsendate' + index).html());

        $('#btnCreateClose').trigger('click');

        return false;
    }

    public.createInstitutionAnnouncement = function () {
        var model = {}
        model.institutionNewsId = $('#hdnInstitutionAnnouncementId').val();
        model.institutionId = $('#ddlInstitutions').val();
        model.title = $('#txtTitle').val();
        model.announcement = $('#txtAnnouncement').val();
        model.description = $('#txtDescription').val();
        model.startDate = $('#txtStartDate').val();
        model.endDate = $('#txtEndDate').val();

        if ($('#txtTitle').val().trim() == '') {
            Alert(localizationLib.getLocalizeData("InstitutionAnnouncementTitleMandatoryKey"), 'error');
            $('#txtTitle').focus();
            return;
        }

        if ($('#txtAnnouncement').val().trim() == '') {
            Alert(localizationLib.getLocalizeData("InstitutionAnnouncementMandatoryKey"), 'error');
            $('#txtAnnouncement').focus();
            return;
        }

        $('#btnSaveInstitutionAnnouncements').prop('disabled', 'disabled');

        $.ajax({
            method: 'Post',
            url: model.InstitutionAnnouncementId == 0 ? "/Admin/CreateInstitutionAnnouncement" : "/Admin/UpdateInstitutionAnnouncement",
            data: { instituationAnnouncementViewModel: model },
            success: function (e) {
                $('#btnSaveInstitutionAnnouncements').removeAttr('disabled');
                Alert(localizationLib.getLocalizeData("institutionAnnouncementsUpdateSuccessKey"), 'Success');
                institutionannouncement.clearInstitutionAnnouncement();
                $('#btntopclose').trigger('click');
            },
            error: function (e) {
                $('#btnSaveInstitutionAnnouncements').removeAttr('disabled');
                var msg = JSON.parse(e.responseText);
                Alert(msg.detail, 'error');
                Alert(localizationLib.getLocalizeData("FailedToinstitutionAnnouncementsKey"), 'error');
            }
        })
    }

    public.deleteInstitutionAnnouncement = function (id) {
        if (confirm('Are you sure, you want delete Institution Announcement')) {
            $.ajax({
                method: 'Post',
                url: "/Admin/DeleteInstitutionAnnouncement",
                data: { institutionNewsId: id },
                success: function (e) {
                    Alert(localizationLib.getLocalizeData("InstitutionAnnouncementsDeleteMsgKey"), 'Success');
                    institutionannouncement.showInstitutionAnnouncements();
                },
                error: function (e) {
                    var msg = JSON.parse(e.responseText);
                    Alert(msg.detail, 'error');
                    Alert(localizationLib.getLocalizeData("InstitutionAnnouncementsFailedDeleteKey"), 'error');
                }
            })
        }
    }

    public.clearInstitutionAnnouncement = function () {
        $('#hdnInstitutionAnnouncementId').val(0);
        $('#hdnInstitutionId').val(0);
        $('#ddlInstitutions').val(0);
        $('#txtTitle').val('');
        $('#txtAnnouncement').val('');
        $('#txtDescription').val('');
        $('#txtStartDate').val('');
        $('#txtEndDate').val('');
    }

    return public;
})();