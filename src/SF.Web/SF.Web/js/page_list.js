/**
 * Created by wangli1 on 2017/4/20.
 */
$(function(){
    $(".detail-block .page-li").on('click',function(){
        //alert(1111);
        $(this).find(".icon-xl").toggleClass("active");
        $(this).parent().find(".slist").slideToggle();
    });
    $(".filters").click(function(){
        $(".page-filter").show();
    });
    $(".page-up").click(function(){
        $(".page-filter").hide();
    })
   /* createTab($('.content-box'))*/
    $(".card-hover").hover(function(){
      $(this).find(".box-card").toggle();
    })
    $(".tree-logo").hover(function(){
        $(this).parent().find(".tag").toggle();
    })
})
$("table input").uniform();
//ÇÐ»»

/*function createTab(dom) {

    var containers = $('.tab-container', dom);
    $.each(containers, function (index, _container) {
        _container = $(_container);
        if (_container.hasClass('tabed')) {
            return;
        }
        //add tag
        _container.addClass('tabed');

        var _headers = $('>.tab-list>.tab-header', _container),
            _contents = $('>.tab-contents>.all-content', _container);

        $.each(_headers, function (index, _header) {
            $(_header).on('click', function () {
                active(index);
            });
        });

        var activeCover = $('.active-cover', _container);


        function active(index) {
            _headers.removeClass('active');
            $(_headers[index]).addClass('active');
            _contents.removeClass('active');
            $(_contents[index]).addClass('active');
            activeCover.removeClass('active-0 active-1 active-2 active-3');
            activeCover.addClass('active-' + index);

        }

        active(0);

    });
}*/
