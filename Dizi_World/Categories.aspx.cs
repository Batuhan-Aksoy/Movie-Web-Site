using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace Dizi_World
{
    public partial class WebForm3 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            movies_content.InnerHtml = null;
            string kat_id = Request.QueryString["kat_id"];
            int kategori_id = Int32.Parse(kat_id);
            Service_Reference_2.Sql_WebServiceSoapClient client = new Service_Reference_2.Sql_WebServiceSoapClient();
            DataSet db = new DataSet();
            db = client.kategori_diziler(kategori_id);
            double dizi_sayisi = db.Tables[0].Rows.Count;
            if(dizi_sayisi>0)
            { 
                movies_content.InnerHtml += "<br/><h2>" + db.Tables[0].Rows[0][4] + "</h2><br/>";
                int dizi_s = 0;
                int sinir= db.Tables[0].Rows.Count; 
                if (dizi_sayisi > 4)
                    dizi_sayisi = Math.Ceiling(dizi_sayisi / 4);
                else
                {
                    dizi_sayisi = 1;
                }     
            
                for(int i = 0;i<dizi_sayisi;i++)//4lü kutucuk ayarla
                {
                    movies_content.InnerHtml += "<div class='movies-row-box'> ";
                    for(int j = 0; j <4; j++)//sınır ayarla
                    {
                        movies_content.InnerHtml +=
                            "<div class='movies-box' onmousemove='movies_open("+i+"," + dizi_s + "); movies_content_display(" + dizi_s+ ");' onmouseout='movies_close("+i+ "," + dizi_s + "); movies_content_display_none(" + dizi_s + ");'>" +
                            "<img src ='images/"+db.Tables[0].Rows[dizi_s][3]+ "' alt = '" + db.Tables[0].Rows[dizi_s][1] + "' title = '" + db.Tables[0].Rows[dizi_s][1] + "' />" +
                            "<a href ='Details.aspx?dizi_id=" + db.Tables[0].Rows[dizi_s][0] + "&sezon_id=1'><i class='fa fa-play-circle movies-icon' aria-hidden='true'></i></a>" +
                            "<span class='movies-name'>" + db.Tables[0].Rows[dizi_s][1] + "</span>" +
                            "<span class='movies-about'><a href ='Details.aspx?dizi_id=" + db.Tables[0].Rows[dizi_s][0]+"&sezon_id=1'>Detayı Gör</a></span>" +
                            "</div>";
                        dizi_s += 1;
                        if (dizi_s == sinir)
                            break;
                    }
                    movies_content.InnerHtml += "</div><br /> <br />";
                }
            }
            else
                movies_content.InnerHtml += "Sonuç Yok";
        }
    }
}