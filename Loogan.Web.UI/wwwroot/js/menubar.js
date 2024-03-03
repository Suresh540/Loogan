function fnMenubarLoad(userName, signout) {

    if (DoesitMobileOperator()) {
        $('.replace').css('display', 'none');
        $('#imgMenu').css('display', 'block');
        $('#ulMobMenu').css('display', 'block');

        if ($("#ulMobMenu").html() == undefined || $("#ulMobMenu").html() == '') {
            $('#ulMenu').find('li a').each((index, elm) => {
                let a = $(elm).removeAttr('style');
                $("#ulMobMenu").append('li').append(a[0]);
            })
        }
    }

    if ($("#ulMenu").html().trim() == '') {
        $.ajax({
            method: 'Post',
            url: "/Common/GetRoleMenus",
            success: function (data) {
                $("#ulMenu").append(`<li class="liSpace">
                            <img src="/images/profile.png" style="width:30px;height:30px" />
                            <a style="color:white;font-size:16px;" onclick="return navigateurl(this,'/Profile/Profile')">
                                 ${userName}
                            </a>`);
                for (let i of data) {
                    var menu = i.menuName;
                    $("#ulMenu").append(`<li class="liSpace">
                                            <img src="${i.menuIcon}" style="width:30px;height:30px" title="${menu}" />
                                            <a style="color:white;font-size:16px;" onclick="return navigateurl(this,'${i.menuUrl}')">${menu}</a>
                                    </li>`);

                }

                $("#ulMenu").append(`<li class="liSpace">
                                    <img src="/images/signout.png" style="width:30px;height:30px" title="${signout}" />
                                    <a style="color:white;font-size:16px;" href="/Logout">${signout}</a >
                                </li>`);

                if (DoesitMobileOperator()) {
                    $('.replace').css('display', 'none');
                    $('#imgMenu').css('display', 'block');
                    $('#ulMobMenu').css('display', 'block');

                    if ($("#ulMobMenu").html() == undefined || $("#ulMobMenu").html() == '') {
                        $('#ulMenu').find('li a').each((index, elm) => {
                            let a = $(elm).removeAttr('style');
                            $("#ulMobMenu").append('li').append(a[0]);
                        })
                    }
                }
            },
            error: function (e) {
                Alert(e, 'error')
            }
        });
    }
}
async function navigateurl(ctrl, url) {
    if (url == undefined || url.trim() == 'null' || url.trim() == '') {
        Alert('No url configured', 'error');
        return;
    }
    //To show the busy icon written function in site.js
    showloadinSymbol();

    const newState = { page: url };
    history.pushState(newState, '', url);
    const response = await fetch(url);
    let html = await response.text();
    var div = document.createElement('div');
    //Hide the busy icon written function in site.js
    hideloadingSymbol();

    $(div).html(html);
    $(div).find('.replace').css('display', 'none');
    $('#divrightLoad').html('');
    $('#divrightLoad').append(div);

    setTimeout(() => {
        $("#ulMenu").find('li').removeClass('btnactivetab');
        $(ctrl).parent().addClass('btnactivetab');
    }, 100);
    return false;
}

//[Detect is it mobile browser]
function DoesitMobileOperator() {
    const toMatch = [
        /Android/i,
        /webOS/i,
        /iPhone/i,
        /iPad/i,
        /iPod/i,
        /BlackBerry/i,
        /Windows Phone/i
    ];

    return toMatch.some((toMatchItem) => {
        return navigator.userAgent.match(toMatchItem);
    });
}

