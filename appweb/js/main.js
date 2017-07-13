/**
 * Created by lili on 17/7/12.
 */

$(document).ready(function () {
    var mySwiper1 = new Swiper('#swiper1', {
        loop: true,
        autoplay: 3000,
        pagination: '.pagination'
    });
    var mySwiper2 = new Swiper('#swiper2', {
        loop: true,
        autoplay: 3000
    });

    $(".menuNavTip.icon-menuNavTip,.content-cover").click(function () {
        $(".open-wait").toggleClass("open");
    });


    $(window).on("resize", function () {
        window.getHtmlSize();
    });

    $("#hot_con1").show().liMarquee({
        hoverstop: false
    });
    setTimeout(function () {
        $("#hot_con2").show().liMarquee({
            hoverstop: false,
            scrollamount: 90
        })
    }, 1000)


});