using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace Dizi_World
{
    public partial class İndex : System.Web.UI.Page
    {
        public static int mesaj_deger = 0;
        private void Page_Load(object sender, EventArgs e)//load olunca her sayfa yüklediğinde tekrar çekiyor oyüzden Page_Init kullanılabilir.
        {
            if(Request.QueryString["mesaj_deger"]!=null && mesaj_deger==0)
            {                              
                Response.Write("<script>alert('Giriş Başarılı Hoşgeldiniz.')</script>");
                mesaj_deger = 1;
            }
            
            
            master_slider.InnerHtml = null;
            slider_box.InnerHtml = null;
            content.InnerHtml = null;
                Service_Reference_2.Sql_WebServiceSoapClient client = new Service_Reference_2.Sql_WebServiceSoapClient();
                DataSet db2 = new DataSet();
                db2 = client.slider();
                for (int sli = 0; sli < 5; sli++)
                {
                    if (sli != 0 && sli != 4)
                    {
                        master_slider.InnerHtml +=
                                 "<div class='side' style='display:none;'>" +
                                 "<i class='left-button fa fa-chevron-left'  aria-hidden='true' onclick='slider_left(" + sli + "); slider_box_li(" + (sli - 1) + ");'></i>" +
                                 "<a href='Details.aspx?dizi_id="+db2.Tables[0].Rows[sli][4]+"&sezon_id=1'><i class='play-button fa fa-play-circle' aria-hidden='true'></i></a>" +
                                 "<span class='film-name'>" + db2.Tables[0].Rows[sli][1] + "</span>" +
                                 "<span class='watch-name'>İzle</span>" +
                                 "<i class='fa fa-chevron-right right-button' aria-hidden='true' onclick='slider_right(" + sli + "); slider_box_li(" + (sli + 1) + ");'></i>" +
                                 "<video width ='100%' height='auto' autoplay muted loop class='video' >" +
                                     "<source src='videos/" + db2.Tables[0].Rows[sli][2] + "' type='video/mp4'/>" +
                               " </video> " +
                           "</div>";
                    }
                    else if (sli == 0)
                    {
                        master_slider.InnerHtml +=
                            "<div class='side'>" +
                            "<i class='left-button fa fa-chevron-left' aria-hidden='true'></i>" +
                            "<a href='Details.aspx?dizi_id=" + db2.Tables[0].Rows[sli][4] + "&sezon_id=1'><i class='play-button fa fa-play-circle' aria-hidden='true'></i></a>" +
                            "<span class='film-name'>" + db2.Tables[0].Rows[sli][1] + "</span>" +
                            "<span class='watch-name'>İzle</span>" +
                            "<i class='fa fa-chevron-right right-button' aria-hidden='true' onclick='slider_right(" + sli + "); slider_box_li(" + (sli + 1) + ");'></i>" +
                            "<video width ='100%' height='auto' autoplay muted loop class='video' >" +
                                "<source src='videos/" + db2.Tables[0].Rows[sli][2] + "' type='video/mp4'/>" +
                          " </video> " +
                      "</div>";
                    }
                    else if (sli == 4)
                    {
                        master_slider.InnerHtml +=
                            "<div class='side' style='display:none;'>" +
                            "<i class='left-button fa fa-chevron-left'  aria-hidden='true' onclick='slider_left(" + sli + "); slider_box_li(" + (sli - 1) + ")'></i>" +
                            "<a href='Details.aspx?dizi_id=" + db2.Tables[0].Rows[sli][4] + "&sezon_id=1'><i class='play-button fa fa-play-circle' aria-hidden='true'></i></a>" +
                            "<span class='film-name'>" + db2.Tables[0].Rows[sli][1] + "</span>" +
                            "<span class='watch-name'>İzle</span>" +
                            "<i class='fa fa-chevron-right right-button' aria-hidden='true'></i>" +
                            "<video width ='100%' height='auto' autoplay muted loop class='video' >" +
                                "<source src='videos/" + db2.Tables[0].Rows[sli][2] + "' type='video/mp4'/>" +
                          " </video> " +
                      "</div>";
                    }

                }
                slider_box.InnerHtml +=
                        "<ul>";
                for (int slb = 0; slb < 5; slb++)
                {

                    slider_box.InnerHtml += "<li class='slider-box-li'><img src='images/" + db2.Tables[0].Rows[slb][3] + "'/></li>";

                }
                slider_box.InnerHtml += "</ul>";



                DataSet db = new DataSet();
                int js_indisi = 0;
                int dizi_side_sayisi = 0;
                int js_left_button = 0;
                int js_right_button = 0;
                for (int i = 0; i < 3; i++)//content-box için
                {
                    db = client.diziler_genelkategori(i+1);
                    double content_box_side_count = db.Tables[0].Rows.Count;
                    content_box_side_count = Math.Ceiling(content_box_side_count / 4);
                    int sinir = db.Tables[0].Rows.Count;
                    content.InnerHtml += "<div class='content-box'><br/><span>"+db.Tables[0].Rows[i][5]+"</span>";
                    for (int j = 0; j <content_box_side_count; j++)//content-box-side için
                    {
                        if (j>0)
                        {
                            content.InnerHtml += "<div class='content-box-side' style='display:none'>" +
                             "<i class='content-box-side-button fa fa-chevron-left' onclick='content_left_button(" + js_left_button + ");' aria-hidden='true'></i>";
                            js_left_button += 1;
                        }
                        else
                        {
                            content.InnerHtml += "<div class='content-box-side'>" +
                                "<i class='content-box-side-button fa fa-chevron-left' aria-hidden='true'></i>";
                            js_left_button += 1;
                        }
                        
                        for (int k = 0; k < 4; k++)//content-box-side-item için
                        {
                            content.InnerHtml +=
                                       "<div class='content-box-side-item' onmousemove='content_display(" + js_indisi + ");' onmouseout='content_display_none(" + js_indisi + ");'>" +
                                       "<a href='Details.aspx?dizi_id=" + db.Tables[0].Rows[dizi_side_sayisi][0] + "&sezon_id=1''><i class='content-box-side-playbutton fa fa-play-circle' aria-hidden='true'></i></a>" +
                                       "<img src ='images/" + db.Tables[0].Rows[dizi_side_sayisi][3] + "' title='" + db.Tables[0].Rows[dizi_side_sayisi][1] + "' width='100%' height='100%'/>" +
                                       "<p class='content-box-side-text'>" + db.Tables[0].Rows[dizi_side_sayisi][4] + "</p>" +
                                       "</div>";
                            js_indisi += 1;
                            dizi_side_sayisi += 1;
                            if (dizi_side_sayisi == sinir)
                                break;
                        
                        }
                        if(j==content_box_side_count-1)
                        {
                            content.InnerHtml += "<i class='content-box-side-button fa fa-chevron-right'  aria-hidden='true'></i></div>";
                            js_right_button += 1;
                        }
                            
                        else
                        {
                            content.InnerHtml += "<i class='content-box-side-button fa fa-chevron-right' onclick='content_right_button(" + js_right_button + ");' aria-hidden='true'></i></div>";
                            js_right_button += 1;
                        }
                            


                }
                    
                    dizi_side_sayisi = 0;              
                    content.InnerHtml += "</div> <br>";
                }
            db = client.diziler_genelkategori(4);
            int indis = 0; 
            content.InnerHtml += "<br/><div class='content-box'><span>" + db.Tables[0].Rows[0][5] + "</span><br/><br/>";
            for(int ctb=0; ctb<2;ctb++)
            {
                content.InnerHtml += "<div class='content-theree-box'>";
                for (int ctb2=0;ctb2<3;ctb2++)
                {
                    content.InnerHtml+= 
                        "<div class='content-box-side-item' onmousemove='content_display("+js_indisi+");' onmouseout='content_display_none("+js_indisi+");'>"+
                             "<img src ='images/"+db.Tables[0].Rows[indis][3]+ "' alt = '" + db.Tables[0].Rows[indis][1] + "' title = '" + db.Tables[0].Rows[indis][1] + "' width = '100%' height = '100%' />"+
                             "<a href='Details.aspx?dizi_id=" + db.Tables[0].Rows[indis][0] + "&sezon_id=1''><i class='content-box-side-playbutton fa fa-play-circle' aria-hidden='true'></i></a>" +
                             "<p class='content-box-side-text'>" + db.Tables[0].Rows[indis][4] + "</p>" +
                        "</div>";
                    js_indisi += 1;
                    indis += 1;
                }
                content.InnerHtml += "</div>";
            }
            content.InnerHtml += "</div><br/>";
        }
    }
}