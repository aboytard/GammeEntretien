<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/GammeEntretien.Master" CodeBehind="SousStationActionsPrevisionnelles.aspx.vb" Inherits="GammeEntretien.SousStationActionsPrevisionnelles" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Titre" runat="server">
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
    <div class="col-xs-6"><asp:Button ID="BtRetour" runat="server" Text="Revenir au Formulaire de la sous-station" /> </div>
</div>


    <asp:Label ID="LbRecap" runat="server" Text=""></asp:Label>
    <asp:gridview id="GwStlisteActionsPrevisionnelles" runat="server"></asp:gridview>

<asp:Panel ID="PnAjouterActionsPrevisionnelles" runat="server" CssClass="CadreCouleur1">
<br />
    <div class="row">
        <div class="col-xs-2"></div>
        <div class="col-xs-10 h4">Sélectionnez le secteur que vous souhaitez ajouter</div>
    </div>

    <div class="row">
        <div class="col-xs-1"></div>
        <div class="col-xs-3"><asp:DropDownList ID="DdlSecteurs" runat="server" CssClass="form-control"></asp:DropDownList></div>
        <div class="col-xs-8"><asp:Button ID="BtAjoutActionsSousSecteur" runat="server" Text="Ajouter les actions du secteur sélectionné" /> </div>
    </div>
<br />
</asp:Panel> 


</asp:Content>
