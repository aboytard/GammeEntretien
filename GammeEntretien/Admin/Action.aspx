<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/GammeEntretien.Master" CodeBehind="Action.aspx.vb" Inherits="GammeEntretien.Action" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Titre" runat="server">
    Formulaire Action
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
    <div class="col-xs-2"></div>
    <div class="col-xs-6"></div>
     <div class="col-xs-4">
         <asp:Button ID="BtRetour" runat="server" Text="Revenir à la liste" CssClass="btn-default" />
     </div>
</div>

 <div class="row">
    <div class="col-xs-12">Informations sur l'action</div>
</div>
 <div class="row">
    <div class="col-xs-2">Libelle</div>
    <div class="col-xs-8"><asp:TextBox ID="TbLibelle" runat="server" CssClass="form-control" MaxLength ="500"></asp:TextBox></div>
     <div class="col-xs-2"></div>
</div>

<div class="row">
    <div class="col-xs-2">Description</div>
    <div class="col-xs-8"><asp:TextBox ID="TbDescription" runat="server" CssClass="form-control" MaxLength ="500"></asp:TextBox></div>
    <div class="col-xs-8"></div>
</div>

<div class="row">
    <div class="col-xs-2">Fréquence</div>
    <div class="col-xs-2"><asp:TextBox ID="TbFrequence" runat="server" CssClass="form-control" MaxLength ="10"></asp:TextBox></div>
    <div class="col-xs-8"></div>
</div>

<div class="row">
    <div class="col-xs-2">Référence Secteur (Id , Libellé)</div>
    <div class="col-xs-2"><asp:TextBox ID="TbSecteurId" runat="server" CssClass="form-control" MaxLength ="10"></asp:TextBox></div>
    <div class="col-xs-6"><asp:TextBox ID="TbSecteurLibelle" runat="server" CssClass="form-control" MaxLength ="50"></asp:TextBox></div>
    <div class="col-xs-2"></div>
</div>

<div class="row">
    <div class="col-xs-2">Gamme (Id, Libellé)</div>
    <div class="col-xs-2"><asp:TextBox ID="TbGammeId" runat="server" CssClass="form-control" MaxLength ="10"></asp:TextBox></div>
    <div class="col-xs-6"><asp:TextBox ID="TbGammeLibelle" runat="server" CssClass="form-control" MaxLength ="50"></asp:TextBox></div>
    <div class="col-xs-2"></div>
</div>

<div class="row">
    <div class="col-xs-2"></div>
    <div class="col-xs-3"><asp:Button ID="BtEnregistrer" runat="server" Text="Enregistrer les modifications" /></div>
    <div class="col-xs-2"></div>
    <div class="col-xs-3"><asp:Button ID="BtSupprimer" runat="server" Text="Supprimer l'Action" /></div>
    <div class="col-xs-2"></div>
</div>

<div class="row">
    <div class="col-xs-8"></div>
    <div class="col-xs-3">
        <asp:LinkButton ID="LkListeActionsAPrevoir" runat="server">Liste des sous-stations attribuées</asp:LinkButton>
    </div>
    <div class="col-xs-1"></div>
</div>

</asp:Content>
