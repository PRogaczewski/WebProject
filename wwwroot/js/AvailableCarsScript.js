	document.getElementById("DateFrom").onchange = function () { CheckDate() };
    document.getElementById("DateFrom").onchange = function () { MinDateTomorrowOnly() };

	function MinDateTomorrow() {
        var date = document.getElementById("DateFrom").value;

        var today = new Date(date);

        var dt = today.getDate() + 1;
        var mt = today.getMonth() + 1;
        var yyyt = today.getFullYear();

        var LastDay = new Date(yyyt, mt, 0); //last day of month (y)

        var isDay = LastDay.getDate();

        if (today.getDate() == isDay) {
            dt = 1;
            mt = today.getMonth() + 2;
        }

        if (dt < 10) {
            dt = '0' + dt
        }
        if (mt < 10) {
            mt = '0' + mt
        }

        tomorrow = yyyt + '-' + mt + '-' + dt;

        document.getElementById("DateTo").value = tomorrow;
        document.getElementById("DateTo").setAttribute("min", tomorrow);
    }

    function CheckDate() {
        var dateTemp = document.getElementById("DateFrom").value;
        var dateTempTo = document.getElementById("DateTo").value;

        var todayIf = new Date(dateTemp);
        var tomorrowIf = new Date(dateTempTo);

        if (todayIf.getTime() >= tomorrowIf.getTime()) {
            MinDateTomorrow();
        }
    }

    function MinDateTomorrowOnly() {
        var date = document.getElementById("DateFrom").value;

        var today = new Date(date);

        var dt = today.getDate() + 1;
        var mt = today.getMonth() + 1;
        var yyyt = today.getFullYear();

        var LastDay = new Date(yyyt, mt, 0); //last day of month (y)

        var isDay = LastDay.getDate();

        if (today.getDate() == isDay) {
            dt = 1;
            mt = today.getMonth() + 2;
        }

        if (dt < 10) {
            dt = '0' + dt
        }
        if (mt < 10) {
            mt = '0' + mt
        }

        tomorrow = yyyt + '-' + mt + '-' + dt;

        document.getElementById("DateTo").setAttribute("min", tomorrow);
    }