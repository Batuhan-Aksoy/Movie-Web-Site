<%@ Page Title="" Language="C#" MasterPageFile="~/Anasayfa.Master" AutoEventWireup="true" CodeBehind="İletisim.aspx.cs" Inherits="Dizi_World.WebForm1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="comn-content">
<h2>İletişim</h2>
    <hr />
<div class="comn-box">
    <div>
    <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d2985.870306751654!2d32.290429815391384!3d41.55040527924944!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x409b7ab49a558613%3A0xee38d5f5682368b2!2zQmFydMSxbiDDnG5pdmVyc2l0ZXNpIE3DvGhlbmRpc2xpayBGYWvDvGx0ZXNp!5e0!3m2!1str!2str!4v1650958030700!5m2!1str!2str" width="600" height="450" style="border:0;" allowfullscreen="" loading="lazy" referrerpolicy="no-referrer-when-downgrade"></iframe>
    <br /><br />
    </div>
    <div>
    <h3>Adres Bilgileri</h3>
     <hr />
    <i class="fa fa-map-marker" aria-hidden="true"></i> &nbsp;
    <span>Bartın Üniversitesi Mühendislik Mimarlık Fakültesi, 74110 Kutlubeyyazıcılar/Bartın Merkez/Bartın</span>
    <br />
    
    <i class="fa fa-phone" aria-hidden="true"></i>
    <span>05070061932</span>
    
    <br />
    <i class="fa fa-envelope-o" aria-hidden="true"></i>
    <span><a href="mailto:19010311009@ogrenci.bartin.edu.tr">19010311009@ogrenci.bartin.edu.tr</a></span>
        
        <div class="comn-button" onclick="comn_form();">
            İletişim Formu İçin Tıklayınız.
        </div>
    </div>
</div>
    <div class="comn-form" id="comn-form-id">
        <h3>İletişim Formu</h3>
        <hr />
        <label>Adınız : </label>
        <asp:TextBox ID="TextBox_Ad" runat="server" required></asp:TextBox> <br /><br />
        <label>Soyadınız : </label>
        <asp:TextBox ID="TextBox_Soyad" runat="server" required></asp:TextBox><br /><br />
        <label>E-mail Adres : </label>
        <asp:TextBox ID="TextBox_Email" runat="server" required></asp:TextBox><br /><br />
        <label>İletişim Telefon Numarası :</label>
        <asp:TextBox ID="TextBox_Tel" runat="server" required></asp:TextBox><br /><br />
        <label>İletişim Türü : </label>
        <asp:DropDownList ID="DropDownList1" runat="server" required>
            <asp:ListItem Value="" Selected>Lütfen Seçiniz</asp:ListItem>
            <asp:ListItem Value="">Şikayet</asp:ListItem>
            <asp:ListItem Value="">Yardım</asp:ListItem>
            <asp:ListItem Value="">Öneri</asp:ListItem>
        </asp:DropDownList><br /><br />
        <label>Mesaj : </label><br />
        <asp:TextBox ID="TextBox_Mesaj" runat="server" TextMode="MultiLine" Rows="10" Width="100%" required></asp:TextBox><br /><br />
        <asp:Button ID="button_iletisim" runat="server" OnClick="button_iletisim_Click" Text="Gönder" d style="margin-left:0.2%; height:40px;"/><br /><br />
        <input id="Reset1" type="reset" value="Temizle" style="margin-left:0.2%; height:40px;" />
    </div>
</div>
</asp:Content>
