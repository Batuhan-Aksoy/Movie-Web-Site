using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Windows.Forms;
namespace Dizi_World
{
    /// <summary>
    /// Sql_WebService için özet açıklama
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // Bu Web Hizmeti'nin, ASP.NET AJAX kullanılarak komut dosyasından çağrılmasına, aşağıdaki satırı açıklamadan kaldırmasına olanak vermek için.
    // [System.Web.Script.Services.ScriptService]
    public class Sql_WebService : System.Web.Services.WebService
    {

        [WebMethod]
        public int login_dogrula(string kulad, string sifre)
        {
            string sql_command = ConfigurationManager.ConnectionStrings["Database_Connect_String"].ConnectionString;
            SqlConnection sql_conn = new SqlConnection(sql_command);
            sql_conn.Open();
            SqlCommand sql_cmd = new SqlCommand("SELECT * FROM Kullanicilar", sql_conn);
            SqlDataReader reader = sql_cmd.ExecuteReader();
            if (reader.HasRows)
            {
                while (reader.Read())
                {
                    if (reader["kullanici_kullaniciad"].Equals(kulad) == true && reader["kullanici_sifre"].Equals(sifre)==true)
                    {
                        return 1;          
                    }
                    else
                    {
                        return 2;  
                    }
                        
                }
            }
            else
            {
                return 0;
            }
            reader.Close();
            sql_conn.Close();
            return 0;
        }
        [WebMethod]
        public DataSet giris_bilgileri(string kulad,string sifre)
        {
            int sonuc = login_dogrula(kulad, sifre);
            if (sonuc == 1)
            {
                DataSet kullanıcı_verileri = new DataSet();
                SqlDataAdapter da = new SqlDataAdapter();
                string sql_command = ConfigurationManager.ConnectionStrings["Database_Connect_String"].ConnectionString;
                SqlConnection sql_conn = new SqlConnection(sql_command);
                sql_conn.Open();
                SqlCommand sql_cmd = new SqlCommand("SELECT kullanici_id,kullanici_ad,kullanici_soyad,kullanici_kullaniciad FROM Kullanicilar WHERE kullanici_kullaniciad='"+kulad+"'", sql_conn);
                da.SelectCommand = sql_cmd;
                da.Fill(kullanıcı_verileri);
                sql_conn.Close();
                return kullanıcı_verileri;
            }
            else
            {
                return null;
            }
                
        }

            [WebMethod]
        public int kullanici_kayit(string ad, string soyad,string kulad,string sifre, string email, string tel)
        {
            string sql_command = ConfigurationManager.ConnectionStrings["Database_Connect_String"].ConnectionString;
            SqlConnection sql_conn = new SqlConnection(sql_command);
            sql_conn.Open();
            SqlCommand sql_cmd = new SqlCommand("INSERT INTO Kullanicilar (kullanici_ad,kullanici_soyad," +
                "kullanici_kullaniciad,kullanici_sifre,kullanici_email,kullanici_tel) VALUES " +
                "(@ad,@soyad,@kulad,@sifre,@email,@tel)", sql_conn);
            sql_cmd.Parameters.AddWithValue("@ad", ad);
            sql_cmd.Parameters.AddWithValue("@soyad", soyad);
            sql_cmd.Parameters.AddWithValue("@kulad", kulad);
            sql_cmd.Parameters.AddWithValue("@sifre", sifre);
            sql_cmd.Parameters.AddWithValue("@email", email);
            sql_cmd.Parameters.AddWithValue("@tel", tel);
            int sonuc = sql_cmd.ExecuteNonQuery();
            if (sonuc > 0)
            {
                sql_conn.Close();
                return 1;
            }
            else
            {
                sql_conn.Close();
                return 2;
            }
                

            
        }
        [WebMethod]
        public DataSet dizi_arama(string deger)
        {
            
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet dizi_verileri = new DataSet();

            string sql_command = ConfigurationManager.ConnectionStrings["Database_Connect_String"].ConnectionString;
            SqlConnection sql_conn = new SqlConnection(sql_command);
            sql_conn.Open();
            SqlCommand sql_cm = new SqlCommand("SELECT dizi_id,dizi_ad FROM Diziler WHERE dizi_ad LIKE '%"+deger+"%'", sql_conn);
            da.SelectCommand = sql_cm;
            da.Fill(dizi_verileri);
            sql_conn.Close();
            return dizi_verileri;
        }
        [WebMethod]
        public DataSet kategoriler()
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet kategori_adlari = new DataSet();
            string sql_command = ConfigurationManager.ConnectionStrings["Database_Connect_String"].ConnectionString;
            SqlConnection sql_conn = new SqlConnection(sql_command);
            sql_conn.Open();
            SqlCommand sql_cm = new SqlCommand("SELECT kategori_id,kategori_ad FROM Kategoriler", sql_conn);
            da.SelectCommand = sql_cm;
            da.Fill(kategori_adlari);
            sql_conn.Close();
            return kategori_adlari;
        }
        [WebMethod]
        public DataSet diziler()
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet dizi_verileri = new DataSet();
            string sql_command = ConfigurationManager.ConnectionStrings["Database_Connect_String"].ConnectionString;
            SqlConnection sql_conn = new SqlConnection(sql_command);
            sql_conn.Open();
            SqlCommand sql_cm = new SqlCommand("SELECT d.dizi_id,d.dizi_ad,d.dizi_aciklama,d.dizi_foto,k.kategori_ad,g.genelkategori_ad FROM Diziler as d" +
                " INNER JOIN Kategoriler as k on d.kategori_id = k.kategori_id" +
                " INNER JOIN Genel_Kategoriler as g on d.genelkategori_id=g.genelkategori_id", sql_conn);
            da.SelectCommand = sql_cm;
            da.Fill(dizi_verileri);
            sql_conn.Close();
            return dizi_verileri;
        }

        [WebMethod]
        public DataSet diziler_genelkategori(int genelkatid)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet dizi_genelkat_verileri = new DataSet();
            string sql_command = ConfigurationManager.ConnectionStrings["Database_Connect_String"].ConnectionString;
            SqlConnection sql_conn = new SqlConnection(sql_command);
            sql_conn.Open();
            SqlCommand sql_cm = new SqlCommand("SELECT d.dizi_id,d.dizi_ad,d.dizi_aciklama,d.dizi_foto,k.kategori_ad,g.genelkategori_ad FROM Diziler as d" +
                " INNER JOIN Kategoriler as k on d.kategori_id = k.kategori_id" +
                " INNER JOIN Genel_Kategoriler as g on d.genelkategori_id=g.genelkategori_id WHERE " +
                "d.genelkategori_id="+genelkatid+"", sql_conn);
            da.SelectCommand = sql_cm;
            da.Fill(dizi_genelkat_verileri);
            sql_conn.Close();
            return dizi_genelkat_verileri;
        }

        [WebMethod]
        public DataSet diziler_id(int dizi_id)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet dizi_verileri = new DataSet();
            string sql_command = ConfigurationManager.ConnectionStrings["Database_Connect_String"].ConnectionString;
            SqlConnection sql_conn = new SqlConnection(sql_command);
            sql_conn.Open();
            SqlCommand sql_cm = new SqlCommand("SELECT * FROM Diziler" +
                " WHERE dizi_id="+dizi_id+"", sql_conn);
            da.SelectCommand = sql_cm;
            da.Fill(dizi_verileri);
            sql_conn.Close();
            return dizi_verileri;
        }
        [WebMethod]
        public DataSet kategori_diziler(int kategori_id)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet kat_dizi_verileri = new DataSet();
            string sql_command = ConfigurationManager.ConnectionStrings["Database_Connect_String"].ConnectionString;
            SqlConnection sql_conn = new SqlConnection(sql_command);
            sql_conn.Open();
            SqlCommand sql_cm = new SqlCommand("SELECT d.dizi_id,d.dizi_ad,d.dizi_aciklama,d.dizi_foto,k.kategori_ad FROM Diziler as d" +
                " INNER JOIN Kategoriler as k on d.kategori_id = k.kategori_id WHERE k.kategori_id =" + kategori_id+"", sql_conn);
            da.SelectCommand = sql_cm;
            da.Fill(kat_dizi_verileri);
            sql_conn.Close();
            return kat_dizi_verileri;
        }
        [WebMethod]
        public DataSet slider()
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet slider_verileri = new DataSet();
            string sql_command = ConfigurationManager.ConnectionStrings["Database_Connect_String"].ConnectionString;
            SqlConnection sql_conn = new SqlConnection(sql_command);
            sql_conn.Open();
            SqlCommand sql_cm = new SqlCommand("SELECT * FROM Slider", sql_conn);
            da.SelectCommand = sql_cm;
            da.Fill(slider_verileri);
            sql_conn.Close();
            return slider_verileri;
        }
        [WebMethod]
        public DataSet genel_kategoriler()
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet genel_kategori_verileri = new DataSet();
            string sql_command = ConfigurationManager.ConnectionStrings["Database_Connect_String"].ConnectionString;
            SqlConnection sql_conn = new SqlConnection(sql_command);
            sql_conn.Open();
            SqlCommand sql_cm = new SqlCommand("SELECT * FROM Genel_Kategoriler", sql_conn);
            da.SelectCommand = sql_cm;
            da.Fill(genel_kategori_verileri);
            sql_conn.Close();
            return genel_kategori_verileri;
        }
        [WebMethod]
        public DataSet sezonlar(int dizi_id)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet dizi_sezon_verileri = new DataSet();
            string sql_command = ConfigurationManager.ConnectionStrings["Database_Connect_String"].ConnectionString;
            SqlConnection sql_conn = new SqlConnection(sql_command);
            sql_conn.Open();
            SqlCommand sql_cm = new SqlCommand("SELECT * FROM Dizi_Sezonlar WHERE dizi_id="+dizi_id+"", sql_conn);
            da.SelectCommand = sql_cm;
            da.Fill(dizi_sezon_verileri);
            sql_conn.Close();
            return dizi_sezon_verileri;
        }
        [WebMethod]
        public DataSet bolumler(int dizi_id,int sezon_id)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet dizi_sezon_bolum_verileri = new DataSet();
            string sql_command = ConfigurationManager.ConnectionStrings["Database_Connect_String"].ConnectionString;
            SqlConnection sql_conn = new SqlConnection(sql_command);
            sql_conn.Open();
            SqlCommand sql_cm = new SqlCommand("SELECT db.bolum_id,db.bolum_no,db.bolum_foto,ds.sezon_no FROM Dizi_Bolumler as db " +
                "INNER JOIN Dizi_Sezonlar as ds on db.sezon_id=ds.sezon_id WHERE db.dizi_id=" + dizi_id + " AND db.sezon_id="+sezon_id+"", sql_conn);
            da.SelectCommand = sql_cm;
            da.Fill(dizi_sezon_bolum_verileri);
            sql_conn.Close();
            return dizi_sezon_bolum_verileri;
        }
        [WebMethod]
        public DataSet bolumler_izle(int dizi_id, int sezon_id,int bolum_id)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet bolum_verileri = new DataSet();
            string sql_command = ConfigurationManager.ConnectionStrings["Database_Connect_String"].ConnectionString;
            SqlConnection sql_conn = new SqlConnection(sql_command);
            sql_conn.Open();
            SqlCommand sql_cm = new SqlCommand("SELECT db.bolum_id,db.bolum_no,db.bolum_foto,db.bolum_video,d.dizi_ad,ds.sezon_no FROM Dizi_Bolumler as db " +
                "INNER JOIN Dizi_Sezonlar as ds on db.sezon_id=ds.sezon_id INNER JOIN Diziler as d on db.dizi_id=d.dizi_id" +
                " WHERE db.dizi_id=" + dizi_id + " AND db.sezon_id=" + sezon_id + " AND db.bolum_id="+bolum_id+"", sql_conn);
            da.SelectCommand = sql_cm;
            da.Fill(bolum_verileri);
            sql_conn.Close();
            return bolum_verileri;
        }
        [WebMethod]
        public DataSet watch_bolum_id_getir(int dizi_id, int sezon_id)
        {

            SqlDataAdapter da = new SqlDataAdapter();
            DataSet watch_bolum_id_verileri = new DataSet();
            string sql_command = ConfigurationManager.ConnectionStrings["Database_Connect_String"].ConnectionString;
            SqlConnection sql_conn = new SqlConnection(sql_command);
            sql_conn.Open();
            SqlCommand sql_cm = new SqlCommand("SELECT bolum_id FROM Dizi_Bolumler WHERE dizi_id=" + dizi_id + " AND sezon_id=" + sezon_id + "", sql_conn);
            da.SelectCommand = sql_cm;
            da.Fill(watch_bolum_id_verileri);
            sql_conn.Close();
            return watch_bolum_id_verileri;


        }
        [WebMethod]
        public DataSet user_list(int kul_id)
        {
             SqlDataAdapter da = new SqlDataAdapter();
             DataSet list_verileri = new DataSet();
             string sql_command = ConfigurationManager.ConnectionStrings["Database_Connect_String"].ConnectionString;
             SqlConnection sql_conn = new SqlConnection(sql_command);
             sql_conn.Open();
             SqlCommand sql_cm = new SqlCommand("SELECT dl.liste_id,dl.dizi_id,d.dizi_ad,d.dizi_foto FROM Kullanici_Liste as dl INNER JOIN Diziler as d on dl.dizi_id=d.dizi_id WHERE dl.kullanici_id=" + kul_id +"", sql_conn);
             da.SelectCommand = sql_cm;
             da.Fill(list_verileri);
             sql_conn.Close();
             return list_verileri;
            

        }
        [WebMethod]
        public DataSet user_info_get(int kul_id)
        {
            SqlDataAdapter da = new SqlDataAdapter();
            DataSet user_verileri = new DataSet();
            string sql_command = ConfigurationManager.ConnectionStrings["Database_Connect_String"].ConnectionString;
            SqlConnection sql_conn = new SqlConnection(sql_command);
            sql_conn.Open();
            SqlCommand sql_cm = new SqlCommand("SELECT kullanici_ad,kullanici_soyad,kullanici_kullaniciad,kullanici_email,kullanici_tel FROM Kullanicilar WHERE kullanici_id="+kul_id+"", sql_conn);
            da.SelectCommand = sql_cm;
            da.Fill(user_verileri);
            sql_conn.Close();
            return user_verileri;
        }
        [WebMethod]
        public int user_info_p_update(int kul_id, string ad, string soyad, string kulad, string sifre, string email, string tel)
        {
            string sql_command = ConfigurationManager.ConnectionStrings["Database_Connect_String"].ConnectionString;
            SqlConnection sql_conn = new SqlConnection(sql_command);
            sql_conn.Open();
            SqlCommand sql_cmd = new SqlCommand("UPDATE Kullanicilar SET kullanici_ad=@ad,kullanici_soyad=@soyad," +
                "kullanici_kullaniciad=@kulad,kullanici_sifre=@sifre,kullanici_email=@email,kullanici_tel=@tel WHERE kullanici_id=" + kul_id + "", sql_conn);
            sql_cmd.Parameters.AddWithValue("@ad", ad);
            sql_cmd.Parameters.AddWithValue("@soyad", soyad);
            sql_cmd.Parameters.AddWithValue("@kulad", kulad);
            sql_cmd.Parameters.AddWithValue("@sifre", sifre);
            sql_cmd.Parameters.AddWithValue("@email", email);
            sql_cmd.Parameters.AddWithValue("@tel", tel);
            int sonuc = sql_cmd.ExecuteNonQuery();
            if (sonuc > 0)
            {
                sql_conn.Close();
                return 1;
            }
            else
            {
                sql_conn.Close();
                return 2;
            }
        }
        [WebMethod]
        public int user_info_update(int kul_id, string ad, string soyad, string kulad, string email, string tel)
        {
            string sql_command = ConfigurationManager.ConnectionStrings["Database_Connect_String"].ConnectionString;
            SqlConnection sql_conn = new SqlConnection(sql_command);
            sql_conn.Open();
            SqlCommand sql_cmd = new SqlCommand("UPDATE Kullanicilar SET kullanici_ad=@ad,kullanici_soyad=@soyad," +
                "kullanici_kullaniciad=@kulad,kullanici_email=@email,kullanici_tel=@tel WHERE kullanici_id=" + kul_id + "", sql_conn);
            sql_cmd.Parameters.AddWithValue("@ad", ad);
            sql_cmd.Parameters.AddWithValue("@soyad", soyad);
            sql_cmd.Parameters.AddWithValue("@kulad", kulad);
            sql_cmd.Parameters.AddWithValue("@email", email);
            sql_cmd.Parameters.AddWithValue("@tel", tel);
            int sonuc = sql_cmd.ExecuteNonQuery();
            if (sonuc > 0)
            {
                sql_conn.Close();
                return 1;
            }
            else
            {
                sql_conn.Close();
                return 2;
            }
        }
        [WebMethod]
        public int listeye_ekle(int kul_id,int dizi_id)
        {
            string sql_command = ConfigurationManager.ConnectionStrings["Database_Connect_String"].ConnectionString;
            SqlConnection sql_conn = new SqlConnection(sql_command);
            sql_conn.Open();
            SqlCommand sql_cmd = new SqlCommand("INSERT INTO Kullanici_Liste (kullanici_id,dizi_id)" +
                " VALUES (@kul_id,@dizi_id)", sql_conn);
            sql_cmd.Parameters.AddWithValue("@kul_id", kul_id);
            sql_cmd.Parameters.AddWithValue("@dizi_id", dizi_id);
            int sonuc = sql_cmd.ExecuteNonQuery();
            if (sonuc > 0)
            {
                sql_conn.Close();
                return 1;
            }
            else
            {
                sql_conn.Close();
                return 2;
            }

        }
        [WebMethod]
        public int iletisim_ekle(string ad,string soyad, string email, string tel, string tur,string mesaj,int kul_id)
        {
            string sql_command = ConfigurationManager.ConnectionStrings["Database_Connect_String"].ConnectionString;
            SqlConnection sql_conn = new SqlConnection(sql_command);
            sql_conn.Open();
            SqlCommand sql_cmd = new SqlCommand("INSERT INTO Kullanici_İletisim (iletisim_ad,iletisim_soyad,iletisim_email,iletisim_tel,iletisim_turu,iletisim_mesaj,kul_id)" +
                " VALUES (@ad,@soyad,@email,@tel,@tur,@mesaj,@kul_id)", sql_conn);
            sql_cmd.Parameters.AddWithValue("@ad", ad);
            sql_cmd.Parameters.AddWithValue("@soyad", soyad);
                sql_cmd.Parameters.AddWithValue("@email",email);
            sql_cmd.Parameters.AddWithValue("@tel", tel);
            sql_cmd.Parameters.AddWithValue("@tur", tur);
            sql_cmd.Parameters.AddWithValue("@mesaj", mesaj);
            sql_cmd.Parameters.AddWithValue("@kul_id", kul_id);
            int sonuc = sql_cmd.ExecuteNonQuery();
            if (sonuc > 0)
            {
                sql_conn.Close();
                return 1;
            }
            else
            {
                sql_conn.Close();
                return 2;
            }
        }


    }
}
