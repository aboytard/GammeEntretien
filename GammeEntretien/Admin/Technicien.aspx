<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/GammeEntretien.Master" CodeBehind="Technicien.aspx.vb" Inherits="GammeEntretien.Technicien" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Titre" runat="server">
    Formulaire Technicien
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
    <div class="col-xs-12">Informations sur le Technicien</div>
</div>
 <div class="row">
    <div class="col-xs-2">NOM Prénom</div>
    <div class="col-xs-8"><asp:TextBox ID="TbTechnicienNom" runat="server" CssClass="form-control" MaxLength ="80"></asp:TextBox></div>
     <div class="col-xs-2"></div>
</div>

<div class="row">
    <div class="col-xs-2">Description</div>
    <div class="col-xs-8"><asp:TextBox ID="TbTechnicienDescription" runat="server" CssClass="form-control" MaxLength ="80"></asp:TextBox></div>
    <div class="col-xs-2"></div>
</div>


<div class="row">
      <div class="col-xs-12">Informations sur le Rex de Référence</div>
</div>

<div class="row">
    <div class="col-xs-2">Ref Rex</div>
    <div class="col-xs-8"><asp:TextBox ID="TbRexId" runat="server" CssClass="form-control" ></asp:TextBox></div>
    <div class="col-xs-2"></div>
</div>

<div class="row">
    <div class="col-xs-2">Nom Rex</div>
    <div class="col-xs-8"><asp:TextBox ID="TbRexNom" runat="server" CssClass="form-control" ></asp:TextBox></div>
    <div class="col-xs-2"></div>
</div>

 <div class="row">
    <div class="col-xs-2">Ajout Sous-Stations</div>
    <div class="col-xs-4">
    </div>
    <div class="col-xs-2"></div>
    <div class="col-xs-3">
        <asp:LinkButton ID="LkListeSousStationAAtribuer" runat="server">Liste des sous-stations à attribuer</asp:LinkButton>
    </div>
    <div class="col-xs-1"></div>
</div>


 <div class="row">
    <div class="col-xs-2"></div>
    <div class="col-xs-3"><asp:Button ID="BtEnregistrer" runat="server" Text="Enregistrer les modifications" /></div>
    <div class="col-xs-2"></div>
    <div class="col-xs-3"><asp:Button ID="BtSupprimer" runat="server" Text="Supprimer le Technicien" /></div>
    <div class="col-xs-2"></div>
</div>

        
</asp:Content>
