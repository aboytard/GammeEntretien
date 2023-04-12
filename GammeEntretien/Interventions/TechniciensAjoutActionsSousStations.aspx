<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/GammeEntretien.Master" CodeBehind="TechniciensAjoutActionsSousStations.aspx.vb" Inherits="GammeEntretien.TechniciensAjoutActionsSousStations" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Titre" runat="server">
    Ajouter Une Action pour un Technicien sur une Sous-Station donnée
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
    <div class="col-xs-2">Id (SousStationId ; TechnicienId)</div>
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
    <div class="col-xs-1">Gamme </div>
    <div class="col-xs-5">
         <asp:DropDownList ID="DdlGamme" runat="server" AutoPostBack="True"></asp:DropDownList>
    </div>
    <div class="col-xs-6"></div>
</div>  

<div class="row">
    <div class="col-xs-1">Secteur </div>
    <div class="col-xs-5">
         <asp:DropDownList ID="DdlSecteur" runat="server" AutoPostBack="True"></asp:DropDownList>
    </div>
    <div class="col-xs-6"></div>
</div>  

<div class="row">
    <div class="col-xs-1">Action </div>
    <div class="col-xs-5">
         <asp:DropDownList ID="DdlAction" runat="server" AutoPostBack="True"></asp:DropDownList>
    </div>
    <div class="col-xs-6"></div>
</div>  

    <asp:gridview id="GwProgrammer" runat="server">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkZoom" runat="server" CommandArgument ='<%# Eval("Id") %>' Text="Gérer" OnClick="ZoomProgrammerAction" > </asp:LinkButton> 
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
    </asp:gridview>

</asp:Content>
