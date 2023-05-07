using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Dizi_World
{
     
    public partial class Anasayfa : System.Web.UI.MasterPage
    {
        public static int giris=0;
        public static int cikis = 0;
        private void Page_Load(object sender, EventArgs e)
        {
            TextBox_dizi_ara.Visible = false;
            TextBox_Ad_record.Visible = false;
            TextBox_Soyad_record.Visible = false;
            TextBox_Kulad_record.Visible = false;
            TextBox_Sifre_record.Visible = false;
            TextBox_Email_record.Visible = false;
            TextBox_Tel_record.Visible = false;
            TextBox_Kulad.Visible = false;
            TextBox_Sifre.Visible = false;
            login_box_id.Style.Add("display", "none");
            record_box_id.Style.Add("display", "none");
            search.Style.Add("display", "none");
            
            if(Request.QueryString["cikis"]!=null)
            {
                cikis = 1;              
                if(cikis==1)
                    Response.Redirect("İndex.aspx?deger=1");
            }
            
            if (giris==1 && cikis==0)
            {
                giris_yap.Visible = false;
                kayit_ol.Visible = false;
                sag_menu_kul_ad.InnerHtml = "<li onmousemove='kul_menu_box_open();' onmouseout='kul_menu_box_close();'>" + Session["kullanici_kulad"] +
                    "<div class='kul-menu-box'><ul>" +
                    "<a href='User_List.aspx?kul_id="+Session["kullanici_id"]+"'><li>Listelerim</li></a><br>" +
                    "<a href='User.aspx'><li>Hesap Bilgilerim</li></a>" +
                    "<a href='Cikis.aspx?cikis=1'><li>Çıkış Yap</li></a>"+
                    "</ul></div>"+
                    "</li>";
                cikis = 0;
                
            }



            Service_Reference_2.Sql_WebServiceSoapClient client = new Service_Reference_2.Sql_WebServiceSoapClient();
            DataSet db = new DataSet();
            db = client.kategoriler();
            kat_menu.InnerHtml = "<ul>";
            int sayi = db.Tables[0].Rows.Count;
            for(int i=0; i<sayi;i++)
            {
                kat_menu.InnerHtml += "<a href='Categories.aspx?kat_id=" + db.Tables[0].Rows[i][0] + "'><li>" + db.Tables[0].Rows[i][1] + "</li></a>";
            }
            kat_menu.InnerHtml += "</ul>";
        }
        protected void kategori_Click( object sender,EventArgs e)
        {
            Response.Write("<script>alert('kategoriye tıklandı')</script>");
        }
        protected void Button_Giris_Click(object sender, EventArgs e)
        {

            Service_Reference_2.Sql_WebServiceSoapClient client = new Service_Reference_2.Sql_WebServiceSoapClient();
            string kullanici_adi = TextBox_Kulad.Text;
            string sifre = TextBox_Sifre.Text;
            int i = client.login_dogrula(kullanici_adi, sifre);
            if (i == 1)
            {
                DataSet db = new DataSet();
                db = client.giris_bilgileri(kullanici_adi, sifre);
                Session["kullanici_id"] = db.Tables[0].Rows[0][0];
                Session["kullanici_ad"] = db.Tables[0].Rows[0][1];
                Session["kullanici_soyad"] = db.Tables[0].Rows[0][2];
                Session["kullanici_kulad"] = db.Tables[0].Rows[0][3];
                giris = 1;
                Response.Redirect("İndex.aspx?mesaj_deger=1");
            }      
            else if (i == 2)
            {       
                Response.Write("<script>alert('Kullanıcı Girişi Başarısız Lütfen Tekrar Deneyiniz.')</script>");
            }
                
            else
            {
                Response.Write("<script>alert('Böyle Bir Kullanıcı Yok.')</script>");
            }
            
                

                
        }

        protected void Button_Record_Click(object sender,EventArgs e)
        {
            Service_Reference_2.Sql_WebServiceSoapClient client = new Service_Reference_2.Sql_WebServiceSoapClient();
            string ad = TextBox_Ad_record.Text;
            string soyad = TextBox_Soyad_record.Text;
            string kulad = TextBox_Kulad_record.Text;
            string sifre = TextBox_Sifre_record.Text;
            string email = TextBox_Email_record.Text;
            string tel = TextBox_Tel_record.Text;
            int sonuc = client.kullanici_kayit(ad, soyad, kulad, sifre, email, tel);
            if (sonuc == 1)
            {
                Response.Write("<script>alert('Kayıt Tamamlandı')</script>");
            }
            else if (sonuc == 2)
                Response.Write("<script>alert('Kayıt Başarısız')</script>");
            else
                Response.Write("<script>alert('İşlem Başarısız')</script>");
        }
        protected void Search_Button_Click(object sender, EventArgs e)
        {
                
                arama_sonuc_box.Style.Add("display", "block");
                string arama_deger = TextBox_dizi_ara.Text;
                Service_Reference_2.Sql_WebServiceSoapClient client = new Service_Reference_2.Sql_WebServiceSoapClient();
                DataSet db = new DataSet();
                db = client.dizi_arama(arama_deger);
                int sayi = db.Tables[0].Rows.Count;
                arama_sonuc.InnerHtml = "<ul>";
                for (int i=0;i<sayi;i++)
                 {
                     arama_sonuc.InnerHtml += "<a href='Details.aspx?dizi_id="+db.Tables[0].Rows[i][0]+"&sezon_id=1'><li>" + db.Tables[0].Rows[i][1].ToString() + "</li></a>";       
                 }
                if (sayi == 0)
                arama_sonuc.InnerHtml += "<span style='color:white;'>Sonuç yok</span>";
                arama_sonuc.InnerHtml += "</ul>";
        }
        protected void girisyap_textbox_Click(object sender, EventArgs e)
        {
            login_box_id.Style.Add("display", "block");
            login_box_id.Style.Add("position", "fixed");
            record_box_id.Style.Add("display", "none");
            search.Style.Add("display", "none");
            TextBox_dizi_ara.Visible = false;
            TextBox_Ad_record.Visible = false;
            TextBox_Soyad_record.Visible = false;
            TextBox_Kulad_record.Visible = false;
            TextBox_Sifre_record.Visible = false;
            TextBox_Email_record.Visible = false;
            TextBox_Tel_record.Visible = false;

            TextBox_Kulad.Visible = true;
            TextBox_Sifre.Visible = true;
        }
        protected void kayit_textbox_Click(object sender, EventArgs e)
        {
            record_box_id.Style.Add("display", "block");
            record_box_id.Style.Add("position", "fixed");
            login_box_id.Style.Add("display", "none");
            search.Style.Add("display", "none");
            TextBox_dizi_ara.Visible = false;
            TextBox_Kulad.Visible = false;
            TextBox_Sifre.Visible = false;

            TextBox_Ad_record.Visible = true;
            TextBox_Soyad_record.Visible = true;
            TextBox_Kulad_record.Visible = true;
            TextBox_Sifre_record.Visible = true;
            TextBox_Email_record.Visible = true;
            TextBox_Tel_record.Visible = true;
        }
        protected void arama_textbox_Click(object sender, EventArgs e)
        {
            TextBox_dizi_ara.Visible = true;
            search.Style.Add("display", "flex");
            login_box_id.Style.Add("display", "none");
            record_box_id.Style.Add("display", "none");
            TextBox_Kulad.Visible = false;
            TextBox_Sifre.Visible = false;
            TextBox_Ad_record.Visible = false;
            TextBox_Soyad_record.Visible = false;
            TextBox_Kulad_record.Visible = false;
            TextBox_Sifre_record.Visible = false;
            TextBox_Email_record.Visible = false;
            TextBox_Tel_record.Visible = false;
        }
        protected void arama_box_close_Click(object sender, EventArgs e)
        {
            arama_sonuc_box.Style.Add("display", "none");
            arama_sonuc_box.InnerHtml = null;
        }

    }
}