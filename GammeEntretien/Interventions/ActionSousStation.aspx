<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/GammeEntretien.Master" CodeBehind="ActionSousStation.aspx.vb" Inherits="GammeEntretien.ActionSousStation" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Titre" runat="server">
    Programmer les propriétés d'une Action pour une Sous-Station
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
     <div class="row text-danger">
    <div class="col-xs-1">Message Label</div>
    <div class="col-xs-11">
        <asp:Label ID="LbMessage" runat="server" Text=""></asp:Label>
    </div>
</div>


<div class="row text-danger">
    <div class="col-xs-6"></div>
    <div class="col-xs-2">(SousStationId ; ActionId)</div>
    <div class="col-xs-4">
        <asp:Label ID="LbId" runat="server" Text=""></asp:Label>
    </div>
</div>



<div class="row">
    <div class="col-xs-2"></div>
    <div class="col-xs-6"></div>
    <div class="col-xs-4">
         <asp:Button ID="BtRetour" runat="server" Text="Revenir à la liste" CssClass="btn-default" />
    </div>
</div>

    <br/>


 <div class="row">
    <div class="col-xs-2">Fréquence</div>
    <div class="col-xs-4"><asp:TextBox ID="TbFrequence" runat="server" CssClass="form-control" MaxLength ="10"></asp:TextBox></div>
     <div class="col-xs-6"></div>
</div>

    <br/>

 <div class="row">
    <div class="col-xs-2">DPTO</div>
    <div class="col-xs-4"><asp:TextBox ID="TbDPTO" runat="server" CssClass="form-control" MaxLength ="50"></asp:TextBox></div>
     <div class="col-xs-6"></div>
</div>

    <br/>

 <div class="row">
    <div class="col-xs-2">DPTA</div>
    <div class="col-xs-4"><asp:TextBox ID="TbDPTA" runat="server" CssClass="form-control" MaxLength ="50"></asp:TextBox></div>
     <div class="col-xs-6"></div>
</div>

    <br/>

 <div class="row">
    <div class="col-xs-2">Dernière Date de Réalisation</div>
    <div class="col-xs-4"><asp:TextBox ID="TbDerniereDateDeRealisation" runat="server" CssClass="form-control" MaxLength ="50"></asp:TextBox></div>
     <div class="col-xs-6"></div>
</div>

    <br/>

 <div class="row">
    <div class="col-xs-2">Date de Création</div>
    <div class="col-xs-4"><asp:TextBox ID="TbDateDeCreation" runat="server" CssClass="form-control" MaxLength ="50"></asp:TextBox></div>
     <div class="col-xs-6"></div>
</div>

    <br/>

<div class="row">
    <div class="col-xs-1"></div>
     <div class="col-xs-4">
         <asp:Button ID="BtEnregistrer" runat="server" Text="Enregister les propriétés de l'action " CssClass="btn-default" />
     </div>
     <div class="col-xs-1"></div>
    <div class="col-xs-4"></div>
    <div class="col-xs-2"></div>
</div>

</asp:Content>
