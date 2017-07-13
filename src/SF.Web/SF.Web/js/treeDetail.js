/**
 * Created by Lily on 2017/5/10.
 */
$(function () {
 $(".box-footer li").click(function () {
    $(".box-footer li").removeClass("active");
    $(this).addClass("active");
    var tab=$(this).attr("data-tab");
    $('.box-tab').hide();
    $(tab).show();

 })

})