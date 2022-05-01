<%@ Page Title="" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="RicercaVeicoli.aspx.cs" Inherits="ApplicazioneViecoli.RicercaVeicoli" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">


    <div class="panel panel-default">
        <div class="panel-heading">
            <h3 class="panel-title">Ricerca Veicolo</h3>
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
                <label for="txtImmatricolazioneDA">ImmatricolazioneDA</label>
                <asp:TextBox runat="server" ID="txtDataDa" CssClass="form-control">
                </asp:TextBox>
            </div>




            <div class="form-group">

                <asp:Calendar runat="server" ID="ImmatricolazioneDA" OnSelectionChanged="Immatricolazione_SelectionChanged"></asp:Calendar>
            </div>
            <div class="form-group">
                <label for="txtImmatricolazioneA">ImmatricolazioneA</label>
                <asp:TextBox runat="server" ID="txtDataA" CssClass="form-control">
                </asp:TextBox>
            </div>




            <div class="form-group">

                <asp:Calendar runat="server" ID="ImmatricolazioneA" OnSelectionChanged="ImmatricolazioneA_SelectionChanged"></asp:Calendar>
            </div>
            



        </div>
        <asp:Button runat="server" ID="btnRicerca" Text="Ricerca" CssClass="btn btn-default" OnClick="btnRicerca_Click" />
        <asp:Button runat="server" ID="btnReset" Text="Reset" CssClass="btn btn-default" OnClick="btnReset_Click" />
    </div>

    <asp:GridView runat="server" ID="gvVeicoli" CssClass="table table table-bordered table-hover table-striped no-margin" BorderStyle="None" AutoGenerateColumns="False" DataKeyNames="Id"  OnRowCommand="gvVeicoli_RowCommand">
        <Columns>
             <asp:ButtonField ButtonType="Button" AccessibleHeaderText="Dettaglio" Text="Dettaglio" CommandName="Dettaglio" />

            <asp:BoundField DataField="Id" HeaderText="Id" Visible="false">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Marca" HeaderText="Marca">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Modello" HeaderText="Modello">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            <asp:BoundField DataField="Immatricolazione" HeaderText="DataImmatricolazione" DataFormatString="{0:d}">
                <HeaderStyle HorizontalAlign="Center" />
            </asp:BoundField>
            

           
        </Columns>
    </asp:GridView>


     <style>        body {
            background-color : blue 
                   }
        footer{
            color : white
        }
    </style>   

</asp:Content>
