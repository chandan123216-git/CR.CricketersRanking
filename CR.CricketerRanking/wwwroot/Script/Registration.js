var registrationModule = function () {

    function init() {
    }

    function registerUser() {

        debugger

        var username = document.getElementById("idUsername").value;  
        var password = document.getElementById("idPassword").value;
        var firstname = document.getElementById("idFirstname").value;
        var lastname = document.getElementById("idLastname").value;

        var user = {};
        user.Username = username;
        user.Password = password;
        user.Firstname = firstname;
        user.Lastname = lastname;
        
        $.ajax({
            url: '/Registration/RegisterUser',
            method: 'POST',
            async: true,
            contentType: "application/json; charset=utf-8",
            data : JSON.stringify(user),
            success: function (data) {
                console.log(data);
            }
        });
    }

    /*
    void Fun(String username , string password){
        
    }
    */
    return {
        init: init,
        registerUser: registerUser
    };

}();

