<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/GammeEntretien.Master" CodeBehind="Techniciens.aspx.vb" Inherits="GammeEntretien.Techniciens" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Titre" runat="server">
    Gestion des Techniciens
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">

<div class="row danger">
    <div class="col-xs-11">
        <asp:Label ID="Lberreur" runat="server" style="color: #FF3300"></asp:Label>
    </div>
    <div class="col-xs-1">
        
    </div>
</div>

<div class="row">
    <div class="col-xs-1">Supervisé par </div>
    <div class="col-xs-5">
         <asp:DropDownList ID="DdlRex" runat="server" AutoPostBack="True"></asp:DropDownList>
    </div>
    <div class="col-xs-6">
        
    </div>            
</div>

    <asp:Button ID="BtCreer" runat="server" Text="Créer un nouvelle enregistrement" OnClick="CreerTechnicien" /> 

 
<div class="row">
    <div class="col-xs-12">
        <asp:GridView ID="GwTechnicien" runat="server">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                      <asp:LinkButton ID="LinkZoom" runat="server" CommandArgument ='<%# Eval("Id") %>' Text="Gérer" OnClick="ZoomTechnicien" > </asp:LinkButton> 
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>



</asp:Content>
