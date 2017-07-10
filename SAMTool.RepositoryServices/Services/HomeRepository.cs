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
    public class HomeRepository:IHomeRepository
    {
        private IDatabaseFactory _databaseFactory;
        public HomeRepository(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }
        public List<SysMenu> GetAllSysLinks()
        {
            List<SysMenu> Linklist = null;
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
                        cmd.CommandText = "[GetAllHomeLinks]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if ((sdr != null) && (sdr.HasRows))
                            {
                                Linklist = new List<SysMenu>();
                                while (sdr.Read())
                                {
                                    SysMenu _SysMenuObj = new SysMenu();
                                    {
                                        _SysMenuObj.ID = (sdr["ID"].ToString() != "" ? Guid.Parse(sdr["ID"].ToString()) : _SysMenuObj.ID);
                                        _SysMenuObj.LinkName = (sdr["LinkName"].ToString() != "" ? (sdr["LinkName"].ToString()) : _SysMenuObj.LinkName);
                                        _SysMenuObj.LinkDescription = (sdr["LinkDescription"].ToString() != "" ? (sdr["LinkDescription"].ToString()) : _SysMenuObj.LinkDescription);
                                        _SysMenuObj.Controller = (sdr["Controller"].ToString() != "" ? sdr["Controller"].ToString() : _SysMenuObj.Controller);
                                        _SysMenuObj.Action = (sdr["Action"].ToString() != "" ? sdr["Action"].ToString() : _SysMenuObj.Action);
                                        _SysMenuObj.Order = (sdr["Order"].ToString() != "" ? int.Parse(sdr["Order"].ToString()) : _SysMenuObj.Order);
                                        _SysMenuObj.Type= (sdr["Type"].ToString() != "" ? sdr["Type"].ToString() : _SysMenuObj.Type);
                                    }
                                    Linklist.Add(_SysMenuObj);
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
            return Linklist;
        }
    }
}