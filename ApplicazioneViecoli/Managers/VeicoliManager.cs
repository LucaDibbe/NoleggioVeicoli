using NoleggioVeicoli.Models;
using System;
using System.Collections.Generic;
using System.Data;
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

        public bool InsertVeicolo(Models.VeicoliModel veicoliModel)
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
                        sqlCommand.Parameters.AddWithValue("@IdAlimentazione", veicoliModel.IdAlimentazione);
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

        public List<MarcaModel> GetMarca()
        {
            var TipoMarcaList = new List<MarcaModel>();
            var sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("\t[Id]");
            sb.AppendLine("\t,[Marca]");
            sb.AppendLine("FROM [dbo].[LDB_Marca]");

            var dataSet = new DataSet();
            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString()))
                {
                    using (var sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlDataAdapter.SelectCommand = sqlCommand;
                        sqlDataAdapter.SelectCommand.Connection = sqlConnection;
                        sqlDataAdapter.Fill(dataSet);

                        var dataTable = dataSet.Tables[0];


                        if (dataTable == null || dataTable.Rows.Count <= 0)
                        {
                            return new List<MarcaModel>();
                        }

                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            var TipoMarca = new MarcaModel();
                            //personaModel.Id = Convert.ToInt32(dataRow["Id"]);
                            TipoMarca.Id = dataRow.Field<int>("id");
                            TipoMarca.Marca = dataRow.Field<string>("Marca");
                            TipoMarcaList.Add(TipoMarca);
                        }
                    }
                }
            }
            return TipoMarcaList;
        }


        public List<AlimentazioneModel> GetAlimentazione()
        {
            var TipoAlimentazioneList = new List<AlimentazioneModel>();
            var sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("\t[Id]");
            sb.AppendLine("\t,[Alimentazione]");
            sb.AppendLine("FROM [dbo].[LDB_Alimentazione]");

            var dataSet = new DataSet();
            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString()))
                {
                    using (var sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlDataAdapter.SelectCommand = sqlCommand;
                        sqlDataAdapter.SelectCommand.Connection = sqlConnection;
                        sqlDataAdapter.Fill(dataSet);

                        var dataTable = dataSet.Tables[0];


                        if (dataTable == null || dataTable.Rows.Count <= 0)
                        {
                            return new List<AlimentazioneModel>();
                        }

                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            var TipoAlimentazione = new AlimentazioneModel();
                            //personaModel.Id = Convert.ToInt32(dataRow["Id"]);
                            TipoAlimentazione.Id = dataRow.Field<int>("Id");
                            TipoAlimentazione.Alimentazione = dataRow.Field<string>("Alimentazione");
                            TipoAlimentazioneList.Add(TipoAlimentazione);
                        }
                    }
                }
            }
            return TipoAlimentazioneList;
        }

    }
}