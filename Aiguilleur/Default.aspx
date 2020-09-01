<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Aiguilleur._Default" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    
    <asp:Label ID="Label1" runat="server" Text="Selectionner l'aeroport"></asp:Label>
    <asp:DropDownList ID="DropDownList1" runat="server">
    </asp:DropDownList>

    
    <asp:Button ID="ButtonAeroport" runat="server" Text="Aller à cet Aéroport" />
    <asp:Panel ID="Panel1" runat="server" Height="371px" style="margin-top: 39px">
        <asp:Table ID="ListeVols" runat="server" Height="319px" Width="592px">
            <asp:TableRow runat="server">
            </asp:TableRow>
        </asp:Table>
    </asp:Panel>

    
</asp:Content>
