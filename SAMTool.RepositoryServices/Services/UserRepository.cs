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
    public class UserRepository : IUserRepository
    { 
        private IDatabaseFactory _databaseFactory; 
        public UserRepository(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }

        public List<User> GetAllUsers()
        {
            List<User> UserList = null;
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
                        cmd.CommandText = "[GetUser]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if ((sdr != null) && (sdr.HasRows))
                            {
                                UserList = new List<User>();
                                while (sdr.Read())
                                {
                                    User _rolesObj = new User();
                                    {
                                        _rolesObj.ID = (sdr["ID"].ToString() != "" ? Guid.Parse(sdr["ID"].ToString()) : _rolesObj.ID);
                                        _rolesObj.LoginName = (sdr["LoginName"].ToString() != "" ? sdr["LoginName"].ToString() : _rolesObj.LoginName);
                                        _rolesObj.UserName = (sdr["UserName"].ToString() != "" ? sdr["UserName"].ToString() : _rolesObj.UserName);
                                        _rolesObj.Active = (sdr["Active"].ToString() != "" ? Boolean.Parse(sdr["Active"].ToString()) : _rolesObj.Active);
                                        _rolesObj.Email = (sdr["emailID"].ToString() != "" ? sdr["emailID"].ToString() : _rolesObj.UserName);
                                        _rolesObj.RoleCSV= (sdr["RoleList"].ToString() != "" ? sdr["RoleList"].ToString() : _rolesObj.RoleCSV);
                                        _rolesObj.RoleIDCSV = (sdr["RoleListID"].ToString() != "" ? sdr["RoleListID"].ToString() : _rolesObj.RoleIDCSV);
                                        _rolesObj.Password= (sdr["Password"].ToString() != "" ? sdr["Password"].ToString() : _rolesObj.Password);
                                    }
                                    UserList.Add(_rolesObj);
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

            return UserList;
        }

        public object InsertUser(User userObj)
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
                        cmd.CommandText = "[InsertUser]";
                        cmd.CommandType = CommandType.StoredProcedure;  
                        cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 250).Value = userObj.UserName;
                        cmd.Parameters.Add("@LoginName", SqlDbType.NVarChar, 250).Value = userObj.LoginName;
                        cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 250).Value = userObj.Password;
                        cmd.Parameters.Add("@Active", SqlDbType.Bit).Value = userObj.Active;
                        cmd.Parameters.Add("@RoleList", SqlDbType.NVarChar, -1).Value = userObj.RoleCSV;
                        cmd.Parameters.Add("@EmailID", SqlDbType.NVarChar, 250).Value = userObj.Email;
                        cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar, 250).Value = "Gibin"; //userObj.logDetails.CreatedBy;
                        cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = DateTime.Now;//userObj.logDetails.CreatedDate;

                        outParameter = cmd.Parameters.Add("@StatusOut", SqlDbType.Int);
                        outParameter.Direction = ParameterDirection.Output;
                        outParameter2 = cmd.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier);
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

        public object UpdateUser(User userObj)
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
                        cmd.CommandText = "[UpdateUser]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = userObj.ID;
                        cmd.Parameters.Add("@UserName", SqlDbType.NVarChar, 250).Value = userObj.UserName;
                        cmd.Parameters.Add("@LoginName", SqlDbType.NVarChar, 250).Value = userObj.LoginName;
                        cmd.Parameters.Add("@Password", SqlDbType.NVarChar, 250).Value = userObj.Password;
                        cmd.Parameters.Add("@Active", SqlDbType.Bit).Value = userObj.Active;
                        cmd.Parameters.Add("@RoleList", SqlDbType.NVarChar, -1).Value = userObj.RoleCSV;
                        cmd.Parameters.Add("@EmailID", SqlDbType.NVarChar, 250).Value = userObj.Email;
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

        public object DeleteUser(User userObj)
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
                        cmd.CommandText = "[DeleteUser]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@UserID", SqlDbType.UniqueIdentifier).Value = userObj.ID;  
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
    }
}