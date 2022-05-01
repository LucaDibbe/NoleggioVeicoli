<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="InserisciVeicoli.aspx.cs" Inherits="ApplicazioneViecoli.InserisciVeicoli" %>
<%@ Register Src="~/Controls/InfoControl.ascx" TagPrefix="uc1" TagName="InfoControl" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

         <uc1:InfoControl runat="server" id="infoControl" />




<div class="panel panel-default">
    <div class="panel-heading">
        <h3 class="panel-title">Inserisci Veicolo</h3>
    </div>

    <div class="panel-body">
        <div class="form-group">
            <label for="ddlTipoMarca">Tipo marca</label>
            <asp:DropDownList ID="ddlTipoMarca"
                AutoPostBack="False"
                CssClass="form-control"
                runat="server">
            </asp:DropDownList>
        </div>

        <div class="form-group">
            <label for="txtModello">Modello</label>
            <asp:TextBox runat="server" ID="txtModello" CssClass="form-control">
            </asp:TextBox>
        </div>
        <div class="form-group">
            <label for="txtTarga">Targa</label>
            <asp:TextBox runat="server" ID="txtTarga" CssClass="form-control">
            </asp:TextBox>
        </div>
        <div class="form-group">
            <label for="ddlAlimentazione">Tipo alimentazione</label>
            <asp:DropDownList ID="ddlAlimentazione"
                AutoPostBack="False"
                CssClass="form-control"
                runat="server">
            </asp:DropDownList>
        </div>
        <div class="form-group">
            <label for="txtImmatricolazione">Immatricolazione</label>
            <asp:TextBox runat="server" ID="txtData" CssClass="form-control">
            </asp:TextBox>
        </div>




        <div class="form-group">

            <asp:Calendar runat="server" ID="Immatricolazione" OnSelectionChanged="Immatricolazione_SelectionChanged"></asp:Calendar>
        </div>
        <div class="form-group">
            <label for="txtNote">Note</label>
            <asp:TextBox runat="server" ID="txtNote" CssClass="form-control">
            </asp:TextBox>
        </div>
    </div>
     <asp:Button runat="server" ID="btnInserisci" Text="Inserisci" CssClass="btn btn-default" OnClick="btnInserisci_Click" />
    </div>
           
    <style>        body {
            background-color : blue 
                   }
        footer{
            color : white
        }
    </style>   

</asp:Content>
