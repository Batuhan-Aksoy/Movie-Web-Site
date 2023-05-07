using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
namespace Dizi_World
{
    public partial class User : System.Web.UI.Page
    {
        public static int deger = 0;
        protected void Page_Load(object sender, EventArgs e)
        {
            
        }

        protected void kul_info_button_Click(object sender, EventArgs e)
        {
            deger=1;
            Service_Reference_2.Sql_WebServiceSoapClient client = new Service_Reference_2.Sql_WebServiceSoapClient();
            int sonuc=0;
            
            if (TextBox_Sifre.Text=="")
            {
                string ad = TextBox_Ad.Text;
                string soyad = TextBox_Soyad.Text;
                string kulad = TextBox_Kulad.Text;
                string email = TextBox_Email.Text;
                string tel = TextBox_Tel.Text;
                sonuc = client.user_info_update(Int32.Parse(Session["kullanici_id"].ToString()), ad,soyad,kulad,email,tel);
                if (sonuc == 1)
                {
                    Response.Write("<script>alert('Bilgiler Güncellendi.')</script>");
                }
                else
                    Response.Write("<script>alert('Bilgiler Güncellenemedi Tekrar Deneyiniz')</script>");
            }
            else
            {   string ad = TextBox_Ad.Text;
                string soyad = TextBox_Soyad.Text;
                string kulad = TextBox_Kulad.Text;
                string sifre = TextBox_Sifre.Text;
                string email = TextBox_Email.Text;
                string tel = TextBox_Tel.Text;
                sonuc = client.user_info_p_update(Int32.Parse(Session["kullanici_id"].ToString()),ad,soyad,kulad,sifre,email,tel);
                if (sonuc == 1)
                {
                    Response.Write("<script>alert('Bilgiler Güncellendi.')</script>");
                }
                else
                    Response.Write("<script>alert('Bilgiler Güncellenemedi Tekrar Deneyiniz')</script>");              
                }
            
            
                
        }
    }
}