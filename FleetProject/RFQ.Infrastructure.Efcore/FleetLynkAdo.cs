using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using RFQ.Domain.Helper;
using RFQ.Domain.Interfaces;
using RFQ.Domain.Utility;
using System.Data;

namespace RFQ.Infrastructure.Efcore
{
    public class FleetLynkAdo : IFleetLynkAdo
    {
        private readonly string _connectionString;

        public FleetLynkAdo(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("RfqDBConnection");
        }

        public async Task<DataTable> ExecuteStoredProcedureAsync(string procedureName, List<SqlParameter> parameters)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(procedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    if (parameters != null && parameters.Count > 0)
                    {
                        command.Parameters.AddRange(parameters.ToArray());
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable resultTable = new DataTable();
                        await Task.Run(() => adapter.Fill(resultTable));
                        return resultTable;
                    }
                }
            }
        }

        public async Task<DataTable> ExecuteStoredProcedureAsync(List<SqlParameter> parameters)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(_connectionString))
                {
                    using (SqlCommand command = new SqlCommand(StoredProcedureHelper.sp_GetPagedData, connection))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        if (parameters != null && parameters.Count > 0)
                        {
                            command.Parameters.AddRange(parameters.ToArray());
                        }

                        using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                        {
                            DataTable resultTable = new DataTable();
                            await Task.Run(() => adapter.Fill(resultTable));
                            return resultTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }

        }


        public async Task<DataSet> ExecuteStoredProcedureDataSet(string procedureName, List<SqlParameter> parameters)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(procedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    if (parameters != null && parameters.Count > 0)
                    {
                        command.Parameters.AddRange(parameters.ToArray());
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataSet resultDataSet = new DataSet();
                        await Task.Run(() => adapter.Fill(resultDataSet));
                        return resultDataSet;
                    }
                }
            }
        }
        
        public async Task<DataSet> ExecuteStoredProcedureDataSet(List<SqlParameter> parameters)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(StoredProcedureHelper.sp_GetPagedData, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    if (parameters != null && parameters.Count > 0)
                    {
                        command.Parameters.AddRange(parameters.ToArray());
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataSet resultDataSet = new DataSet();
                        await Task.Run(() => adapter.Fill(resultDataSet));
                        return resultDataSet;
                    }
                }
            }
        }

        public int ExecuteNonQuery(string query, List<SqlParameter> parameters)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.Text;

                    if (parameters != null && parameters.Count > 0)
                    {
                        command.Parameters.AddRange(parameters.ToArray());
                    }

                    connection.Open();
                    return command.ExecuteNonQuery();
                }
            }
        }

        public object ExecuteScalar(string query, List<SqlParameter> parameters)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.Text;

                    if (parameters != null && parameters.Count > 0)
                    {
                        command.Parameters.AddRange(parameters.ToArray());
                    }

                    connection.Open();
                    return command.ExecuteScalar();
                }
            }
        }

        public DataTable ExecuteQuery(string query, List<SqlParameter> parameters)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.CommandType = CommandType.Text;

                    if (parameters != null && parameters.Count > 0)
                    {
                        command.Parameters.AddRange(parameters.ToArray());
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable resultTable = new DataTable();
                        adapter.Fill(resultTable);
                        return resultTable;
                    }
                }
            }
        }

        public async Task<DataTable> ExecuteStoredProcedure(string procedureName)
        {
            using (SqlConnection connection = new SqlConnection(_connectionString))
            {
                using (SqlCommand command = new SqlCommand(procedureName, connection))
                {
                    command.CommandType = CommandType.StoredProcedure;

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable resultTable = new DataTable();
                        await Task.Run(() => adapter.Fill(resultTable));
                        return resultTable;
                    }
                }
            }
        }

    }
}
