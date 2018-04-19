$(document).ready(function () {
    moment.locale('ru');
    $(".thread-time").each(function () {
        $(this).append(moment($(this).attr("datetime"), "YYYYMMDDHHmmss").fromNow());
    });
    
}); 
$('.thread-text article').readmore({
    collapsedHeight: 90,
    speed: 75,
    moreLink: '<div class="thread-more"><a color="#9a64bd" href="#">Раскрыть</a></div>',
    lessLink: '<div class="thread-more"><a href="#">Свернуть</a></div>'
});