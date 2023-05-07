using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace Dizi_World
{
    public partial class User_List : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            user_list_content.InnerHtml = null;
            string kul_ids = Request.QueryString["kul_id"];
            int kul_id = Int32.Parse(kul_ids);
            Service_Reference_2.Sql_WebServiceSoapClient client = new Service_Reference_2.Sql_WebServiceSoapClient();
            DataSet db3 = new DataSet();
            db3 = client.user_list(kul_id);
            double dizi_sayisi = db3.Tables[0].Rows.Count;
            int sinir = db3.Tables[0].Rows.Count;
            if (dizi_sayisi > 0)
            {
                if (dizi_sayisi > 4)
                {
                    dizi_sayisi = Math.Ceiling(dizi_sayisi / 4);
                }
                else
                {
                    dizi_sayisi = 1;
                }
                int js_indis = 0;
                user_list_content.InnerHtml += "<br><br><h2 style='margin:0; padding:0;'>Listeye Eklenen Dizilerim</h2> <br>";
                for (int i = 0; i < dizi_sayisi; i++)
                {
                    user_list_content.InnerHtml += "<div class='season-box'>";
                    for (int j = 0; j < 4; j++)
                    {

                        user_list_content.InnerHtml +=
                            "<div class='season-box-item' onmousemove='details_icon_display(" + js_indis + ");' onmouseout='details_icon_display_none(" + js_indis + ");'>" +
                            "<img src ='images/" + db3.Tables[0].Rows[js_indis][3] + "' alt ='" + db3.Tables[0].Rows[js_indis][2] + " Bölüm' title ='" + db3.Tables[0].Rows[js_indis][2] + " Bölüm' width = '100%' height ='90%' />" +
                            "<a href='Details.aspx?dizi_id=" + db3.Tables[0].Rows[js_indis][1] + "&sezon_id=1'><i class='season-box-item-icon fa fa-play-circle' aria-hidden='true'></i></a>" +
                            "<div class='bolum-ad'>" + db3.Tables[0].Rows[js_indis][2] + ". Bölüm</div>" +
                            "</div>";
                        js_indis += 1;
                        if (js_indis == sinir)
                        {
                            break;
                        }

                    }
                    user_list_content.InnerHtml += "</div><br/><br/>";

                }
            }
            else
                user_list_content.InnerHtml += "<p style='color:white;'>Sonuç Yok </p> <br> <br>";
        }
    }
}