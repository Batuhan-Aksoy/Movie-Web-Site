using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace Dizi_World
{
    public partial class Details : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            details_content.InnerHtml = null;
            details_bar.InnerHtml = null;
            season_content.InnerHtml = null;


            string dizi_ids = Request.QueryString["dizi_id"];
            int dizi_id = Int32.Parse(dizi_ids);
            Service_Reference_2.Sql_WebServiceSoapClient client = new Service_Reference_2.Sql_WebServiceSoapClient();
            DataSet db = new DataSet();
            db = client.diziler_id(dizi_id);
            details_content.InnerHtml +=
                "<img src='images/"+db.Tables[0].Rows[0][6]+ "' alt='" + db.Tables[0].Rows[0][1] + "' title='" + db.Tables[0].Rows[0][1] + "' width='100%' height='100%'/>" +
                "<a href='Watch.aspx?dizi_id="+dizi_id+"&sezon_id=1&bolum_id=1'><i class='fa fa-play-circle' aria-hidden='true'></i></a>"+
                "<span>" + db.Tables[0].Rows[0][1] + "</span>" +
                "<p>" + db.Tables[0].Rows[0][2] + "</p>" +
                "<div class='details-add-button'><a href='Listeye_Ekle.aspx?kul_id="+Session["kullanici_id"] +"&dizi_id="+dizi_id+"' style='text-decoration:none; color:black;'> + Listeye Ekle</a></div>";


            //sezon bar
            int sezon_id = 0;
            string sezon;
            sezon = Request.QueryString["sezon_id"];
            sezon_id = Int32.Parse(sezon);
            DataSet db2 = new DataSet();
            db2 = client.sezonlar(dizi_id);
            int sezon_sayisi = db2.Tables[0].Rows.Count;
            details_bar.InnerHtml +=
                "<ul>";
            for (int i = 0; i < sezon_sayisi;i++)
            {
                details_bar.InnerHtml += "<a href='Details.aspx?sezon_id="+(i+1)+"&dizi_id="+dizi_id+"' style='text-decoration:none;'><li class='details-bar-li'>Sezon "+db2.Tables[0].Rows[i][1]+"</li></a>";
            }
            details_bar.InnerHtml += "</ul>";



            //seacon content

            DataSet db3 = new DataSet();
            db3 = client.bolumler(dizi_id,sezon_id);
            double bolum_sayisi = db3.Tables[0].Rows.Count;
            int sinir = db3.Tables[0].Rows.Count;
            if (bolum_sayisi > 0)
            {
                if (bolum_sayisi > 4)
                {
                    bolum_sayisi = Math.Ceiling(bolum_sayisi / 4);
                }
                else
                {
                    bolum_sayisi = 1;
                }
                int js_indis = 0;
                season_content.InnerHtml += "<h2> " + db3.Tables[0].Rows[0][3] + " Sezon </h2>";
                for (int i = 0; i < bolum_sayisi; i++)
                {
                    season_content.InnerHtml += "<div class='season-box'>";
                    for (int j = 0; j < 4; j++)
                    {

                        season_content.InnerHtml +=
                            "<div class='season-box-item' onmousemove='details_icon_display(" + js_indis + ");' onmouseout='details_icon_display_none(" + js_indis + ");'>" +
                            "<img src ='images/" + db3.Tables[0].Rows[js_indis][2] + "' alt ='" + db3.Tables[0].Rows[js_indis][1] + " Bölüm' title ='" + db3.Tables[0].Rows[js_indis][1] + " Bölüm' width = '100%' height ='90%' />" +
                            "<a href='Watch.aspx?dizi_id="+ dizi_id + "&sezon_id="+ sezon_id + "&bolum_id="+ db3.Tables[0].Rows[js_indis][0] + "'><i class='season-box-item-icon fa fa-play-circle' aria-hidden='true'></i></a>" +
                            "<div class='bolum-ad'>" + db3.Tables[0].Rows[js_indis][1] + ". Bölüm</div>" +
                            "</div>";
                        js_indis += 1;
                        if (js_indis == sinir)
                        {
                            break;
                        }

                    }
                    season_content.InnerHtml += "</div><br/>";

                }
            }
            else
                season_content.InnerHtml += "<p style='color:white;'>Sonuç Yok </p> <br> <br>";
        }
    }
}