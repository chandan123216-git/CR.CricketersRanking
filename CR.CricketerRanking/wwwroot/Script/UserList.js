var userlistModule = function () {

    function init() {
    }

    function authenticateUser() {
        debugger
    }

    function getBatsman()
    {
        $.ajax({
            url: '/UserList/GetBatsman',
            method: 'GET',
            async: true,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                console.log(data);
            }
        });
    }

    function getBowler() {
        $.ajax({
            url: '/UserList/GetBowler',
            method: 'GET',
            async: true,
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                console.log(data);
            }
        });
    }
    
    function CountBatsmanCheckbox() {
        var iCount = $('#divbatsman').find('input[name="batsman"]:checked').length;
        if (iCount == 3) {
            $('input.chkbatsman:not(:checked)').attr('disabled', 'disabled');
        }
        else {
            $('input.chkbatsman').removeAttr('disabled');
        }
    }

    function CountBowlerCheckbox() {
        var iCount = $('#divbowler').find('input[name="bowler"]:checked').length;
        if (iCount == 3) {
            $('input.chkbowler:not(:checked)').attr('disabled', 'disabled');   
        }
        else {
            $('input.chkbowler').removeAttr('disabled');
        }
    }
    //////////////////////////////////  Backup  ///////////////////////////////////////////////
    /*function OnBowlerSubmit() {
        var bowlerArr = [];

        $("input:checkbox[name=bowlwe]:checked").each(function () {
            console.log($(this).val());
            bowlerArr.push($(this).val());
        });
        var playerIds = batsmanArr.toString();
        $.ajax({
            url: '/UserList/GetBatsman',
            method: 'GET',
            async: true,
            data: { playerIds: playerIds},
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                console.log(data);
            }
        });
    }*/
    ////////////////////////////////////////////////////////////////////////

    function OnBowlerSubmit() {

        debugger
        var userPoll = [];

        $("input:checkbox[name=bowler]").each(function () {
            console.log($(this).val());
            var userpoll = {};
            userpoll.PlayerID = parseInt($(this).val());
            userpoll.IsActive = $('#chk_' + $(this).val()).is(":checked");
            userPoll.push(userpoll);
        });
        console.log(userPoll);
      //  var playerIds = batsmanArr.toString();
        $.ajax({
            url: '/UserList/AddRanking',
            method: 'POST',
            async: true,
            data: JSON.stringify(userPoll),
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                console.log(data);
            }
        });
    }

    function OnBatsmanSubmit() {
        var userPoll = [];

        debugger
        $("input:checkbox[name=batsman]").each(function () {
            console.log($(this).val());
            var userpoll = {};
            userpoll.PlayerID = parseInt($(this).val());
            userpoll.IsActive = $('#chk_' + $(this).val()).is(":checked");
            userPoll.push(userpoll);
        });
        console.log(userPoll);

        $.ajax({
            url: '/UserList/AddRanking',
            method: 'POST',
            async: true,
            data: JSON.stringify(userPoll), 
            contentType: "application/json; charset=utf-8",
            success: function (data) {
                console.log(data);
            }
        });
    }

    return {
        init: init,
        getBatsman: getBatsman,
        CountBatsmanCheckbox: CountBatsmanCheckbox,
        CountBowlerCheckbox: CountBowlerCheckbox,
        OnBatsmanSubmit: OnBatsmanSubmit,
        OnBowlerSubmit: OnBowlerSubmit
    }

}();

