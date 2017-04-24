/**
 * Created by wangli1 on 2017/4/21.
 */
$(function(){
   $(".radios").uniform();
       /* $(".tab-container .tab-navs a").click(function(){
          $(".tab-container .tab-navs a").removeClass("active");
          $(this).addClass("active");
        });*/
    function resetTabNav() {
        var st = $(window).scrollTop();

        $(".tab-container .tab-navs a").each(function (i, nav) {
            var target = $($(nav).attr('href'));
            if ((target).position().top < st) {
                $(".tab-container .tab-navs a").removeClass("active");
                $(nav).addClass('active');
            }
        });

    }

    function updateGap() {
        var wh = $(window).height() - $('.field-btn').position().top + $('#info_5').position().top - $('.field-btn').height();
        $('.scroll-gap').height(Math.max(0, wh));
    }
    $(window).scroll(resetTabNav);
    $(window).resize(updateGap);
    updateGap();
    resetTabNav();

})
