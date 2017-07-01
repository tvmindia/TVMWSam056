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
    public class RolesRepository: IRolesRepository
    {
        private IDatabaseFactory _databaseFactory;
        public RolesRepository(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        public object DeleteRoles(Roles RolesObj)
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
                        cmd.CommandText = "[DeleteRoles]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = RolesObj.ID;
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

        public List<Roles> GetAllAppRoles(Guid? id)
        { 
            List<Roles> rolesList = null;
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
                        cmd.CommandText = "[GetRoles]";
                        if(id!=null)
                        cmd.Parameters.Add("@AppID", SqlDbType.UniqueIdentifier).Value = id;
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if ((sdr != null) && (sdr.HasRows))
                            {
                                rolesList = new List<Roles>();
                                while (sdr.Read())
                                {
                                    Roles _rolesObj = new Roles();
                                    { 
                                        _rolesObj.ID = (sdr["ID"].ToString() != "" ? Guid.Parse(sdr["ID"].ToString()) : _rolesObj.ID);
                                        _rolesObj.AppID = (sdr["AppID"].ToString() != "" ? Guid.Parse(sdr["AppID"].ToString()) : _rolesObj.AppID);
                                        _rolesObj.RoleDescription = (sdr["RoleDescription"].ToString() != "" ? sdr["RoleDescription"].ToString() : _rolesObj.RoleDescription);
                                        _rolesObj.RoleName = (sdr["RoleName"].ToString() != "" ? sdr["RoleName"].ToString() : _rolesObj.RoleName);
                                        _rolesObj.ApplicationName = (sdr["ApplicationName"].ToString() != "" ? sdr["ApplicationName"].ToString() : _rolesObj.ApplicationName);
                                    }
                                    rolesList.Add(_rolesObj);
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

            return rolesList;
        } 

        public object InsertRoles(Roles RolesObj)
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
                        cmd.CommandText = "[InsertRoles]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@AppID", SqlDbType.UniqueIdentifier).Value = RolesObj.AppID;
                        cmd.Parameters.Add("@RoleName", SqlDbType.NVarChar, 250).Value = RolesObj.RoleName;
                        cmd.Parameters.Add("@RoleDescription", SqlDbType.NVarChar, 250).Value = RolesObj.RoleDescription; 
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
                        Message = "Duplicate login Name"
                    };
                default:
                    return new
                    {
                        Status = outParameter.Value.ToString(),
                        Message = "Insert Failure"
                    };
            }

        }

        public object UpdateRoles(Roles RolesObj)
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
                        cmd.CommandText = "[UpdateRoles]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = RolesObj.ID;
                        cmd.Parameters.Add("@AppID", SqlDbType.UniqueIdentifier).Value = RolesObj.AppID;
                        cmd.Parameters.Add("@RoleName", SqlDbType.NVarChar, 250).Value = RolesObj.RoleName;
                        cmd.Parameters.Add("@RoleDescription", SqlDbType.NVarChar, 250).Value = RolesObj.RoleDescription; 
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