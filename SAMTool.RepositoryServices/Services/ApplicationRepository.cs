using SAMTool.DataAccessObject.DTO;
using SAMTool.RepositoryServices.Contracts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SAMTool.RepositoryServices.Services
{
    public class ApplicationRepository: IApplicationRepository
    {
        private IDatabaseFactory _databaseFactory;
        public ApplicationRepository(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        public object DeleteApplication(Application appObj)
        {
            SqlParameter outParameter = null;
            try
            {

                using (SqlConnection con = _databaseFactory.GetDBConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        cmd.Connection = con;
                        cmd.CommandText = "[DeleteApplication]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = appObj.ID;
                        outParameter = cmd.Parameters.Add("@StatusOut", SqlDbType.Int);
                        outParameter.Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            switch (outParameter.Value.ToString())
            {
                case "1":
                    return new
                    {
                        Status = outParameter.Value.ToString(),
                        Message = "Delete Success"
                    };
                default:
                    return new
                    {
                        Status = outParameter.Value.ToString(),
                        Message = "Delete Failure"
                    };
            }
        }

        public List<Application> GetAllApplication()
        {
            List<Application> ApplicationList = null;
            try
            {
                using (SqlConnection con = _databaseFactory.GetDBConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        cmd.Connection = con;
                        cmd.CommandText = "[GetAllApplication]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if ((sdr != null) && (sdr.HasRows))
                            {
                                ApplicationList = new List<Application>();
                                while (sdr.Read())
                                {
                                    Application applicationObj = new Application();

                                    {
                                        applicationObj.ID = (sdr["ID"].ToString() != "" ? Guid.Parse(sdr["ID"].ToString()) : applicationObj.ID);
                                        applicationObj.Name = (sdr["Name"].ToString() != "" ? sdr["Name"].ToString() : applicationObj.Name);
                                        //applicationObj.CreatedDate = (sdr["CreatedDate"].ToString() != "" ? sdr["CreatedDate"].ToString() : applicationObj.CreatedDate);
                                        
                                    };

                                    ApplicationList.Add(applicationObj);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return ApplicationList;
        }

        public object InsertApplication(Application appObj)
        {
            SqlParameter outParameter = null;
            SqlParameter outParameter2 = null;
            try
            {

                using (SqlConnection con = _databaseFactory.GetDBConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        cmd.Connection = con;
                        cmd.CommandText = "[InsertApplication]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 250).Value = appObj.Name; 
                        cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar, 250).Value = "Gibin"; //userObj.logDetails.CreatedBy;
                        cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = DateTime.Now;//userObj.logDetails.CreatedDate; 
                        outParameter = cmd.Parameters.Add("@StatusOut", SqlDbType.Int);
                        outParameter.Direction = ParameterDirection.Output;
                        outParameter2 = cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier);
                        outParameter2.Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            switch (outParameter.Value.ToString())
            {
                case "1":
                    return new
                    {
                        ID = Guid.Parse(outParameter2.Value.ToString()),
                        Status = outParameter.Value.ToString(),
                        Message = "Insert Success"
                    };
                case "2":
                    return new
                    {
                        Status = outParameter.Value.ToString(),
                        Message = "Duplicate Application Name"
                    };
                default:
                    return new
                    {
                        Status = outParameter.Value.ToString(),
                        Message = "Insert Failure"
                    };
            }
        }

        public object UpdateApplication(Application appObj)
        {

            SqlParameter outParameter = null;
            try
            {

                using (SqlConnection con = _databaseFactory.GetDBConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        cmd.Connection = con;
                        cmd.CommandText = "[UpdateApplication]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = appObj.ID;
                        cmd.Parameters.Add("@Name", SqlDbType.NVarChar, 250).Value = appObj.Name; 
                        cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar, 250).Value = "Gibin"; //userObj.logDetails.CreatedBy;
                        cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = DateTime.Now;//userObj.logDetails.CreatedDate;

                        outParameter = cmd.Parameters.Add("@StatusOut", SqlDbType.Int);
                        outParameter.Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
            switch (outParameter.Value.ToString())
            {
                case "1":
                    return new
                    {
                        Status = outParameter.Value.ToString(),
                        Message = "Update Success"
                    };
                default:
                    return new
                    {
                        Status = outParameter.Value.ToString(),
                        Message = "Update Failure"
                    };
            }


        }
    }
}