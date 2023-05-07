<%@ Page Title="" Language="C#" MasterPageFile="~/Anasayfa.Master" AutoEventWireup="true" CodeBehind="User.aspx.cs" Inherits="Dizi_World.User" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <div class="user-info-content" runat="server" id="user_info">
        <br /><br />
        <h3>Kullanıcı Bilgileri</h3>
        <hr /><br /><br />
        <label>Adınız : </label>
        <asp:TextBox ID="TextBox_Ad" runat="server" placeholder="Değiştirmek İstediğiniz Yeni Adınızı Girin." required></asp:TextBox> <br /><br />
        <label>Soyadınız : </label>
        <asp:TextBox ID="TextBox_Soyad" runat="server" placeholder="Değiştirmek İstediğiniz Yeni Soyadınızı Girin." required></asp:TextBox><br /><br />
        <label>Kullanıcı Adınız : </label>
        <asp:TextBox ID="TextBox_Kulad" runat="server" placeholder="Değiştirmek İstediğiniz Yeni Kullanıcı Adınızı Girin." required></asp:TextBox><br /><br />
        <label>Yeni Şifreniz : </label>
        <asp:TextBox ID="TextBox_Sifre" TextMode="Password" placeholder="Değiştirmek İstediğiniz Yeni Şifrenizi Girin. İsteğe Bağlıdır" runat="server"></asp:TextBox><br /><br />
        <label>E-mail Adresiniz : </label>
        <asp:TextBox ID="TextBox_Email" TextMode="Email" placeholder="Değiştirmek İstediğiniz Yeni Mail Adresinizi Girin." runat="server" required></asp:TextBox><br /><br />
        <label>Telefon Numaranız:</label>
        <asp:TextBox ID="TextBox_Tel" runat="server" placeholder="Değiştirmek İstediğiniz Yeni Telefon Numaranızı Girin." required></asp:TextBox><br /><br /> 
        <asp:Button ID="kul_info_button" runat="server" Text="Bilgileri Güncelle" d style="margin-left:0.2%; height:40px;" OnClick="kul_info_button_Click"/><br /><br />
        <input id="Reset1" type="reset" value="Temizle" style="margin-left:0.2%; height:40px;" />
        <br />
        <br /><br />
    </div>

</asp:Content>
