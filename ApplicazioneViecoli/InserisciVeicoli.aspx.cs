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
            txtData.Text = Immatricolazione.SelectedDate.ToString();
        }

        protected void btnInserisci_Click(object sender, EventArgs e)
        {

            //if (txtNome.Text == "" || txtCognome.Text == "") {
            //    //Visualizzo un messaggio di errore
            //    return;
            //}

            //if (!IsFormValido())
            //{
            //    //Visualizzo un messaggio di errore
            //    //infoControl.SetMessage(Web.Controls.InfoControl.TipoMessaggio.Danger, "Il form non è valido, nessun record inserito");
            //    return;
            //}
            //var nome = txtNome.Text;

            var veicoliModel = new VeicoliModel();

            veicoliModel.Modello = txtModello.Text;
            veicoliModel.Targa = txtTarga.Text;
            veicoliModel.IdMarca = int.Parse(ddlTipoMarca.SelectedValue);
            veicoliModel.IdAlimentazione = int.Parse(ddlAlimentazione.SelectedValue);


            

            var vaicoliManager = new VeicoliManager("Data Source=sqlserverprincipale.database.windows.net;Initial Catalog=Stage2022;User ID=utente;Password=Safo2022!");
            bool isVeicoloInserito = vaicoliManager.InsertVeicolo(veicoliModel);
        }

        //private bool IsFormValido()
        //{

            
        //    if (string.IsNullOrWhiteSpace(txtModello.Text))
        //    {
        //        return false;
        //    }
        //    if (string.IsNullOrWhiteSpace(txtTarga.Text))
        //    {
        //        return false;
        //    }
        //    if (!int.TryParse(ddlTipoMarca.SelectedValue, out int IdMarca) || IdMarca <= 0)
        //    {
        //        return false;
        //    }

        //    return true;
        //}

    }
}