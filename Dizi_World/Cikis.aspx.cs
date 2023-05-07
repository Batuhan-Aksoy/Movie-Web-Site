using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Dizi_World
{
    public partial class Cikis : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if(Request.QueryString["cikis"]!=null)
            {
                Session.Clear();
                Response.Redirect("İndex.aspx?cikis=1");
            }
        }
    }
}