<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/GammeEntretien.Master" CodeBehind="SousStation.aspx.vb" Inherits="GammeEntretien.SousStation" %>
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
    <div class="col-xs-2"></div>
    <div class="col-xs-6"></div>
     <div class="col-xs-4">
         <asp:Button ID="BtRetour" runat="server" Text="Revenir à la liste" CssClass="btn-default" />
     </div>
</div>

 <div class="row">
    <div class="col-xs-12">Informations sur la Sous-Station</div>
</div>
 <div class="row">
    <div class="col-xs-2">Code </div>
    <div class="col-xs-8"><asp:TextBox ID="TbCodeSousStation" runat="server" CssClass="form-control" MaxLength ="80"></asp:TextBox></div>
     <div class="col-xs-2"></div>
</div>

<div class="row">
    <div class="col-xs-2">Libellé</div>
    <div class="col-xs-8"><asp:TextBox ID="TbLibelle" runat="server" CssClass="form-control" MaxLength ="80"></asp:TextBox></div>
    <div class="col-xs-2"></div>
</div>

<div class="row">
    <div class="col-xs-2">Ref site</div>
    <div class="col-xs-8"><asp:TextBox ID="TbSiteId" runat="server" CssClass="form-control" ></asp:TextBox></div>
    <div class="col-xs-2"></div>
</div>

    <asp:Panel ID="PnSite" runat="server">
        <br /><br /> 
         <div class="row">
            <div class="col-xs-12">Informations sur le Site de Référence</div>
        </div>

         <div class="row">
            <div class="col-xs-2">Adresse</div>
            <div class="col-xs-8"><asp:TextBox ID="TbAdresse1" runat="server" CssClass="form-control" MaxLength ="80"></asp:TextBox></div>
             <div class="col-xs-2"></div>
        </div>
        <div class="row">
            <div class="col-xs-2">Complément</div>
            <div class="col-xs-8"><asp:TextBox ID="TbAdresse2" runat="server" CssClass="form-control" MaxLength ="80"></asp:TextBox></div>
            <div class="col-xs-2"></div>
        </div>

         <div class="row">
                <div class="col-xs-2">Ville</div>
                <div class="col-xs-2">
                    <asp:TextBox ID="TbCodePostal" runat="server" CssClass="form-control" MaxLength ="5"></asp:TextBox>
                </div>
                <div class="col-xs-5">
                    <asp:TextBox ID="TbVille" runat="server" CssClass="form-control" MaxLength ="80"></asp:TextBox>
                </div>
             <div class="col-xs-3"></div>
         </div>

         <div class="row">
            <div class="col-xs-3">Rex</div>
            <div class="col-xs-9"><asp:DropDownList ID="DdlRex" runat="server"></asp:DropDownList></div>
        </div>

         <div class="row">
            <div class="col-xs-3">Technicien</div>
            <div class="col-xs-9"><asp:DropDownList ID="DdlTechnicien" runat="server"></asp:DropDownList></div>
        </div>

    </asp:Panel>

 <div class="row">
    <div class="col-xs-8"></div>
    <div class="col-xs-3">
        <asp:LinkButton ID="LkListeActionsAPrevoir" runat="server">Liste des actions à prévoir</asp:LinkButton>
    </div>
    <div class="col-xs-1"></div>
</div>
 <div class="row">
    <div class="col-xs-8">Ajout actions</div>
    <div class="col-xs-3">
        <asp:LinkButton ID="LkListeTechniciens" runat="server">Liste des technicien affectés</asp:LinkButton>
    </div>
    <div class="col-xs-1"></div>
</div>
 <div class="row">
    <div class="col-xs-2"></div>
    <div class="col-xs-3"><asp:Button ID="BtEnregistrer" runat="server" Text="Enregistrer les modifications" /></div>
    <div class="col-xs-2"></div>
    <div class="col-xs-3"><asp:Button ID="BtSupprimer" runat="server" Text="Supprimer la sous-station" /></div>
    <div class="col-xs-2"></div>
</div>

        


</asp:Content>
