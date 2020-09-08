<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Aiguilleur._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    
    <asp:Panel ID="Panel2" runat="server" Height="46px">
        <asp:Label ID="Label1" runat="server" Text="Selectionner l'Aéroport"></asp:Label>
        <asp:DropDownList ID="DropDownList1" runat="server">
        </asp:DropDownList>
        <asp:Panel ID="Panel3" runat="server" Height="61px" style="margin-top: 22px">
            <asp:Label runat="server" Text="De"></asp:Label>
            <asp:TextBox ID="TextBox1" runat="server" type ="date"></asp:TextBox>
            <asp:Label ID="Label2" runat="server" Text="À"></asp:Label>
            <asp:TextBox ID="TextBox2" runat="server" type ="date"></asp:TextBox>
            <asp:Button ID="ButtonAeroport" runat="server" OnClick="GenerateListVolsOfAirport" style="margin-bottom: 20" Text="Aller à cet aéroport" />
        </asp:Panel>
    </asp:Panel>

    <asp:Panel ID="Panel1" runat="server" Height="280px" style="margin-top: 76px" Visible="False">
        <asp:GridView ID="ListeVols" runat="server">
        </asp:GridView>
        
        
        

        <asp:Button ID="Button1" runat="server" OnClick="Proposer" Text="Proposer Pistes"  />
        
        
        

        <asp:Button ID="Button2" runat="server" Text="Valider Propositions" Visible="False" />
        
        
        

    </asp:Panel>

    
</asp:Content>
