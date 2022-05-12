var seconds = 5;
    var element = document.getElementById("CountDown");
    element.innerHTML = seconds;
    setInterval(function () {
        seconds--;
        element.innerHTML = seconds;
        if (seconds == 0) {
            window.location.href = '/Index';
        }
    }, 1000);