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
        public List<Home> GetAllSysLinks()
        {
            List<Home> Linklist = null;
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
                                Linklist = new List<Home>();
                                while (sdr.Read())
                                {
                                    Home _HomeObj = new Home();
                                    {
                                        _HomeObj.ID = (sdr["ID"].ToString() != "" ? Guid.Parse(sdr["ID"].ToString()) : _HomeObj.ID);
                                        _HomeObj.LinkName = (sdr["LinkName"].ToString() != "" ? (sdr["LinkName"].ToString()) : _HomeObj.LinkName);
                                        _HomeObj.LinkDescription = (sdr["LinkDescription"].ToString() != "" ? (sdr["LinkDescription"].ToString()) : _HomeObj.LinkDescription);
                                        _HomeObj.Controller = (sdr["Controller"].ToString() != "" ? sdr["Controller"].ToString() : _HomeObj.Controller);
                                        _HomeObj.Action = (sdr["Action"].ToString() != "" ? sdr["Action"].ToString() : _HomeObj.Action);
                                        _HomeObj.Order = (sdr["Order"].ToString() != "" ? int.Parse(sdr["Order"].ToString()) : _HomeObj.Order);
                                        _HomeObj.Type= (sdr["Type"].ToString() != "" ? sdr["Type"].ToString() : _HomeObj.Type);
                                    }
                                    Linklist.Add(_HomeObj);
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