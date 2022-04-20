using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Web;

namespace NoleggioVeicoli.Managers
{
    public class VeicoliManager
    {
        public VeicoliManager(string connectionString)
        {
            this.ConnectionString = connectionString;
        }
        public string ConnectionString { get; set; }


        public bool InsertVeicoli(Models.VeicoliModel veicoliModel)
        {
            bool isInserito = false;
            var sb = new StringBuilder();
            sb.AppendLine("INSERT INTO [dbo].[LDB_Veicoli] (");
            sb.AppendLine("[IdMarca]");
            sb.AppendLine(",[Modello]");
            sb.AppendLine(",[Targa]");
            sb.AppendLine(",[Immatricolazione]");
            sb.AppendLine(",[IdAlimentazione]");
            sb.AppendLine(",[Noleggiato]");
            sb.AppendLine(",[Nominativo]");
            sb.AppendLine(",[Note]");
            sb.AppendLine(") VALUES (");
            sb.AppendLine("@IdMarca");
            sb.AppendLine(",@Modello");
            sb.AppendLine(",@Targa");
            sb.AppendLine(",@Immatricolazione");
            sb.AppendLine(",@IdAlimentazione");
            sb.AppendLine(",@Noleggiato");
            sb.AppendLine(",@Nominativo");
            sb.AppendLine(",@Note");
            sb.AppendLine(")");

            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString(), sqlConnection))
                {
                    if (veicoliModel.IdMarca.HasValue)
                    {
                        sqlCommand.Parameters.AddWithValue("@IdMarca", veicoliModel.IdMarca);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@IdMarca", DBNull.Value);
                    }
                    if (string.IsNullOrEmpty(veicoliModel.Modello))
                    {
                        sqlCommand.Parameters.AddWithValue("@Modello", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Modello", veicoliModel.Modello);
                    }

                    if (string.IsNullOrEmpty(veicoliModel.Targa))
                    {
                        sqlCommand.Parameters.AddWithValue("@Targa", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Targa", veicoliModel.Targa);
                    }
                    if (veicoliModel.Immatricolazione.HasValue)
                    {
                        sqlCommand.Parameters.AddWithValue("@Immatricolazione", veicoliModel.Immatricolazione);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Immatricolazione", DBNull.Value);
                    }
                    if (veicoliModel.IdAlimentazione.HasValue)
                    {
                        sqlCommand.Parameters.AddWithValue("@IdComuneNascita", veicoliModel.IdAlimentazione);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@IdAlimentazione", DBNull.Value);
                    }
                    if (string.IsNullOrEmpty(veicoliModel.Noleggiato))
                    {
                        sqlCommand.Parameters.AddWithValue("@Noleggiato", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Noleggiato", veicoliModel.Noleggiato);
                    }
                    if (string.IsNullOrEmpty(veicoliModel.Nominativo))
                    {
                        sqlCommand.Parameters.AddWithValue("@Nominativo", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Nominativo", veicoliModel.Nominativo);
                    }
                    

                    if (string.IsNullOrEmpty(veicoliModel.Note))
                    {
                        sqlCommand.Parameters.AddWithValue("@Note", DBNull.Value);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Note", veicoliModel.Note);
                    }

                    

                    

                    var numRigheInserite = sqlCommand.ExecuteNonQuery();
                    if (numRigheInserite >= 1)
                    {
                        isInserito = true;
                    }
                }
            }
            return isInserito;
        }
    }
}