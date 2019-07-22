function Common() {
    _this = this;

    this.init = function () {
        $("#LoginPopup").click(function () {
            _this.showPopup("/Login/LoginAjax", initLoginPopup);
        });
    }

    this.init = function () {
        $("#RegisterPopup").click(function () {
            _this.showPopup("/User/RegisterAjax", initRegisterPopup);
        });
    }

    this.showPopup = function (url, callback) {
        $.ajax({
            type: "GET",
            url: url,
            success: function (data) {
                showModalData(data, callback);
            }
        });
    }

    function initLoginPopup(modal) {
        $("#LoginButton").click(function () {
            $.ajax({
                type: "POST",
                url: "/Login/LoginAjax",
                data: $("#LoginForm").serialize(),
                success: function (data) {
                    showModalData(data);
                    initLoginPopup(modal);
                }
            });
        });
    }

    function initRegisterPopup(modal) {
        $("#RegisterButton").click(function () {
            $.ajax({
                type: "POST",
                url: "/User/RegisterAjax",
                data: $("#RegisterForm").serialize(),
                success: function (data) {
                    showModalData(data);
                    initRegisterPopup(modal);
                }
            });
        });
    }

    function showModalData(data, callback) {
        $(".modal-backdrop").remove();
        var popupWrapper = $("#PopupWrapper");
        popupWrapper.empty();
        popupWrapper.html(data);
        var popup = $(".modal", popupWrapper);
        $(".modal", popupWrapper).modal();
        if (callback != undefined) {
            callback(popup);
        }
    }
}

var common = null;
$().ready(function () {
    common = new Common();
    common.init();
});