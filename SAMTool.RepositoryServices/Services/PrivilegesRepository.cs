using SAMTool.RepositoryServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAMTool.DataAccessObject.DTO;
using System.Data.SqlClient;
using System.Data;

namespace SAMTool.RepositoryServices.Services
{
    public class PrivilegesRepository: IPrivilegesRepository
    {
        private IDatabaseFactory _databaseFactory;
        public PrivilegesRepository(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        public object DeletePrivileges(Privileges userObj)
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
                        cmd.CommandText = "[DeletePrivileges]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = userObj.ID;
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

        public List<Privileges> GetAllPrivileges()
        {
            List<Privileges> PrivilegesList = null;
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
                        cmd.CommandText = "[GetAllPrivileges]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if ((sdr != null) && (sdr.HasRows))
                            {
                                PrivilegesList = new List<Privileges>();
                                while (sdr.Read())
                                {
                                    Privileges _PrivilObj = new Privileges();
                                    {
                                        _PrivilObj.ID = (sdr["ID"].ToString() != "" ? Guid.Parse(sdr["ID"].ToString()) : _PrivilObj.ID);
                                        _PrivilObj.AppID = (sdr["AppID"].ToString() != "" ? Guid.Parse(sdr["AppID"].ToString()) : _PrivilObj.AppID);
                                        _PrivilObj.RoleID = (sdr["RoleID"].ToString() != "" ? Guid.Parse(sdr["RoleID"].ToString()) : _PrivilObj.RoleID);
                                        _PrivilObj.ApplicationName = (sdr["ApplicationName"].ToString() != "" ? sdr["ApplicationName"].ToString() : _PrivilObj.ApplicationName);
                                        _PrivilObj.RoleName = (sdr["RoleName"].ToString() != "" ? sdr["RoleName"].ToString() : _PrivilObj.RoleName);
                                        _PrivilObj.AccessDescription = (sdr["AccessDescription"].ToString() != "" ? sdr["AccessDescription"].ToString() : _PrivilObj.AccessDescription);
                                        _PrivilObj.ModuleName = (sdr["ModuleName"].ToString() != "" ? sdr["ModuleName"].ToString() : _PrivilObj.ModuleName);
                                        _PrivilObj.commonDetails = new Common();
                                        _PrivilObj.commonDetails.CreatedDatestr = (sdr["CreatedDate"].ToString() != "" ? DateTime.Parse(sdr["CreatedDate"].ToString()).ToString("dd-MMM-yyyy") : _PrivilObj.commonDetails.CreatedDatestr);
                                        _PrivilObj.commonDetails.CreatedBy= (sdr["CreatedBy"].ToString() != "" ? sdr["CreatedBy"].ToString() : _PrivilObj.commonDetails.CreatedBy);
                                    }
                                    PrivilegesList.Add(_PrivilObj);
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

            return PrivilegesList;
        } 
        public object InsertPrivileges(Privileges PrivilegesObj)
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
                        cmd.CommandText = "[InsertPrivileges]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@AppID", SqlDbType.UniqueIdentifier).Value = PrivilegesObj.AppID;
                        cmd.Parameters.Add("@RoleID", SqlDbType.UniqueIdentifier).Value = PrivilegesObj.RoleID;
                        cmd.Parameters.Add("@ModuleName", SqlDbType.NVarChar, 250).Value = PrivilegesObj.ModuleName; 
                        cmd.Parameters.Add("@AccessDescription", SqlDbType.NVarChar, -1).Value = PrivilegesObj.AccessDescription;
                        cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar, 250).Value = PrivilegesObj.commonDetails.CreatedBy;
                        cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = PrivilegesObj.commonDetails.CreatedDate;

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
                default:
                    return new
                    {
                        Status = outParameter.Value.ToString(),
                        Message = "Insert Failure"
                    };
            }

        }

        public object UpdatePrivileges(Privileges PrivilegesObj)
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
                        cmd.CommandText = "[UpdatePrivileges]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = PrivilegesObj.ID;
                        cmd.Parameters.Add("@AppID", SqlDbType.UniqueIdentifier).Value = PrivilegesObj.AppID;
                        cmd.Parameters.Add("@RoleID", SqlDbType.UniqueIdentifier).Value = PrivilegesObj.RoleID;
                        cmd.Parameters.Add("@ModuleName", SqlDbType.NVarChar, 250).Value = PrivilegesObj.ModuleName;
                        cmd.Parameters.Add("@AccessDescription", SqlDbType.NVarChar, -1).Value = PrivilegesObj.AccessDescription;
                        cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar, 250).Value = PrivilegesObj.commonDetails.CreatedBy;
                        cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = PrivilegesObj.commonDetails.CreatedDate;

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