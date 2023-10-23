editproduct = () => {
	let flag = true;
	let Run = $('#PrName').val();
	let Rpa = $('#PrPrize').val();
	let myf = $('#file').val();
	//let fg = $('#Prflag').val();
	//let PrName = $('#PrDescription').val();


	let letter = /^[a-zA-Z]+$/;
	let letter2 = /^[0-9.]+$/;
	//let letter3 = /^[0-9]+$/;
	$("elo").css("color", "red");


	if (Run == "") {
		$("#elo").html("please enter medicine Name");
		$('#PrName').focus();
		flag = false;
	} else if (Run.match(letter) == null) {
		$("#elo").html("please enter valid medicine Name");
		$('#PrName').focus();
		flag = false;
	}

	else if (Rpa == "") {
		$("#elo").html("please enter Prize");
		$('#PrPrize').focus();
		flag = false;
	}

	// else if (Lpa.match(passformat) == null) {
	else if (Rpa.match(letter2) == null) {
		$("#elo").html("only digits are allowed");
		$('#PrPrize').focus();
		flag = false;
	}

	else if (myf == "") {
		$("#elo").html("please enter medicine image");
		$('#file').focus();
		flag = false;
	}

	//else if (fg == "") {
	//	$("#elo").html("please enter flag");
	//	$('#PrDescription').focus();
	//	flag = false;
	//}
	//else if (fg.match(letter3) == null) {
	//	$("#elo").html("please enter valid  flag");
	//	$('#Prflag').focus();
	//	flag = false;
	//}
	//else if (PrName == "") {
	//	$("#elo").html("please enter descritption");
	//	$('#PrDescription').focus();
	//	flag = false;
	//}
	return flag;
}