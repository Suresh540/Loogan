var institution = (function () {

    var public = {};
    public.showInstitution = function (pageIndex, pageSize) {
        setTimeout(() => {
            var model = {};
            model.pagesize = pageSize == undefined ? 10 : pageSize;
            model.pageIndex = pageIndex == undefined ? 1 : pageIndex;
            model.totalRecords = getTotalRecords();
            $.ajax({
                method: 'Post',
                url: "/Admin/GetAllInstitutions",
                data: { pageModel: model },
                success: function (data) {
                    $('#tdBody').empty();

                    if (data != null && data != undefined && data.length > 0) {
                        setTotalRecords(data[0].totalRecords);

                        for (var item of data) {
                            let index = item.institutionId
                            $('#tdBody').append(`<tr>
                        <td class="text-danger anchornounderline" title="Delete institution" onclick="institution.deleteInstitution('${index}')">X</td>
                        <td><a id="institutionname${index}" href="#" data-toggle="modal" data-target="#top_modal" onclick="return institution.institutionEdit(${index})" style="cursor:pointer">${item.institutionName}</a></td>
                        <td id="instaddress${index}">${item.address == null ? "" : item.address }</td>
                        <td id="instphonenumber${index}">${item.phoneNumber == null ? "" : item.phoneNumber}</td>
                        <td id="instwebsite${index}">${item.website == null ? "" : item.website}</td>
                        <td id="instmission${index}">${item.mission == null ? "" : item.mission}</td>
                        <td id="instvision${index}">${item.vision == null ? "" : item.vision}</td>
                        <td style="display:none" id="instdescription${index}">${item.description == null ? "" : item.description}</td>
                        <td style="display:none" id="instemailaddress${index}">${item.emailAddress == null ? "" : item.emailAddress}</td>
                        <td style="display:none" id="instinstitutionimageUrl${index}">${item.institutionImageUrl == null ? "" : item.institutionImageUrl}</td>
                        <td style="display:none" id="instadditionalcomments${index}">${item.additionalComments == null ? "" : item.additionalComments}</td>
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

    public.institutionEdit = function (index) {
        $('#hdnInstitutionId').val(index);
        $('#txtInstitutionName').val($('#institutionname' + index).html());
        $('#txtDescription').val($('#instdescription' + index).html());
        $('#txtAddress').val($('#instaddress' + index).html());
        $('#txtPhoneNumber').val($('#instphonenumber' + index).html());
        $('#txtEmailAddress').val($('#instemailaddress' + index).html());
        $('#txtWebsite').val($('#instwebsite' + index).html());
        $('#txtLogo').val($('#instinstitutionimageUrl' + index).html());
        $('#txtMission').val($('#instmission' + index).html());
        $('#txtVision').val($('#instvision' + index).html());
        $('#txtComments').val($('#instadditionalcomments' + index).html());

        $('#btnCreateClose').trigger('click');

        return false;
    }

    public.createInstitution = function () {
        var model = {}
        model.institutionId = $('#hdnInstitutionId').val();
        model.institutionName = $('#txtInstitutionName').val();
        model.description = $('#txtDescription').val();
        model.address = $('#txtAddress').val();
        model.phoneNumber = $('#txtPhoneNumber').val();
        model.emailAddress = $('#txtEmailAddress').val();
        model.website = $('#txtWebsite').val();
        
        model.mission = $('#txtMission').val();
        model.vision = $('#txtVision').val();
        model.additionalComments = $('#txtComments').val();
        var input = document.getElementById("ImagePathFile");
        var files = input.files;
        var formData = new FormData();

        for (var i = 0; i != files.length; i++) {
            formData.append("files", files[i]);
            model.institutionImageUrl = files[i].name;
        }
        formData.append("model", JSON.stringify(model));
        if ($('#txtInstitutionName').val().trim() == '') {
            Alert(localizationLib.getLocalizeData("InstitutionNameMandatoryKey"), 'error');
            $('#txtInstitutionName').focus();
            return;
        }

        $('#btnSaveInstitution').prop('disabled', 'disabled');

        $.ajax({
            method: 'Post',
            url: model.institutionId == 0 ? "/Admin/CreateInstitution" : "/Admin/UpdateInstitution",
            processData: false,
            contentType: false,
            data: formData,
            success: function (e) {
                $('#btnSaveInstitution').removeAttr('disabled');
                Alert(localizationLib.getLocalizeData("institutionUpdateSuccessKey"), 'Success');
                institution.clearInstitution();
                $('#btntopclose').trigger('click');
            },
            error: function (e) {
                $('#btnSaveInstitution').removeAttr('disabled');
                var msg = JSON.parse(e.responseText);
                Alert(msg.detail, 'error');
                Alert(localizationLib.getLocalizeData("FailedToinstitutionKey"), 'error');
            }
        })
    }

    public.deleteInstitution = function (id) {
        if (confirm('Are you sure, you want delete Institution')) {
            $.ajax({
                method: 'Post',
                url: "/Admin/DeleteInstitution",
                data: { institutionId: id },
                success: function (e) {
                    Alert(localizationLib.getLocalizeData("InstitutionDeleteMsgKey"), 'Success');
                    institution.showInstitution();
                },
                error: function (e) {
                    var msg = JSON.parse(e.responseText);
                    Alert(msg.detail, 'error');
                    Alert(localizationLib.getLocalizeData("InstitutionFailedDeleteKey"), 'error');
                }
            })
        }
    }

    public.clearInstitution = function () {
        $('#hdnInstitutionId').val(0);
        $('#txtInstitutionName').val('');
        $('#txtDescription').val('');
        $('#txtAddress').val('');
        $('#txtPhoneNumber').val('');
        $('#txtEmailAddress').val('');
        $('#txtWebsite').val('');
        $('#txtLogo').val('');
        $('#txtMission').val('');
        $('#txtVision').val('');
        $('#txtComments').val('');
    }

    public.ddlinstitution = function () {
        if (document.getElementById('ddlInstitutions') == undefined) {
            return;
        }
        $.ajax({
            method: 'Post',
            url: "/Admin/GetInstitutionsList",
            data: {},
            success: function (response) {
                var dropDownListId = $('#ddlInstitutions');
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

    return public;
})();