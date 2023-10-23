login = () => {
    let flag = true;
    let Lun = $('#email').val();
    let Lpa = $('#password').val();

    let mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;

    $("ello").css("color", "red");
    if (Lun == "") {
        $("#ello").html("please enter email");
        $('#email').focus();
        flag = false;
    } else if (Lun.match(mailformat) == null) {
        $("#ello").html("please enter valid email");
        $('#email').focus();
        flag = false;
    } else if (Lpa == "") {
        $("#ello").html("please enter password");
        $('#password').focus();
        flag = false;
    }
    return flag;
}


forget = () => {
    let flag = true;
    let fem = $('#femail').val();
    let mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
    $("err").css("color", "red");
    if (fem == "") {
        $("#err").html("please enter email");
        $('#femail').focus();
        flag = false;
    } else if (fem.match(mailformat) == null) {
        $("#err").html("please enter valid email");
        $('#femail').focus();
        flag = false;
    }
    return flag;
}
