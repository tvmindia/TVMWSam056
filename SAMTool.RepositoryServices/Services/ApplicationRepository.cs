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
    }
}