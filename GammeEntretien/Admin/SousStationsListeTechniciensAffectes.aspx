<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/GammeEntretien.Master" CodeBehind="SousStationsListeTechniciensAffectes.aspx.vb" Inherits="GammeEntretien.SousStationsListeTechniciensAffectes" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Titre" runat="server">
    Listes des Sous stations Attribuées au technicien
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
<div class="row danger">
    <div class="col-xs-11">
        <asp:Label ID="LbMessage" runat="server" style="color: #FF3300"></asp:Label>
    </div>
    <div class="col-xs-1">        
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
    <div class="col-xs-6"><asp:Button ID="BtRetour" runat="server" Text="Revenir au Formulaire de la sous-station" /> </div>
</div>
     
    <asp:Label ID="LbRecap" runat="server" Text=""></asp:Label>

    <asp:gridview id="GwTechniciensAffectes" runat="server"></asp:gridview>

<asp:Panel ID="PnAjouterUneSousStation" runat="server" CssClass="CadreCouleur1">
<br />
    <div class="row">
        <div class="col-xs-2"></div>
        <div class="col-xs-10 h4">Sélectionnez le technicien que vous souhaitez affecter à la sous station</div>
    </div>
    <div class="row">
        <div class="col-xs-1"></div>
        <div class="col-xs-4"><asp:DropDownList ID="DdlTechniciens" runat="server" CssClass="form-control"></asp:DropDownList></div>
        <div class="col-xs-7"><asp:Button ID="BtAjoutSousStation" runat="server" Text="Ajouter le technicien sélectionné" /> </div>
    </div>
<br />
</asp:Panel>    
</asp:Content>
