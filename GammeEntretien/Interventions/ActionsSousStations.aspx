<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/GammeEntretien.Master" CodeBehind="ActionsSousStations.aspx.vb" Inherits="GammeEntretien.ActionsSousStations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Titre" runat="server">
    Prévoir les Actions Pour une Sous-Station donnée
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">

<div class="row text-danger">
    <div class="col-xs-1"></div>
    <div class="col-xs-11">
        <asp:Label ID="LbMessage" runat="server" Text=""></asp:Label>
    </div>
</div>

<div class="row">
    <div class="col-xs-1">Situé à </div>
    <div class="col-xs-5">
         <asp:DropDownList ID="DdlVilles" runat="server" AutoPostBack="True"></asp:DropDownList>
    </div>
    <div class="col-xs-6"></div>

</div>      

<div class="row">
    <div class="col-xs-1">Situé à </div>
    <div class="col-xs-5">
         <asp:DropDownList ID="DdlSousStation" runat="server" AutoPostBack="True"></asp:DropDownList>
    </div>
    <div class="col-xs-6"></div>
</div>      


<div class="row">
    <div class="col-xs-11">
        <asp:GridView ID="GwActionParSousStation" runat="server">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                      <asp:LinkButton ID="LinkZoom" runat="server" CommandArgument ='<%# Eval("Id") %>' Text="Gérer" OnClick="ZoomActionParSousStation" > </asp:LinkButton> 
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</div>
</asp:Content>
