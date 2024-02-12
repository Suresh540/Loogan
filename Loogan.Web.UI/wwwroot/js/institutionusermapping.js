var institutionusermapping = (function () {
    var public = {};

    public.ddlUserRoles = function () {
        if (document.getElementById('ddlUserType') == undefined) {
            return;
        }
        $.ajax({
            method: 'Post',
            url: "/Admin/GetUserRoles",
            data: {},
            success: function (response) {
                var dropDownListId = $('#ddlUserType');
                dropDownListId.append($("<option></option>").val("").html("Please Select"));
                $.each(response, function () {
                    if (this['userType'] != 'Admin')
                        dropDownListId.append($("<option></option>").val(this['userTypeId']).html(this['userType']));
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

    public.institutionUserTypeChange = function() {

        let selectedInstValue = $('#ddlInstitutions').val();
        let selectedUserTypeValue = $('#ddlUserType').val();
        if (selectedInstValue > 0 && selectedUserTypeValue > 0) {
            $.ajax({
                method: 'GET',
                url: `/User/InstitutionUserChange?selectedInstitutionVal=${document.getElementById('ddlInstitutions').value}&selectedUserTypeVal=${document.getElementById('ddlUserType').value}`,
                success: function (e) {
                    let users = e.actualUsers;
                    let sUsers = e.selectUsers
                    $('#actualUser').empty();
                    $('#selectedUser').empty();

                    $.each(users, function () {
                        let item = this;
                        $('#actualUser').append($("<option></option>")
                            .attr("value", item.userId)
                            .text(item.userName));
                    });

                    $.each(sUsers, function () {
                        let item = this;
                        $('#selectedUser').append($("<option></option>")
                            .attr("value", item.userId)
                            .text(item.userName));
                    });
                },
                error: function (e) {
                    console.log(e);
                }
            });
        }
    }

    public.moveUserItemstoleft = function() {
        $.each($("#selectedUser option:selected"), function () {
            var item = this;
            $(this).remove();
            $('#actualUser').append($("<option></option>")
                .attr("value", $(item).val())
                .text($(item).html()));
        });
    }
    public.moveUserItemstoright = function() {
        $.each($("#actualUser option:selected"), function () {
            var item = this;
            $(this).remove();
            $('#selectedUser').append($("<option></option>")
                .attr("value", $(item).val())
                .text($(item).html()));
        });
    }

    public.createinstitutionUsers = function() {
        var request = [];
        $.each($("#selectedUser option"), function () {
            var saveInstitutionRequest = {};
            saveInstitutionRequest.institutionUserMappingId = 0
            saveInstitutionRequest.institutionId = $('#ddlInstitutions option:selected').val();
            saveInstitutionRequest.userTypeId = $('#ddlUserType option:selected').val();
            saveInstitutionRequest.userId = $(this).val();
            request.push(saveInstitutionRequest);
        });
        if (request.length == 0) {
            Alert(localizationLib.getLocalizeData("SelectChangesKey"), 'error');
            return;
        }
        $.ajax({
            method: 'Post',
            url: "/User/SaveInstitutionUsers",
            data: { request: request },
            success: function (e) {
                Alert(localizationLib.getLocalizeData("DataSavedKey"), 'Success');
            },
            error: function (e) {
                Alert(localizationLib.getLocalizeData("FailedSaveKey"), 'error');
            }
        })
    }

    return public;
})();