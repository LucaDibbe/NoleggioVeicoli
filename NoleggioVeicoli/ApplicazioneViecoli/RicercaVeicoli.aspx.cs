using NoleggioVeicoli.Business.Models;
using NoleggioVeicoli.Managers;
using NoleggioVeicoli.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ApplicazioneViecoli
{
    public partial class RicercaVeicoli : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }



            PopolaMarcaDDL();
            PopolaAlimentazioneDDL();
        }

        private void PopolaMarcaDDL()
        {
            var veicoliManager = new VeicoliManager("Data Source=sqlserverprincipale.database.windows.net;Initial Catalog=Stage2022;User ID=utente;Password=Safo2022!");
            ddlTipoMarca.DataSource = veicoliManager.GetMarca();
            ddlTipoMarca.DataTextField = "Marca";
            ddlTipoMarca.DataValueField = "Id";
            ddlTipoMarca.DataBind();
            ddlTipoMarca.Items.Insert(0, new ListItem("seleziona", "-1"));

        }
        private void PopolaAlimentazioneDDL()
        {

            var veicoliManager = new VeicoliManager("Data Source=sqlserverprincipale.database.windows.net;Initial Catalog=Stage2022;User ID=utente;Password=Safo2022!");
            ddlAlimentazione.DataSource = veicoliManager.GetAlimentazione();
            ddlAlimentazione.DataTextField = "Alimentazione";
            ddlAlimentazione.DataValueField = "Id";
            ddlAlimentazione.DataBind();
            ddlAlimentazione.Items.Insert(0, new ListItem("seleziona", "-1"));
        }


        protected void btnRicerca_Click(object sender, EventArgs e)
        {
            var veicoliManager = new VeicoliManager("Data Source=sqlserverprincipale.database.windows.net;Initial Catalog=Stage2022;User ID=utente;Password=Safo2022!");

            var ricercaVeicoliModel = new RicercaVeicoliModel();

            ricercaVeicoliModel.IdMarca = int.Parse(ddlTipoMarca.SelectedValue);
            ricercaVeicoliModel.Modello = txtModello.Text;
            ricercaVeicoliModel.Targa = txtTarga.Text;
            ricercaVeicoliModel.IdAlimentazione = int.Parse(ddlAlimentazione.SelectedValue);


            if (string.IsNullOrEmpty(txtDataDa.Text))
            {
                ricercaVeicoliModel.ImmatricolazioneDA = DateTime.Parse("01/01/1753");
            }
            else
            {
                DateTime dateTime;
                DateTime.TryParse(txtDataDa.Text, out dateTime);
                ricercaVeicoliModel.ImmatricolazioneDA = dateTime;
            }
            if (string.IsNullOrEmpty(txtDataA.Text))
            {
                ricercaVeicoliModel.ImmatricolazioneA = DateTime.MaxValue;
            }
            else
            {
                DateTime date;
                DateTime.TryParse(txtDataA.Text, out date);
                ricercaVeicoliModel.ImmatricolazioneA = date;
            }


            //if(Noleggiato.Checked)
            //{
            //    ricercaVeicoliModel.Noleggiato = Noleggiato.Text;
            //}
            //if (Disponibile.Checked)
            //{
            //    ricercaVeicoliModel.Noleggiato = Disponibile.Text;
            //}

            var listRicerca = veicoliManager.RicercaVeicoli(ricercaVeicoliModel);
            gvVeicoli.DataSource = listRicerca;
            gvVeicoli.DataBind();
            
        }

        protected void Immatricolazione_SelectionChanged(object sender, EventArgs e)
        {
            txtDataDa.Text = ImmatricolazioneDA.SelectedDate.ToShortDateString();
        }

        protected void ImmatricolazioneA_SelectionChanged(object sender, EventArgs e)
        {
            txtDataA.Text = ImmatricolazioneA.SelectedDate.ToShortDateString();

        }

        

        protected void gvVeicoli_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int index = 0;
            
            if (e.CommandName == "Dettaglio")
            {
                index = Convert.ToInt32(e.CommandArgument);
                var Id = gvVeicoli.DataKeys[index]["Id"].ToString();
                Session["Id"] = Id;
                Response.Redirect("DettaglioVeicolo.aspx?Id=" + Id);
            }
        }

        protected void btnReset_Click(object sender, EventArgs e)
        {
            Response.Redirect("RicercaVeicoli.aspx");
        }
    }
}