<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/GammeEntretien.Master" CodeBehind="Test.aspx.vb" Inherits="GammeEntretien.Test" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Titre" runat="server">
    Test Page de Garde Programmation
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">
    <div class="row text-danger">
    <div class="col-xs-1"></div>
    <div class="col-xs-11">
        <asp:Label ID="LbMessage" runat="server" Text=""></asp:Label>
    </div>
</div>

 


     <br/>

<div class="row">
    <div class="col-xs-1">REX </div>
    <div class="col-xs-5">
         <asp:DropDownList ID="DdlREX" runat="server" AutoPostBack="True"></asp:DropDownList>
    </div>
    <div class="col-xs-6"></div>

</div>      

<div class="row">
    <div class="col-xs-1">Technicien </div>
    <div class="col-xs-5">
         <asp:DropDownList ID="DdlTechnicien" runat="server" AutoPostBack="True"></asp:DropDownList>
    </div>
    <div class="col-xs-6"></div>
</div>      
   
    <br/>
    <br/>

<div class="row">
    <div class="col-xs-1">Ville </div>
    <div class="col-xs-5">
         <asp:DropDownList ID="DdlVilles" runat="server" AutoPostBack="True"></asp:DropDownList>
    </div>
    <div class="col-xs-6"></div>
</div>     

<div class="row">
    <div class="col-xs-1">Sous-Station </div>
    <div class="col-xs-5">
         <asp:DropDownList ID="DdlSousStation" runat="server" AutoPostBack="True"></asp:DropDownList>
    </div>
    <div class="col-xs-6"></div>
</div>     

    <div class="row">
    <div class="col-xs-11">
        <asp:GridView ID="GwActionParSousStationPourUnTechnicienDonne" runat="server">
            <Columns>
                <asp:TemplateField>
                    <ItemTemplate>
                      <asp:LinkButton ID="LinkZoom" runat="server" CommandArgument ='<%# Eval("Id") %>' Text="Gérer" OnClick="ZoomActionPourUnTechnicienSousStation" > </asp:LinkButton> 
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>
    </div>
</div>
</asp:Content>
