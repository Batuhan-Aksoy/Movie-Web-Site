using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dizi_World
{
    public partial class Listeye_Ekle : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["dizi_id"]!=null && Request.QueryString["kul_id"]!=null)
            {
                string dizi_ids = Request.QueryString["dizi_id"];
                string kul_ids = Request.QueryString["kul_id"];
                int dizi_id = Int32.Parse(dizi_ids);
                int kul_id = Int32.Parse(kul_ids);
                Service_Reference_2.Sql_WebServiceSoapClient client = new Service_Reference_2.Sql_WebServiceSoapClient();
                int sonuc = client.listeye_ekle(kul_id, dizi_id);
                if(sonuc==1)
                {
                    Response.Redirect("User_List.aspx?kul_id="+kul_id+"");
                }
            }
            
            
        }
    }
}