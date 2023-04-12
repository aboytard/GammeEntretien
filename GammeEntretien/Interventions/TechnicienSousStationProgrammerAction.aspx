<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/GammeEntretien.Master" CodeBehind="TechnicienSousStationProgrammerAction.aspx.vb" Inherits="GammeEntretien.TechnicienSousStationProgrammerAction" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Titre" runat="server">
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
    <div class="col-xs-2">(TechnicienId ;SousStationId ;ActionId)</div>
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

    <asp:GridView ID="GwActionPrevisionnelleSousStation" runat="server"></asp:GridView>

    <br/>

 <div class="row">
    <div class="col-xs-2">Date de Réalisation </div>
    <div class="col-xs-4"><asp:TextBox ID="TbDateRealisation" runat="server" CssClass="form-control" MaxLength ="10"></asp:TextBox></div>
     <div class="col-xs-6"></div>
</div>

    <br/>

 <div class="row">
    <div class="col-xs-2">Commentaire</div>
    <div class="col-xs-4"><asp:TextBox ID="TbCommentaire" runat="server" CssClass="form-control" MaxLength ="50"></asp:TextBox></div>
     <div class="col-xs-6"></div>
</div>

    <br/>

 <div class="row">
    <div class="col-xs-2">Date Prévisionnelle</div>
    <div class="col-xs-4"><asp:TextBox ID="TbDPTA" runat="server" CssClass="form-control" MaxLength ="50"></asp:TextBox></div>
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
