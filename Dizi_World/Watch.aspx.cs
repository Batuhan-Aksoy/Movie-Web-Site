using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace Dizi_World
{
    public partial class watch : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            watch_content.InnerHtml += null;
            string bolum_ids = Request.QueryString["bolum_id"];
            string dizi_ids = Request.QueryString["dizi_id"];
            string sezon_ids = Request.QueryString["sezon_id"];
            int dizi_id = Int32.Parse(dizi_ids);
            int sezon_id = Int32.Parse(sezon_ids);
            int bolum_id = Int32.Parse(bolum_ids);
            Service_Reference_2.Sql_WebServiceSoapClient client = new Service_Reference_2.Sql_WebServiceSoapClient();
            DataSet db = new DataSet();
            db = client.bolumler_izle(dizi_id,sezon_id,bolum_id);
            if (db.Tables[0].Rows.Count >0)
            {
                watch_content.InnerHtml +=
                    "<div class='watch-box'>" +
                    "<video width='100%' height='550' controls>" +
                      "<source src='videos/" + db.Tables[0].Rows[0][3] + "' type='video/mp4' title='" + db.Tables[0].Rows[0][4] + " " + db.Tables[0].Rows[0][1] + ". Bölüm' />" +
                      "</video>" +
                      "<div class='watch-detail'>" +
                      "<span>" + db.Tables[0].Rows[0][4] + " | " + db.Tables[0].Rows[0][5] + ". Sezon | " + db.Tables[0].Rows[0][1] + ". Bölümü</span>" +
                      "<div class='watch-add-button'><a href='Listeye_Ekle.aspx?kul_id=" + Session["kullanici_id"] + "&dizi_id=" + dizi_id + "' style='text-decoration:none; color:black;'>+ Listeye Ekle</a></div>" +
                      "</div>" +
                      "</div>";
            }
            else
                watch_content.InnerHtml += "Bölüm Yok";
            DataSet db2 = new DataSet();
            db2 = client.sezonlar(dizi_id);
            int sezon_sayisi = db2.Tables[0].Rows.Count;
            DataSet db4 = new DataSet();
            watch_content.InnerHtml +="<div class='details-bar'>"+
                "<ul>";;
            for (int i = 0; i < sezon_sayisi; i++)
            {  
                    db4 = client.watch_bolum_id_getir(dizi_id,(int)db2.Tables[0].Rows[i][0]);
                    if(db4.Tables[0].Rows.Count>0)
                        watch_content.InnerHtml += "<a href='Watch.aspx?sezon_id=" + db2.Tables[0].Rows[i][0] + "&dizi_id=" + dizi_id +"&bolum_id="+db4.Tables[0].Rows[0][0]+"' style='text-decoration:none;'><li class='details-bar-li'>Sezon " + db2.Tables[0].Rows[i][1] + "</li></a>";         
            }
            watch_content.InnerHtml += "</ul></div>";


            DataSet db3 = new DataSet();
            db3 = client.bolumler(dizi_id, sezon_id);
            double bolum_sayisi = db3.Tables[0].Rows.Count;
            int sinir = db3.Tables[0].Rows.Count;
            if (bolum_sayisi > 0)
            {
                watch_content.InnerHtml += "<div class='season-content'>";
                if (bolum_sayisi > 4)
                {
                    bolum_sayisi = Math.Ceiling(bolum_sayisi / 4);
                }
                else
                {
                    bolum_sayisi = 1;
                }
                int js_indis = 0;
                watch_content.InnerHtml += "<h2> " + db3.Tables[0].Rows[0][3] + " Sezon </h2>";
                for (int i = 0; i < bolum_sayisi; i++)
                {
                    watch_content.InnerHtml += "<div class='season-box'>";
                    for (int j = 0; j < 4; j++)
                    {

                        watch_content.InnerHtml +=
                            "<div class='season-box-item' onmousemove='details_icon_display(" + js_indis + ");' onmouseout='details_icon_display_none(" + js_indis + ");'>" +
                            "<img src ='images/" + db3.Tables[0].Rows[js_indis][2] + "' alt ='" + db3.Tables[0].Rows[js_indis][1] + " Bölüm' title ='" + db3.Tables[0].Rows[js_indis][1] + " Bölüm' width = '100%' height ='90%' />" +
                            "<a href='Watch.aspx?dizi_id=" + dizi_id + "&sezon_id=" + sezon_id + "&bolum_id=" + db3.Tables[0].Rows[js_indis][0] + "'><i class='season-box-item-icon fa fa-play-circle' aria-hidden='true'></i></a>" +
                            "<div class='bolum-ad'>" + db3.Tables[0].Rows[js_indis][1] + ". Bölüm</div>" +
                            "</div>";
                        js_indis += 1;
                        if (js_indis == sinir)
                        {
                            break;
                        }

                    }
                    watch_content.InnerHtml += "</div><br/>";

                }
                watch_content.InnerHtml += "</div>";
            }
            else
                watch_content.InnerHtml += "<p style='color:white;'>Sonuç Yok </p> <br> <br>";
        }
    }
}