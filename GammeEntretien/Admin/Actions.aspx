<%@ Page Title="" Language="vb" AutoEventWireup="false" MasterPageFile="~/GammeEntretien.Master" CodeBehind="Actions.aspx.vb" Inherits="GammeEntretien.Actions" %>
<asp:Content ID="Content1" ContentPlaceHolderID="Titre" runat="server">
    Gestion des actions préventive
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="Main" runat="server">

<div class="row danger">
    <div class="col-xs-11">
        <asp:Label ID="Lberreur" runat="server" style="color: #FF3300"></asp:Label>
    </div>
    <div class="col-xs-1"> </div>
</div>

<div class="row">
    <div class="col-xs-1">Gamme </div>
    <div class="col-xs-5">
         <asp:DropDownList ID="DdlGamme" runat="server" AutoPostBack="True"></asp:DropDownList></div>
        <div class="col-xs-1"></div>
    <div class="col-xs-6">
        <asp:Button ID="Boutton" runat="server" Text="..."  Visible ="true" /> 
    </div>            
</div>

    




<div class="row">
    <div class="col-xs-1">Secteur</div>
    <div class="col-xs-5">
        <asp:DropDownList ID="DdlSecteur" runat="server" AutoPostBack="True"></asp:DropDownList>
    </div>
    <div class="col-xs-1"></div>
    <div class="col-xs-6"></div>            
</div>

    <asp:Button ID="BtCreer" runat="server" Text="Créer un nouvelle enregistrement" OnClick="CreerAction" />

        <div class="row">
            <div class="col-xs-12">
                <asp:GridView ID="GwAction" runat="server">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:LinkButton ID="LinkZoom" runat="server" CommandArgument ='<%# Eval("Id") %>' Text="Gérer" OnClick="ZoomAction" > </asp:LinkButton> 
                            </ItemTemplate>
                        </asp:TemplateField>
                    </Columns>
                </asp:GridView>
            </div>
        </div>




</asp:Content>
