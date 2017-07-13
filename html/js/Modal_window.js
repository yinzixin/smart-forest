/**
 * Created by wangli1 on 2017/5/26.
 */

$(function(){
    modal("你是不是想太多了啊");
})
function  modal(message){
    $(".model-cont-msg").text(message);
    $ ('.page-model').show ().delay (3000).fadeOut ();
}