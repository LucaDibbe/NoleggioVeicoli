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
    public partial class DettaglioVeicolo : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

            if (IsPostBack)
            {
                return;
            }

            int Id = int.Parse(Request.QueryString["Id"]);

            PopolaMarcaDDL();
            PopolaAlimentazioneDDL();
            SetVeicolo(Id);
            
        }

        private void PopolaMarcaDDL()
        {
            var veicoliManager = new VeicoliManager("Data Source=sqlserverprincipale.database.windows.net;Initial Catalog=Stage2022;User ID=utente;Password=Safo2022!");
            ddlTipoMarca.DataSource = veicoliManager.GetMarca();
            ddlTipoMarca.DataTextField = "Marca";
            ddlTipoMarca.DataValueField = "Id";
            ddlTipoMarca.DataBind();
        
        }
        private void PopolaAlimentazioneDDL()
        {

            var veicoliManager = new VeicoliManager("Data Source=sqlserverprincipale.database.windows.net;Initial Catalog=Stage2022;User ID=utente;Password=Safo2022!");
            ddlAlimentazione.DataSource = veicoliManager.GetAlimentazione();
            ddlAlimentazione.DataTextField = "Alimentazione";
            ddlAlimentazione.DataValueField = "Id";
            ddlAlimentazione.DataBind();
           
        }

        public void SetVeicolo(int Id)
        {
            var veicoliManager = new VeicoliManager("Data Source=sqlserverprincipale.database.windows.net;Initial Catalog=Stage2022;User ID=utente;Password=Safo2022!");
            Session["Id"] = Id;
            var veicoloModelView = veicoliManager.GetVeicolo(Id);

            ddlTipoMarca.Items.Insert(0, new ListItem($"{veicoloModelView.Marca}", "-1"));
            ddlAlimentazione.Items.Insert(0, new ListItem($"{veicoloModelView.Alimentazione}", "-1"));
            txtModello.Text = veicoloModelView.Modello;
            txtTarga.Text = veicoloModelView.Targa;
            txtData.Text = veicoloModelView.Immatricolazione?.ToString("d");
            txtNote.Text = veicoloModelView.Note;
        }

        protected void btnModifica_Click(object sender, EventArgs e)
        {

            var veicoliManager = new VeicoliManager("Data Source=sqlserverprincipale.database.windows.net;Initial Catalog=Stage2022;User ID=utente;Password=Safo2022!");
            int idVeicolo = Convert.ToInt32(Session["Id"]);

            var veicolo = veicoliManager.GetVeicolo(idVeicolo);
            veicolo.Id = idVeicolo;
            if (int.Parse(ddlTipoMarca.SelectedValue) == -1)
            {
                veicolo.IdMarca = veicolo.IdMarca;
            }
            else
            {
                veicolo.IdMarca = int.Parse(ddlTipoMarca.SelectedValue);
            }
            
            veicolo.Modello = txtModello.Text;
            veicolo.Immatricolazione = DateTime.Parse(txtData.Text);
            veicolo.Targa = txtTarga.Text;
            if (int.Parse(ddlAlimentazione.SelectedValue) == -1)
            {
                veicolo.IdAlimentazione = veicolo.IdAlimentazione;
            }
            else
            {
                veicolo.IdAlimentazione = int.Parse(ddlAlimentazione.SelectedValue);
            }
                
            veicolo.Note = txtNote.Text;
           

            veicoliManager.UpdateVeicolo(veicolo);

            infoControl.SetMessage(ApplicazioneViecoli.Controls.InfoControl.TipoMessaggio.Success, "Il veicolo è stato modificato");

        }

        protected void btnElimina_Click(object sender, EventArgs e)
        {
            var veicoliManager = new VeicoliManager("Data Source=sqlserverprincipale.database.windows.net;Initial Catalog=Stage2022;User ID=utente;Password=Safo2022!");
            int idVeicolo = Convert.ToInt32(Session["Id"]);
            veicoliManager.DeleteVeicolo(idVeicolo);

            infoControl.SetMessage(ApplicazioneViecoli.Controls.InfoControl.TipoMessaggio.Danger, "Il veicolo è stato eliminato");

        }
    }
}