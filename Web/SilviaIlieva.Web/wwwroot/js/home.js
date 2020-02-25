document.addEventListener("DOMContentLoaded", function () {
    var nav = document.getElementById("main-nav");
    showMenu(nav);

    document.getElementsByTagName("body")[0].onresize = function () {
        if (window.innerWidth > 1220) {
            nav.style.display = "block";
            document.getElementById("menu").style.display = "none";
        }
        else {
            nav.style.display = "none";
            document.getElementById("menu").style.display = "block";
        }
    }

    document.getElementById("menu").onclick = function () {
        console.log(nav.style.display);
        if (!nav.style.display || nav.style.display === "none") {
            nav.style.display = "block";
            showMenu(nav);
        } else if (nav.style.display === "block") {
            hideMenu(nav);
        }
    };

    function showMenu(nav) {
        if (nav) {
            var children = nav.querySelectorAll("li");
            if (children) {
                nav.animate([{ height: "0" }, { height: "436px" }], { duration: 700 });
                for (item of children) {
                    item.animate([{ width: "0", opacity: "0" }, { width: "294px", opacity: "1" }], { duration: 1200 });
                };
            }
        }
    }

    function hideMenu(nav) {
        if (nav) {
            var children = nav.querySelectorAll("li");
            if (children) {
                var animation = nav.animate([{ height: "436px" }, { height: "0" }], { duration: 700 });
                for (item of children) {
                    item.animate([{ width: "294px", opacity: "1" }, { width: "0", opacity: "0" }], { duration: 1200 });
                };
                animation.onfinish = function () {
                    nav.style.display = "none";
                }
            }
        }
    }

    var fly = document.getElementById("fly");
    setInterval(function () {
        var top = parseInt(window.getComputedStyle(fly)["top"]),
            left = parseInt(window.getComputedStyle(fly)["left"]),
            maxWidth = window.innerWidth - 65,
            maxHeight = window.innerHeight - 65,
            newLeft = getRandomInt(0, maxWidth),
            newTop = getRandomInt(0, maxHeight);
        fly.animate([{ top: top + "px", left: left + "px" }, { top: newTop + "px", left: newLeft + "px" }], { duration: 2000, fill: "forwards" });
    }, 2000);

    function getRandomInt(min, max) {
        min = Math.ceil(min);
        max = Math.floor(max);
        return Math.floor(Math.random() * (max - min + 1)) + min;
    }

    fly.addEventListener("click", function () {
        fly.animation.pause();
    })
});