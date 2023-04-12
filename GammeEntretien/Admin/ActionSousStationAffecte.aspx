<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/GammeEntretien.Master" CodeBehind="ActionSousStationAffecte.aspx.vb" Inherits="GammeEntretien.ActionSousStationAffecte" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Titre" runat="server">
    Liste des Sous-Stations affectées à un technicien
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
<div class="row text-danger">
    <div class="col-xs-1"></div>
    <div class="col-xs-11">
        <asp:Label ID="LbMessage" runat="server" Text=""></asp:Label>
    </div>
</div>
<div class="row text-danger">
    <div class="col-xs-8"></div>
    <div class="col-xs-2">Id demandé</div>
    <div class="col-xs-2">
        <asp:Label ID="LbId" runat="server" Text=""></asp:Label>
    </div>
</div>    

<div class="row">
    <div class="col-xs-1"></div>
    <div class="col-xs-5"></div>
    <div class="col-xs-6"><asp:Button ID="BtRetour" runat="server" Text="Revenir au Formulaire de l'action" /> </div>
</div>

    <asp:Label ID="LbRecap" runat="server" Text=""></asp:Label>
    <asp:gridview id="GwStlisteSousStation" runat="server"></asp:gridview>

<asp:Panel ID="PnAjouterUneSousStation" runat="server" CssClass="CadreCouleur1">
<br />
    <div class="row">
        <div class="col-xs-2"></div>
        <div class="col-xs-10 h4">Sélectionnez le site dans laquelle se trouve l'installation</div>
    </div>

    <div class="row">
        <div class="col-xs-1"></div>
        <div class="col-xs-5"><asp:DropDownList ID="DdlVilles" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList></div>
        <div class="col-xs-6"></div>
    </div>

    <div class="row">
        <div class="col-xs-2"></div>
        <div class="col-xs-10 h4">Sélectionnez l'installation à laquelle vous voulez affecter l'action</div>
    </div>

    <div class="row">
        <div class="col-xs-1"></div>
        <div class="col-xs-4"><asp:DropDownList ID="DdlSousStation" runat="server" CssClass="form-control" AutoPostBack="true"></asp:DropDownList></div>
        <div class="col-xs-7"><asp:Button ID="BtAjoutSousStation" runat="server" Text="Ajouter la sous-station sélectionnée" /> </div>
    </div>
<br />
</asp:Panel> 



</asp:Content>
