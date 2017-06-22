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

        public List<Roles> GetAllRoles()
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
                                        _rolesObj.RoleDescription = (sdr["RoleDescription"].ToString() != "" ? sdr["RoleDescription"].ToString() : _rolesObj.RoleDescription);
                                        _rolesObj.RoleName = (sdr["RoleName"].ToString() != "" ? sdr["RoleName"].ToString() : _rolesObj.RoleName);  
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
    }
}