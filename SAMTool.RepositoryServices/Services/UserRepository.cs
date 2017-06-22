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
                                        _rolesObj.Email = (sdr["Email"].ToString() != "" ? sdr["Email"].ToString() : _rolesObj.UserName);
                                        //_rolesObj.RoleCSV= (sdr["Email"].ToString() != "" ? sdr["Email"].ToString() : _rolesObj.RoleCSV);
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
    }
}