    //----------------------------------------------------------- On Start Date
    var today = new Date();

    var dd = today.getDate();
    var mm = today.getMonth() + 1; //January is 0!
    var yyyy = today.getFullYear();

    if (dd < 10) {
        dd = '0' + dd
    }

    if (mm < 10) {
        mm = '0' + mm
    }

    today = yyyy + '-' + mm + '-' + dd;
    document.getElementById("DateFrom").setAttribute("value", today);
    document.getElementById("DateFrom").setAttribute("min", today);
    //------------------------------------------------------------ On End Date
    //var date = document.getElementById("DateFrom").value;
    var tomorrow = new Date();
    
    var dt = tomorrow.getDate() + 1;
    var mt = tomorrow.getMonth() + 1;
    var yyyt = tomorrow.getFullYear();
    if (dt < 10) {
        dt = '0' + dt
    }
    if (mt < 10) {
        mt = '0' + mt
    }

    tomorrow = yyyt + '-' + mt + '-' + dt;
    document.getElementById("DateTo").value = tomorrow;
    document.getElementById("DateTo").setAttribute("min", tomorrow);