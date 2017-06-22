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
    public class AppObjectRepository:IAppObjectRepository
    {
        private IDatabaseFactory _databaseFactory;
        public AppObjectRepository(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        } 
        public List<AppObject> GetAllAppObjects(Guid id)
        {
            List<AppObject> appObjectList =null;
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
                        cmd.Parameters.Add("@AppID", SqlDbType.UniqueIdentifier).Value =id;
                        cmd.CommandText = "[GetAllObjectsOnApplication]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if ((sdr != null) && (sdr.HasRows))
                            {
                                appObjectList = new List<AppObject>();
                                while (sdr.Read())
                                {
                                    AppObject _appObjectlistObj = new AppObject();
                                    {
                                        _appObjectlistObj.ID = (sdr["ID"].ToString() != "" ? Guid.Parse(sdr["ID"].ToString()) : _appObjectlistObj.ID);
                                        _appObjectlistObj.AppID = (sdr["AppID"].ToString() != "" ? Guid.Parse(sdr["AppID"].ToString()) : _appObjectlistObj.AppID);
                                        _appObjectlistObj.ObjectName = (sdr["ObjectName"].ToString() != "" ? (sdr["ObjectName"].ToString()) : _appObjectlistObj.ObjectName);
                                        _appObjectlistObj.AppName = (sdr["AppName"].ToString() != "" ? (sdr["AppName"].ToString()) : _appObjectlistObj.AppName);
                                        _appObjectlistObj.commonDetails = new Common();
                                        _appObjectlistObj.commonDetails.CreatedDatestr = (sdr["CreatedDate"].ToString() != "" ? DateTime.Parse(sdr["CreatedDate"].ToString()).ToString("dd-MMM-yyyy") : _appObjectlistObj.commonDetails.CreatedDatestr);

                                    }

                                    appObjectList.Add(_appObjectlistObj);
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
            return appObjectList;
        }
    }
}