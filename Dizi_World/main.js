function menukat() {
    document.getElementById("kat_menu").style.display = "block";
}
function menukatc() {
    document.getElementById("kat_menu").style.display = "none";
}
function menu() {
    document.getElementById("menu").style.display = "block";

}
function slider_left(a) {
    document.getElementsByClassName("side")[a-1].style = ("display:inline-block;");
    document.getElementsByClassName("side")[a].style = ("display:none");
    var video1 = document.getElementsByClassName("video")[a-1];
    video1.play();
    var video2 = document.getElementsByClassName("video")[a];
    video2.pause();
}
function slider_right(a) {
    document.getElementsByClassName("side")[a+1].style = ("display:inline-block;");
    document.getElementsByClassName("side")[a].style = ("display:none");
    var video1 = document.getElementsByClassName("video")[a+1];
    video1.play();
    var video2 = document.getElementsByClassName("video")[a];
    video2.pause();
}

function slider_box_li(a) {
    var i;
    for (i = 0; i < 5;i++)
    {
        if (i == a)
            document.getElementsByClassName("slider-box-li")[i].style = ("width:22%; height:110px;");
        else
            document.getElementsByClassName("slider-box-li")[i].style = ("width:16%; height:90px; margin-top:1.5%");
    }
        
}

function content_display(a) {
    document.getElementsByClassName("content-box-side-playbutton")[a].style = ("display:block;");
    document.getElementsByClassName("content-box-side-text")[a].style = ("display:block;");
}

function content_display_none(a) {
    document.getElementsByClassName("content-box-side-playbutton")[a].style = ("display:none;");
    document.getElementsByClassName("content-box-side-text")[a].style = ("display:none;");
}

function content_left_button(a) {
    document.getElementsByClassName("content-box-side")[a-1].style = ("display:flex;");
    document.getElementsByClassName("content-box-side")[a].style = ("display:none;");
}
function content_right_button(a) {
    document.getElementsByClassName("content-box-side")[a+1].style = ("display:flex;");
    document.getElementsByClassName("content-box-side")[a].style = ("display:none;");
}

function comn_form() {
    document.getElementById("comn-form-id").style = ("display:block;");
}
function login_box_close() {
    document.getElementById("login_box_id").style = ("display:none;");
}
function record_box_close() {
    document.getElementById("record_box_id").style = ("display:none;");
}

function movies_open(row,box) { //burayı düzelt
    
    
    
    document.getElementsByClassName("movies-row-box")[row].style = ("width:80%;");
    var mod = box % 4;
        switch (mod) {
            case 0:   
                document.getElementsByClassName("movies-box")[box].style = ("width:30%; height:230px; transition-property: all; transition-duration: 700ms;transition-timing-function:ease-in-out;");
                document.getElementsByClassName("movies-box")[box + 1].style = ("width:22%; margin-top:1%; transition-property: all; transition-duration: 1000ms;transition-timing-function: linear;");
                document.getElementsByClassName("movies-box")[box + 2].style = ("width:22%; margin-top:1%; transition-property: all; transition-duration: 1000ms;transition-timing-function: linear;");
                document.getElementsByClassName("movies-box")[box + 3].style = ("width:22%; margin-top:1%; transition-property: all; transition-duration: 1000ms;transition-timing-function: linear;");
                break;
            case 1:
                document.getElementsByClassName("movies-box")[box - 1].style = ("width:22%; margin-top:1%; transition-property: all; transition-duration: 1000ms;transition-timing-function: linear;");
                document.getElementsByClassName("movies-box")[box].style = ("width:30%; height:230px; transition-property: all; transition-duration: 700ms;transition-timing-function:ease-in-out;");
                document.getElementsByClassName("movies-box")[box + 1].style = ("width:22%; margin-top:1%; transition-property: all; transition-duration: 1000ms;transition-timing-function: linear;");
                document.getElementsByClassName("movies-box")[box + 2].style = ("width:22%; margin-top:1%; transition-property: all; transition-duration: 1000ms;transition-timing-function: linear;");
                break;
            case 2:
                document.getElementsByClassName("movies-box")[box - 2].style = ("width:22%; margin-top:1%; transition-property: all; transition-duration: 1000ms;transition-timing-function: linear;");
                document.getElementsByClassName("movies-box")[box - 1].style = ("width:22%; margin-top:1%; transition-property: all; transition-duration: 1000ms;transition-timing-function: linear;");
                document.getElementsByClassName("movies-box")[box].style = ("width:30%; height:230px; transition-property: all; transition-duration: 700ms;transition-timing-function:ease-in-out;");
                document.getElementsByClassName("movies-box")[box + 1].style = ("width:22%; margin-top:1%; transition-property: all; transition-duration: 1000ms;transition-timing-function: linear;");
                break;
            case 3:
                document.getElementsByClassName("movies-box")[box - 3].style = ("width:22%; margin-top:1%; transition-property: all; transition-duration: 1000ms;transition-timing-function: linear;");
                document.getElementsByClassName("movies-box")[box - 2].style = ("width:22%; margin-top:1%; transition-property: all; transition-duration: 1000ms;transition-timing-function: linear;");
                document.getElementsByClassName("movies-box")[box - 1].style = ("width:22%; margin-top:1%; transition-property: all; transition-duration: 1000ms;transition-timing-function: linear;");
                document.getElementsByClassName("movies-box")[box].style = ("width:30%; height:230px; transition-property: all; transition-duration: 700ms;transition-timing-function:ease-in-out;");
                break;
        }  
}
function movies_close(row, box) {

    document.getElementsByClassName("movies-row-box")[row].style = ("width:60%;");
    var mod = box % 4;
    switch (mod) {
        case 0:
            document.getElementsByClassName("movies-box")[box].style = ("width:24%; height:200px; transition-property: all; transition-duration: 700ms;transition-timing-function: linear;");
            document.getElementsByClassName("movies-box")[box + 1].style = ("width:24%; margin-top:0px; transition-property: all; transition-duration: 1000ms;transition-timing-function: linear;");
            document.getElementsByClassName("movies-box")[box + 2].style = ("width:24%; margin-top:0px; transition-property: all; transition-duration: 1000ms;transition-timing-function: linear;");
            document.getElementsByClassName("movies-box")[box + 3].style = ("width:24%; margin-top:0px; transition-property: all; transition-duration: 1000ms;transition-timing-function: linear;");
            break;
        case 1:
            document.getElementsByClassName("movies-box")[box - 1].style = ("width:24%; margin-top:0px; transition-property: all; transition-duration: 1000ms;transition-timing-function: linear;");
            document.getElementsByClassName("movies-box")[box].style = ("width:24%; height:200px; transition-property: all; transition-duration: 700ms;transition-timing-function: linear;");
            document.getElementsByClassName("movies-box")[box + 1].style = ("width:24%; margin-top:0px; transition-property: all; transition-duration: 1000ms;transition-timing-function: linear;");
            document.getElementsByClassName("movies-box")[box + 2].style = ("width:24%; margin-top:0px; transition-property: all; transition-duration: 1000ms;transition-timing-function: linear;");
            break;
        case 2:
            document.getElementsByClassName("movies-box")[box - 2].style = ("width:24%; margin-top:0px; transition-property: all; transition-duration: 1000ms;transition-timing-function: linear;");
            document.getElementsByClassName("movies-box")[box - 1].style = ("width:24%; margin-top:0px; transition-property: all; transition-duration: 1000ms;transition-timing-function: linear;");
            document.getElementsByClassName("movies-box")[box].style = ("width:24%; height:200px; transition-property: all; transition-duration: 700ms;transition-timing-function: linear;");
            document.getElementsByClassName("movies-box")[box + 1].style = ("width:24%; margin-top:0px; transition-property: all; transition-duration: 1000ms;transition-timing-function: linear;");
            break;
        case 3:
            document.getElementsByClassName("movies-box")[box - 3].style = ("width:24%; margin-top:0px; transition-property: all; transition-duration: 1000ms;transition-timing-function: linear;");
            document.getElementsByClassName("movies-box")[box - 2].style = ("width:24%; margin-top:0px; transition-property: all; transition-duration: 1000ms;transition-timing-function: linear;");
            document.getElementsByClassName("movies-box")[box - 1].style = ("width:24%; margin-top:0px; transition-property: all; transition-duration: 1000ms;transition-timing-function: linear;");
            document.getElementsByClassName("movies-box")[box].style = ("width:24%; height:200px; transition-property: all; transition-duration: 700ms;transition-timing-function: linear;");
            break;
    }
}
function movies_content_display(a) {
    document.getElementsByClassName("movies-icon")[a].style = ("display:block;");
    document.getElementsByClassName("movies-name")[a].style = ("display:block;");
    document.getElementsByClassName("movies-about")[a].style = ("display:block;");
}
function movies_content_display_none(a) {
    document.getElementsByClassName("movies-icon")[a].style = ("display:none;");
    document.getElementsByClassName("movies-name")[a].style = ("display:none;");
    document.getElementsByClassName("movies-about")[a].style = ("display:none;");
}

function details_icon_display(a) {
    document.getElementsByClassName("season-box-item-icon")[a].style = ("display:block;");
}
function details_icon_display_none(a) {
    document.getElementsByClassName("season-box-item-icon")[a].style = ("display:none;");
}
function kul_menu_box_open() {
    document.getElementsByClassName("kul-menu-box")[0].style = ("display:block;");
}
function kul_menu_box_close(){
    document.getElementsByClassName("kul-menu-box")[0].style = ("display:none;");
}



