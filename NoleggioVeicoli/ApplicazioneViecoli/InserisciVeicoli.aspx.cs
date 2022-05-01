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
    public partial class InserisciVeicoli : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                return;
            }



            PopolaMarcaDDL();
            PopolaAlimentazioneDDL();



            //    List<ComuneModel> comuni = Singleton.Instance.ListaComuni;
            //    ddComuneNascita.DataSource = comuni;
            //    ddComuneNascita.DataTextField = "Comune";
            //    ddComuneNascita.DataValueField = "Id";
            //    ddComuneNascita.DataBind();
            //    ddComuneNascita.Items.Insert(0, new ListItem("seleziona", "-1"));


            //var veicoloModel = new VeicoliModel();
            //veicoloModel.
            //veicoliManager.InsertPersona();
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


        protected void Immatricolazione_SelectionChanged(object sender, EventArgs e)
        {
            txtData.Text = Immatricolazione.SelectedDate.ToShortDateString();
        }

        protected void btnInserisci_Click(object sender, EventArgs e)
        {

            

            var veicoliModel = new VeicoliModel();

            veicoliModel.Modello = txtModello.Text;
            veicoliModel.Targa = txtTarga.Text;
            veicoliModel.IdMarca = int.Parse(ddlTipoMarca.SelectedValue);
            veicoliModel.IdAlimentazione = int.Parse(ddlAlimentazione.SelectedValue);
            veicoliModel.Immatricolazione = DateTime.Parse(txtData.Text);
            veicoliModel.Note = txtNote.Text;




            var vaicoliManager = new VeicoliManager("Data Source=sqlserverprincipale.database.windows.net;Initial Catalog=Stage2022;User ID=utente;Password=Safo2022!");
            bool isVeicoloInserito = vaicoliManager.InsertVeicolo(veicoliModel);
            infoControl.SetMessage(ApplicazioneViecoli.Controls.InfoControl.TipoMessaggio.Success, "Il veicolo è stato aggiunto");

        }

        private bool IsFormValido()
        {


            if (string.IsNullOrWhiteSpace(txtModello.Text))
            {
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTarga.Text))
            {
                return false;
            }
            if (!int.TryParse(ddlTipoMarca.SelectedValue, out int IdMarca) || IdMarca <= 0)
            {
                return false;
            }

            return true;
        }

    }
}