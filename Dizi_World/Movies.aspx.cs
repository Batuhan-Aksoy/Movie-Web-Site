using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace Dizi_World
{
    public partial class WebForm2 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            movies_content.InnerHtml = null;
            Service_Reference_2.Sql_WebServiceSoapClient client = new Service_Reference_2.Sql_WebServiceSoapClient();
            DataSet db = new DataSet();
            db = client.diziler();
            double dizi_sayi = db.Tables[0].Rows.Count;
            int js_indis = 0;
            movies_content.InnerHtml += "<br/><h2>Diziler </h2><br/> ";
            dizi_sayi = Math.Ceiling(dizi_sayi / 4);
            int sinir = db.Tables[0].Rows.Count;
            for (int i = 0; i<dizi_sayi;i++)
            {
                movies_content.InnerHtml += "<div class='movies-row-box'>";
             for(int j=0;j<4;j++)
                {
                   if (js_indis == sinir)
                        break; 
                  movies_content.InnerHtml += 
                   "<div class='movies-box' onmousemove='movies_open("+i+","+js_indis+"); movies_content_display("+js_indis+");' onmouseout='movies_close("+i+", "+js_indis+"); movies_content_display_none("+js_indis+"); '>"+
                   "<img src = 'images/"+db.Tables[0].Rows[js_indis][3]+"' alt ='"+ db.Tables[0].Rows[js_indis][1] + "' title = '"+ db.Tables[0].Rows[js_indis][1] + "' />"+
                   "<a href ='Details.aspx?dizi_id=" + db.Tables[0].Rows[js_indis][0] + "&sezon_id=1''><i class='fa fa-play-circle movies-icon' aria-hidden='true'></i></a>" +
                   "<span class='movies-name'>"+ db.Tables[0].Rows[js_indis][1] + "</span>"+
                   "<span class='movies-about'><a href ='Details.aspx?dizi_id="+db.Tables[0].Rows[js_indis][0]+"&sezon_id=1'>Detayı Gör</a></span>   "+
                   "</div>";
                   js_indis += 1;
                }
                movies_content.InnerHtml += "</div> <br> <br>";
            }
            

        }
        
    }
}