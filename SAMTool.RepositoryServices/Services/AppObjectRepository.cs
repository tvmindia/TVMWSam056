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
        public AppObject InsertObject(AppObject AppObjectObj)
        {
            try
            {
                SqlParameter outputStatus, outputID = null;
                using (SqlConnection con = _databaseFactory.GetDBConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        cmd.Connection = con;
                        cmd.CommandText = "[InsertObject]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@AppID", SqlDbType.UniqueIdentifier).Value = AppObjectObj.AppID;
                        cmd.Parameters.Add("@ObjectName", SqlDbType.NVarChar, 250).Value = AppObjectObj.ObjectName;
                        cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar, 250).Value = AppObjectObj.commonDetails.CreatedBy;
                        cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = AppObjectObj.commonDetails.CreatedDate;

                        outputStatus = cmd.Parameters.Add("@Status", SqlDbType.SmallInt);
                        outputStatus.Direction = ParameterDirection.Output;
                        outputID = cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier);
                        outputID.Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();


                    }
                }

                switch (outputStatus.Value.ToString())
                {
                    case "0":
                        Const Cobj = new Const();
                        throw new Exception(Cobj.InsertFailure);
                    case "1":
                        AppObjectObj.ID = new Guid(outputID.Value.ToString());

                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return AppObjectObj;
        }
        public AppObject UpdateObject(AppObject AppObjectObj)
        {
            try
            {
                SqlParameter outputStatus;
                using (SqlConnection con = _databaseFactory.GetDBConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        cmd.Connection = con;
                        cmd.CommandText = "[UpdateObject]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = AppObjectObj.ID;
                        cmd.Parameters.Add("@AppID", SqlDbType.UniqueIdentifier).Value = AppObjectObj.AppID;
                        cmd.Parameters.Add("@ObjectName", SqlDbType.NVarChar, 20).Value = AppObjectObj.ObjectName;
                        cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar, 250).Value = AppObjectObj.commonDetails.UpdatedBy;
                        cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = AppObjectObj.commonDetails.UpdatedDate;

                        outputStatus = cmd.Parameters.Add("@Status", SqlDbType.SmallInt);
                        outputStatus.Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();


                    }
                }

                switch (outputStatus.Value.ToString())
                {
                    case "0":
                        Const Cobj = new Const();
                        throw new Exception(Cobj.InsertFailure);
                    case "1":
                        //AppObjectObj.ID = new Guid(outputID.Value.ToString());

                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return AppObjectObj;
        }
        public AppObject DeleteObject(AppObject AppObjectObj)
        {
            try
            {
                SqlParameter outputStatus;
                using (SqlConnection con = _databaseFactory.GetDBConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        cmd.Connection = con;
                        cmd.CommandText = "[DeleteObject]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = AppObjectObj.ID;
                        cmd.Parameters.Add("@AppID", SqlDbType.UniqueIdentifier).Value = AppObjectObj.AppID;
                        outputStatus = cmd.Parameters.Add("@Status", SqlDbType.SmallInt);
                        outputStatus.Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                    }
                }

                switch (outputStatus.Value.ToString())
                {
                    case "0":
                        Const Cobj = new Const();
                        throw new Exception(Cobj.DeleteFailure);
                    case "1":
                        //AppObjectObj.ID = new Guid(outputID.Value.ToString());

                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return AppObjectObj;
        }

        public List<AppSubobject> GetAllAppSubObjects()
        {
            List<AppSubobject> appObjectList = null;
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
                        
                        cmd.CommandText = "[GetAllSubObjects]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if ((sdr != null) && (sdr.HasRows))
                            {
                                appObjectList = new List<AppSubobject>();
                                while (sdr.Read())
                                {
                                    AppSubobject _appObjectlistObj = new AppSubobject();
                                    {
                                        _appObjectlistObj.ID = (sdr["ID"].ToString() != "" ? Guid.Parse(sdr["ID"].ToString()) : _appObjectlistObj.ID);
                                        _appObjectlistObj.AppID = (sdr["AppID"].ToString() != "" ? Guid.Parse(sdr["AppID"].ToString()) : _appObjectlistObj.AppID);
                                        _appObjectlistObj.AppName = (sdr["AppName"].ToString() != "" ? (sdr["AppName"].ToString()) : _appObjectlistObj.AppName);
                                        _appObjectlistObj.ObjectID = (sdr["ObjectID"].ToString() != "" ? Guid.Parse(sdr["ObjectID"].ToString()) : _appObjectlistObj.ObjectID);
                                        _appObjectlistObj.ObjectName = (sdr["ObjectName"].ToString() != "" ? (sdr["ObjectName"].ToString()) : _appObjectlistObj.ObjectName);
                                        _appObjectlistObj.SubObjName = (sdr["SubObjName"].ToString() != "" ? (sdr["SubObjName"].ToString()) : _appObjectlistObj.SubObjName);
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

        public AppSubobject InsertSubObject(AppSubobject AppObjectObj)
        {
            try
            {
                SqlParameter outputStatus, outputID = null;
                using (SqlConnection con = _databaseFactory.GetDBConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        cmd.Connection = con;
                        cmd.CommandText = "[InsertSubObjects]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ObjectID", SqlDbType.UniqueIdentifier).Value = AppObjectObj.ObjectID;
                        cmd.Parameters.Add("@SubObjName", SqlDbType.NVarChar, 250).Value = AppObjectObj.SubObjName;
                        cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar, 250).Value = AppObjectObj.commonDetails.CreatedBy;
                        cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = AppObjectObj.commonDetails.CreatedDate;

                        outputStatus = cmd.Parameters.Add("@Status", SqlDbType.SmallInt);
                        outputStatus.Direction = ParameterDirection.Output;
                        outputID = cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier);
                        outputID.Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();


                    }
                }

                switch (outputStatus.Value.ToString())
                {
                    case "0":
                        Const Cobj = new Const();
                        throw new Exception(Cobj.InsertFailure);
                    case "1":
                        AppObjectObj.ID = new Guid(outputID.Value.ToString());

                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return AppObjectObj;

        }

        public AppSubobject UpdateSubObject(AppSubobject AppObjectObj)
        {
            try
            {
                SqlParameter outputStatus;
                using (SqlConnection con = _databaseFactory.GetDBConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        cmd.Connection = con;
                        cmd.CommandText = "[UpdateSubObjects]"; 
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = AppObjectObj.ID;
                        cmd.Parameters.Add("@ObjectID", SqlDbType.UniqueIdentifier).Value = AppObjectObj.ObjectID;
                        cmd.Parameters.Add("@SubObjName", SqlDbType.NVarChar, 250).Value = AppObjectObj.SubObjName;
                        cmd.Parameters.Add("@UpdatedBy", SqlDbType.NVarChar, 250).Value = AppObjectObj.commonDetails.UpdatedBy;
                        cmd.Parameters.Add("@UpdatedDate", SqlDbType.DateTime).Value = AppObjectObj.commonDetails.UpdatedDate;

                        outputStatus = cmd.Parameters.Add("@Status", SqlDbType.SmallInt);
                        outputStatus.Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                    }
                }

                switch (outputStatus.Value.ToString())
                {
                    case "0":
                        Const Cobj = new Const();
                        throw new Exception(Cobj.UpdateFailure);
                    case "1":
                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return AppObjectObj;
        }

        public AppSubobject DeleteSubObject(AppSubobject AppObjList)
        {
            try
            {
                SqlParameter outputStatus;
                using (SqlConnection con = _databaseFactory.GetDBConnection())
                {
                    using (SqlCommand cmd = new SqlCommand())
                    {
                        if (con.State == ConnectionState.Closed)
                        {
                            con.Open();
                        }
                        cmd.Connection = con;
                        cmd.CommandText = "[DeleteSubObject]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ID", SqlDbType.UniqueIdentifier).Value = AppObjList.ID; 
                        outputStatus = cmd.Parameters.Add("@Status", SqlDbType.SmallInt);
                        outputStatus.Direction = ParameterDirection.Output;
                        cmd.ExecuteNonQuery();
                    }
                }

                switch (outputStatus.Value.ToString())
                {
                    case "0":
                        Const Cobj = new Const();
                        throw new Exception(Cobj.DeleteFailure);
                    case "1":
                        //AppObjectObj.ID = new Guid(outputID.Value.ToString());

                        break;
                    default:
                        break;
                }

            }
            catch (Exception ex)
            {
                throw ex;
            }
            return AppObjList;
        }
    }
}