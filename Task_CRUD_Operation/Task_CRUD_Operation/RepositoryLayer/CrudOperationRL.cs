using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;
using Task_CRUD_Operation.CommonLayer.Model;

namespace Task_CRUD_Operation.RepositoryLayer
{
    public class CrudOperationRL : ICrudOperationRL
    {
        public readonly IConfiguration _configuration;
        public readonly SqlConnection _sqlConnection;
        //public readonly MySqlConnection _mySqlConnection;

        public CrudOperationRL(IConfiguration configuration)
        {
            _configuration = configuration;
            _sqlConnection = new SqlConnection(_configuration["ConnectionStrings:DBSettingConnection"]);
            //_mySqlConnection = new MySqlConnection(_configuration["ConnectionStrings:MySqlDBConnection"]);
        }
        public async Task<CreateRecordResponse> CreateRecord(CreateRecordRequest request)
        {
            CreateRecordResponse response = new CreateRecordResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                string strQuery = "Insert Into CrudOperationTable (UserName,Age) Values(@UserName,@Age)";
                using (SqlCommand sqlCommand = new SqlCommand(strQuery, _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;
                    sqlCommand.Parameters.AddWithValue("@UserName",request.Username);
                    sqlCommand.Parameters.AddWithValue("@Age", request.Age);
                    _sqlConnection.Open();
                    int status = await sqlCommand.ExecuteNonQueryAsync();
                    if (status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Something is Wrong";
                    }
                }
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = "Something is Wrong";
            }
            finally
            {
                _sqlConnection.Close();
            }
            return response;
        }

        public async Task<DeleteRecordResponse> DeleteInformation(DeleteRecordRequest request)
        {
            DeleteRecordResponse response = new DeleteRecordResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                string sqlQuery = "Delete from CrudOperationTable where Id=@Id";
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery, _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 100;
                    sqlCommand.Parameters.AddWithValue("@Id",request.UserId);
                    _sqlConnection.Open();
                    int status = await sqlCommand.ExecuteNonQueryAsync();
                    if (status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Something is Wrong";

                    }
                }
            }
            catch(Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                _sqlConnection.Close();
            }

            return response;
        }

        public async Task<ReadInformationResponse> ReadInformation()
        {
            ReadInformationResponse response = new ReadInformationResponse();
            response.readInformation = new List<ReadInformation>();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                string strQuery = "Select UserName,Age From CrudOperationTable";
                using (SqlCommand sqlCommand = new SqlCommand(strQuery, _sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 180;                   
                    _sqlConnection.Open();
                    using(SqlDataReader sqlDataReader = await sqlCommand.ExecuteReaderAsync())
                    {
                        if (sqlDataReader.HasRows)
                        {
                            response.readInformation = new List<ReadInformation>();
                            while (await sqlDataReader.ReadAsync())
                            {
                                ReadInformation getResponse = new ReadInformation();
                                //getResponse.UserID = sqlDataReader["ID"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["ID"]) : 0;
                                getResponse.UserName = sqlDataReader["UserName"] != DBNull.Value ? sqlDataReader["UserName"].ToString() : string.Empty;
                                getResponse.Age = sqlDataReader["Age"] != DBNull.Value ? Convert.ToInt32(sqlDataReader["Age"]) : 0;
                                response.readInformation.Add(getResponse);
                            }
                        }
                        else
                        {
                            response.Message = "No data Return";
                        }
                    }
                    //int status = await sqlCommand.ExecuteNonQueryAsync();
                    //if (status <= 0)
                    //{
                    //    response.IsSuccess = false;
                    //    response.Message = "Something is Wrong";
                    //}
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                _sqlConnection.Close();
            }
            return response;
        }

        public async Task<UpdateRecordResponse> UpdateInformation(UpdateRecordRequest request)
        {
            UpdateRecordResponse response = new UpdateRecordResponse();
            response.IsSuccess = true;
            response.Message = "Successful";
            try
            {
                string sqlQuery = "update CrudOperationTable set UserName= @UserName,Age=@Age where Id=@Id";
                using (SqlCommand sqlCommand = new SqlCommand(sqlQuery,_sqlConnection))
                {
                    sqlCommand.CommandType = System.Data.CommandType.Text;
                    sqlCommand.CommandTimeout = 100;
                    sqlCommand.Parameters.AddWithValue("@UserName",request.UserName);
                    sqlCommand.Parameters.AddWithValue("@Age", request.Age);
                    sqlCommand.Parameters.AddWithValue("@Id", request.UserID);
                    _sqlConnection.Open();
                    int Status = await sqlCommand.ExecuteNonQueryAsync();
                    if (Status <= 0)
                    {
                        response.IsSuccess = false;
                        response.Message = "Something is Wrong";
                    }
                }
            }
            catch (Exception ex)
            {
                response.IsSuccess = false;
                response.Message = ex.Message;
            }
            finally
            {
                _sqlConnection.Close();
            }
            return response;
        }
    }
}
