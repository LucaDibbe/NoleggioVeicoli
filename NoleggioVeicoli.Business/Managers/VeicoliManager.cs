using NoleggioVeicoli.Business.Models;
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
                            TipoAlimentazione.Id = dataRow.Field<int>("Id");
                            TipoAlimentazione.Alimentazione = dataRow.Field<string>("Alimentazione");
                            TipoAlimentazioneList.Add(TipoAlimentazione);
                        }
                    }
                }
            }
            return TipoAlimentazioneList;
        }

        public VeicoliModelView GetVeicolo(int Id)
        {
            var veicoliModelView = new VeicoliModelView();
            var sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("\t[LDB_Veicoli].[Id]");
            sb.AppendLine("\t,[LDB_Veicoli].[IdMarca]");
            sb.AppendLine("\t,[LDB_Marca].[Marca]");
            sb.AppendLine("\t,[LDB_Veicoli].[Modello]");
            sb.AppendLine("\t,[LDB_Veicoli].[Targa]");
            sb.AppendLine("\t,[LDB_Veicoli].[IdAlimentazione]");
            sb.AppendLine("\t,[LDB_Alimentazione].[Alimentazione]");
            sb.AppendLine("\t,[LDB_Veicoli].[Immatricolazione]");
            sb.AppendLine("\t,[LDB_Veicoli].[Noleggiato]");
            sb.AppendLine("\t,[LDB_Veicoli].[Nominativo]");
            sb.AppendLine("\t,[LDB_Veicoli].[Note]");

            sb.AppendLine("FROM [dbo].[LDB_Veicoli]");

            sb.AppendLine("\tINNER JOIN [dbo].[LDB_Marca]");
            sb.AppendLine("\tON [dbo].[LDB_Veicoli].[IdMarca] = [dbo].[LDB_Marca].[Id]");

            sb.AppendLine("\tINNER JOIN [dbo].[LDB_Alimentazione]");
            sb.AppendLine("\tON [dbo].[LDB_Veicoli].[IdAlimentazione] = [dbo].[LDB_Alimentazione].[Id]");

            sb.AppendLine("WHERE [LDB_Veicoli].[Id]= @Id");

            var dataSet = new DataSet();
            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString()))
                {
                    sqlCommand.Parameters.AddWithValue("@Id",Id);

                    using (var sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlDataAdapter.SelectCommand = sqlCommand;
                        sqlDataAdapter.SelectCommand.Connection = sqlConnection;
                        sqlDataAdapter.Fill(dataSet);

                        var dataTable = dataSet.Tables[0];
                        foreach (DataRow dataRow in dataTable.Rows)
                        {


                            veicoliModelView.Id = dataRow.Field<int>("Id");
                            veicoliModelView.IdMarca = dataRow.Field<int>("IdMarca");
                            veicoliModelView.Marca = dataRow.Field<string>("Marca");
                            veicoliModelView.Alimentazione = dataRow.Field<string>("Alimentazione");
                            veicoliModelView.IdAlimentazione = dataRow.Field<int>("IdAlimentazione");
                            veicoliModelView.Modello = dataRow.Field<string>("Modello");
                            veicoliModelView.Targa = dataRow.Field<string>("Targa");
                            veicoliModelView.Immatricolazione = dataRow.Field<DateTime?>("Immatricolazione");
                            veicoliModelView.Noleggiato = dataRow.Field<string>("Noleggiato");
                            veicoliModelView.Nominativo = dataRow.Field<string>("Nominativo");
                            veicoliModelView.Note = dataRow.Field<string>("Note");



                        }
                    }


                }
                return veicoliModelView;
            }
        }

        public List<VeicoliModelView> RicercaVeicoli(RicercaVeicoliModel ricercaVeicoliModel)
        {
           
            var veicoliModelList = new List<VeicoliModelView>();
            var sb = new StringBuilder();
            sb.AppendLine("SELECT");
            sb.AppendLine("\t[LDB_Veicoli].[Id]");
            sb.AppendLine("\t,[LDB_Marca].[Marca]");
            sb.AppendLine("\t,[LDB_Veicoli].[Modello]");
            sb.AppendLine("\t,[LDB_Veicoli].[Modello]");
            sb.AppendLine("\t,[LDB_Veicoli].[IdAlimentazione]");
            sb.AppendLine("\t,[LDB_Alimentazione].[Alimentazione]");
            sb.AppendLine("\t,[LDB_Veicoli].[Targa]");
            sb.AppendLine("\t,[LDB_Veicoli].[Immatricolazione]");
            sb.AppendLine("\t,[LDB_Veicoli].[Noleggiato]");
            
            sb.AppendLine("FROM [dbo].[LDB_Veicoli]");

            sb.AppendLine("\tINNER JOIN [dbo].[LDB_Marca]");
            sb.AppendLine("\tON [dbo].[LDB_Veicoli].[IdMarca] = [dbo].[LDB_Marca].[Id]");

            sb.AppendLine("\tINNER JOIN [dbo].[LDB_Alimentazione]");
            sb.AppendLine("\tON [dbo].[LDB_Veicoli].[IdAlimentazione] = [dbo].[LDB_Alimentazione].[Id]");
            
            sb.AppendLine("WHERE 1=1");


            
            
            if(ricercaVeicoliModel.IdMarca>0)
            {
                sb.AppendLine("And IdMarca = @IdMarca");
            }
            if (!string.IsNullOrEmpty(ricercaVeicoliModel.Marca))
            {
                sb.AppendLine("And Marca = @Marca");
            }
            if (!string.IsNullOrEmpty(ricercaVeicoliModel.Modello))
            {
                sb.AppendLine("And Modello like @Modello");
            }
            if (ricercaVeicoliModel.IdAlimentazione > 0)
            {
                sb.AppendLine("And IdAlimentazione = @IdAlimentazione");
            }
            if (!string.IsNullOrEmpty(ricercaVeicoliModel.Alimentazione))
            {
                sb.AppendLine("And Alimentazione = @Alimentazione");
            }
            if (!string.IsNullOrEmpty(ricercaVeicoliModel.Targa))
            {
                sb.AppendLine("And Targa like @Targa");
            }
            if (ricercaVeicoliModel.ImmatricolazioneDA.HasValue)
            {
                sb.AppendLine("And Immatricolazione between @ImmatricolazioneDA");
            }
            if (ricercaVeicoliModel.ImmatricolazioneA.HasValue)
            {
                sb.AppendLine("And @ImmatricolazioneA");
            }
            if (!string.IsNullOrEmpty(ricercaVeicoliModel.Noleggiato))
            {
                sb.AppendLine("And Noleggiato = @Noleggiato");
            }
           

            var dataSet = new DataSet();
            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString()))
                {
                    
                    if(ricercaVeicoliModel.IdMarca > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@IdMarca", ricercaVeicoliModel.IdMarca);
                    }
                    if (!string.IsNullOrEmpty(ricercaVeicoliModel.Marca))
                    {
                        sqlCommand.Parameters.AddWithValue("@Marca", ricercaVeicoliModel.Marca);
                    }
                    if (!string.IsNullOrEmpty(ricercaVeicoliModel.Modello))
                    {
                        sqlCommand.Parameters.AddWithValue("@Modello", $"{ricercaVeicoliModel.Modello}%");
                    }
                    if (ricercaVeicoliModel.IdAlimentazione > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@IdAlimentazione", ricercaVeicoliModel.IdAlimentazione);
                    }
                    if (!string.IsNullOrEmpty(ricercaVeicoliModel.Alimentazione))
                    {
                        sqlCommand.Parameters.AddWithValue("@Alimentazione", ricercaVeicoliModel.Alimentazione);
                    }
                    if (!string.IsNullOrEmpty(ricercaVeicoliModel.Targa))
                    {
                        sqlCommand.Parameters.AddWithValue("@Targa", $"{ricercaVeicoliModel.Targa}%");
                    }
                    if (ricercaVeicoliModel.ImmatricolazioneDA.HasValue)
                    {
                        sqlCommand.Parameters.AddWithValue("@ImmatricolazioneDA", ricercaVeicoliModel.ImmatricolazioneDA);
                    }
                    if (ricercaVeicoliModel.ImmatricolazioneA.HasValue)
                    {
                        sqlCommand.Parameters.AddWithValue("@ImmatricolazioneA", ricercaVeicoliModel.ImmatricolazioneA);
                    }
                    if (!string.IsNullOrEmpty(ricercaVeicoliModel.Noleggiato))
                    {
                        sqlCommand.Parameters.AddWithValue("@Noleggiato", ricercaVeicoliModel.Noleggiato);
                    }
                    

                    using (var sqlDataAdapter = new SqlDataAdapter(sqlCommand))
                    {
                        sqlDataAdapter.SelectCommand = sqlCommand;
                        sqlDataAdapter.SelectCommand.Connection = sqlConnection;
                        sqlDataAdapter.Fill(dataSet);

                        var dataTable = dataSet.Tables[0];
                        foreach (DataRow dataRow in dataTable.Rows)
                        {
                            var veicoliModelView = new VeicoliModelView();

                            veicoliModelView.Id = dataRow.Field<int>("Id");
                            veicoliModelView.Marca = dataRow.Field<string>("Marca");
                            veicoliModelView.Modello = dataRow.Field<string>("Modello");
                            veicoliModelView.Alimentazione = dataRow.Field<string>("Alimentazione");
                            veicoliModelView.Targa = dataRow.Field<string>("Targa");
                            veicoliModelView.Immatricolazione = dataRow.Field<DateTime?>("Immatricolazione");
                            veicoliModelView.Noleggiato = dataRow.Field<string>("Noleggiato");
                            veicoliModelList.Add(veicoliModelView);
                        }
                    }
                }
            }
            return veicoliModelList;
        }

        public bool UpdateVeicolo(VeicoliModelView veicoliModel)
        {
            bool modifica = false;
            var sb = new StringBuilder();
            sb.AppendLine("UPDATE [dbo].[LDB_Veicoli]");
            sb.AppendLine("SET");
            sb.AppendLine("[LDB_Veicoli].[IdMarca] = @IdMarca");
            sb.AppendLine(",[Modello] = @Modello");
            sb.AppendLine(",[Targa] = @Targa");
            sb.AppendLine(",[Immatricolazione] = @Immatricolazione");
            sb.AppendLine(",[LDB_Veicoli].[IdAlimentazione] = @IdAlimentazione");
            sb.AppendLine(",[Note] = @Note");
           
            sb.AppendLine("WHERE [LDB_Veicoli].Id = @Id");

            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString(), sqlConnection))
                {
                    if (veicoliModel.Id > 0)
                    {
                        sqlCommand.Parameters.AddWithValue("@Id", veicoliModel.Id);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Id", DBNull.Value);
                    }
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
                    if (veicoliModel.IdAlimentazione.HasValue)
                    {
                        sqlCommand.Parameters.AddWithValue("@IdAlimentazione", veicoliModel.IdAlimentazione);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@IdAlimentazione", DBNull.Value);
                    }
                    if (veicoliModel.Immatricolazione.HasValue)
                    {
                        sqlCommand.Parameters.AddWithValue("@Immatricolazione", veicoliModel.Immatricolazione);
                    }
                    else
                    {
                        sqlCommand.Parameters.AddWithValue("@Immatricolazione", DateTime.Now);
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
                        modifica = true;
                    }
                }
            }
            return modifica;
        }

        public void DeleteVeicolo(int Id)
        {
            var sb = new StringBuilder();
            sb.AppendLine("DELETE");
            sb.AppendLine("FROM");
            sb.AppendLine("\t[LDB_Veicoli]");
            sb.AppendLine("WHERE Id=@Id");

            using (SqlConnection sqlConnection = new SqlConnection(this.ConnectionString))
            {
                sqlConnection.Open();
                using (SqlCommand sqlCommand = new SqlCommand(sb.ToString(), sqlConnection))
                {
                    sqlCommand.Parameters.AddWithValue("@Id", Id);

                    sqlCommand.ExecuteNonQuery();

                }
            }

        }

    }
}