$(function(){
    $(".radios").uniform();
    $(".tab-container .tab-navs a").click(function(){
      $(".tab-container .tab-navs a").removeClass("active");
      $(this).addClass("active");
    });

})
