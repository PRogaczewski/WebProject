	var today = new Date();
    var tomorrow = new Date();

    //today
    var dd = today.getDate();
    var mm = today.getMonth() + 1;
    var yyyy = today.getFullYear();
    if (dd < 10) {
        dd = '0' + dd
    }
    if (mm < 10) {
        mm = '0' + mm
    }

    //tomorrow
    var dt = tomorrow.getDate() + 1;
    var mt = tomorrow.getMonth() + 1;
    var yyyt = tomorrow.getFullYear();
    if (dt < 10) {
        dt = '0' + dt
    }
    if (mt < 10) {
        mt = '0' + mt
    }

    today = yyyy + '-' + mm + '-' + dd;
    tomorrow = yyyt + '-' + mt + '-' + dt;

    document.getElementById("DateFrom").setAttribute("min", today);
    document.getElementById("DateTo").setAttribute("min", tomorrow);
