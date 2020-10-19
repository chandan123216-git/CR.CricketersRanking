var loginModule = function() {

    function init() {
    }

    function authenticateUser() {
        var Username = document.getElementById("idUsername").value;
        var Password = document.getElementById("idPassword").value;

        var user = {};
        user.Username = Username;
        user.Password = Password;

        $.ajax({
            url: '/Login/authenticateUser',
            method: 'POST',
            async: true,
            contentType: "application/json; charset=utf-8",
            data: JSON.stringify(user),
            success: function (result) {
                console.log(result);
                var path = window.location.protocol + "//" + window.location.host + "/CricktersPoll";
                console.log(path);
                if (result) {
                    location.href = path;
                    console.log(result);
                }
            }
        });
    }

    return {
        init : init,
        authenticateUser : authenticateUser
    };
}();

