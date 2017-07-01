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
    public class ManageAccessRepository: IManageAccessRepository
    {
        private IDatabaseFactory _databaseFactory;
        public ManageAccessRepository(IDatabaseFactory databaseFactory)
        {
            _databaseFactory = databaseFactory;
        }
        public List<ManageAccess> GetAllObjectAccess(Guid AppID, Guid RoleID)
        {
            List<ManageAccess> manageAccessList = null;
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
                        cmd.Parameters.Add("@AppID", SqlDbType.UniqueIdentifier).Value = AppID;
                        cmd.Parameters.Add("@RoleID", SqlDbType.UniqueIdentifier).Value = RoleID;
                        cmd.CommandText = "[GetAllObjectAccess]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if ((sdr != null) && (sdr.HasRows))
                            {
                                manageAccessList = new List<ManageAccess>();
                                while (sdr.Read())
                                {
                                    ManageAccess _manageAccesslistObj = new ManageAccess();
                                    {
                                        _manageAccesslistObj.ID = (sdr["ID"].ToString() != "" ? Guid.Parse(sdr["ID"].ToString()) : _manageAccesslistObj.ID);
                                        _manageAccesslistObj.ObjectID= (sdr["ObjectID"].ToString() != "" ? Guid.Parse(sdr["ObjectID"].ToString()) : _manageAccesslistObj.ObjectID);
                                        _manageAccesslistObj.AppObjectObj = new AppObject();
                                        _manageAccesslistObj.AppObjectObj.AppID = (sdr["AppID"].ToString() != "" ? Guid.Parse(sdr["AppID"].ToString()) : _manageAccesslistObj.AppObjectObj.AppID);
                                        _manageAccesslistObj.AppObjectObj.ObjectName = (sdr["ObjectName"].ToString() != "" ? (sdr["ObjectName"].ToString()) : _manageAccesslistObj.AppObjectObj.ObjectName);
                                        _manageAccesslistObj.AppObjectObj.AppName = (sdr["AppName"].ToString() != "" ? (sdr["AppName"].ToString()) : _manageAccesslistObj.AppObjectObj.AppName);
                                        _manageAccesslistObj.RoleID = (sdr["RoleID"].ToString() != "" ? Guid.Parse(sdr["RoleID"].ToString()) : _manageAccesslistObj.RoleID);
                                        _manageAccesslistObj.Read= (sdr["R"].ToString() != "" ? bool.Parse(sdr["R"].ToString()) : _manageAccesslistObj.Read);
                                        _manageAccesslistObj.Write = (sdr["W"].ToString() != "" ? bool.Parse(sdr["W"].ToString()) : _manageAccesslistObj.Write);
                                        _manageAccesslistObj.Delete = (sdr["D"].ToString() != "" ? bool.Parse(sdr["D"].ToString()) : _manageAccesslistObj.Delete);
                                    }

                                    manageAccessList.Add(_manageAccesslistObj);
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
            return manageAccessList;
        }
        public List<ManageSubObjectAccess> GetAllSubObjectAccess(Guid ObjectID, Guid RoleID)
        {
            List<ManageSubObjectAccess> manageSubObjectAccessList = null;
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
                        cmd.Parameters.Add("@ObjectID", SqlDbType.UniqueIdentifier).Value = ObjectID;
                        cmd.Parameters.Add("@RoleID", SqlDbType.UniqueIdentifier).Value = RoleID;
                        cmd.CommandText = "[GetAllSubObjectAccess]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader sdr = cmd.ExecuteReader())
                        {
                            if ((sdr != null) && (sdr.HasRows))
                            {
                                manageSubObjectAccessList = new List<ManageSubObjectAccess>();
                                while (sdr.Read())
                                {
                                    ManageSubObjectAccess _manageSubObjectAccesslistObj = new ManageSubObjectAccess();
                                    {
                                        _manageSubObjectAccesslistObj.ID = (sdr["ID"].ToString() != "" ? Guid.Parse(sdr["ID"].ToString()) : _manageSubObjectAccesslistObj.ID);
                                        _manageSubObjectAccesslistObj.SubObjectID = (sdr["SubObjectID"].ToString() != "" ? Guid.Parse(sdr["SubObjectID"].ToString()) : _manageSubObjectAccesslistObj.SubObjectID);
                                        _manageSubObjectAccesslistObj.AppSubObjectObj = new AppSubobject();
                                        _manageSubObjectAccesslistObj.AppSubObjectObj.ObjectID = (sdr["ObjectID"].ToString() != "" ? Guid.Parse(sdr["ObjectID"].ToString()) : _manageSubObjectAccesslistObj.AppSubObjectObj.ObjectID);
                                        _manageSubObjectAccesslistObj.AppSubObjectObj.SubObjName = (sdr["SubObjName"].ToString() != "" ? (sdr["SubObjName"].ToString()) : _manageSubObjectAccesslistObj.AppSubObjectObj.SubObjName);
                                        _manageSubObjectAccesslistObj.AppObjectObj = new AppObject();
                                        _manageSubObjectAccesslistObj.AppObjectObj.AppID = (sdr["AppID"].ToString() != "" ? Guid.Parse(sdr["AppID"].ToString()) : _manageSubObjectAccesslistObj.AppObjectObj.AppID);
                                        _manageSubObjectAccesslistObj.AppObjectObj.ObjectName = (sdr["ObjectName"].ToString() != "" ? (sdr["ObjectName"].ToString()) : _manageSubObjectAccesslistObj.AppObjectObj.ObjectName);
                                        _manageSubObjectAccesslistObj.AppObjectObj.AppName = (sdr["AppName"].ToString() != "" ? (sdr["AppName"].ToString()) : _manageSubObjectAccesslistObj.AppObjectObj.AppName);
                                        _manageSubObjectAccesslistObj.RoleID = (sdr["RoleID"].ToString() != "" ? Guid.Parse(sdr["RoleID"].ToString()) : _manageSubObjectAccesslistObj.RoleID);
                                        _manageSubObjectAccesslistObj.Read = (sdr["R"].ToString() != "" ? bool.Parse(sdr["R"].ToString()) : _manageSubObjectAccesslistObj.Read);
                                        _manageSubObjectAccesslistObj.Write = (sdr["W"].ToString() != "" ? bool.Parse(sdr["W"].ToString()) : _manageSubObjectAccesslistObj.Write);
                                    }

                                    manageSubObjectAccessList.Add(_manageSubObjectAccesslistObj);
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
            return manageSubObjectAccessList;
        }
        public ManageAccess AddAccessChanges(List<ManageAccess> ManageAccessList)
        {
            ManageAccess ManageAccessObj = new ManageAccess();
            ManageAccessObj = ManageAccessList[0];
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
                        cmd.CommandText = "[AddObjectAccess]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@AppID", SqlDbType.UniqueIdentifier).Value = ManageAccessObj.AppObjectObj.AppID;
                        cmd.Parameters.Add("@RoleID", SqlDbType.UniqueIdentifier).Value = ManageAccessObj.RoleID;
                        cmd.Parameters.Add("@DetailXml", SqlDbType.NVarChar,-1).Value = ManageAccessObj.DetailXml;
                        cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar, 250).Value = ManageAccessObj.commonObj.CreatedBy;
                        cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = ManageAccessObj.commonObj.CreatedDate;
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
           return ManageAccessObj;
        }
        public ManageSubObjectAccess AddSubObjectAccessChanges(List<ManageSubObjectAccess> ManageSubObjectAccessList)
        {
            ManageSubObjectAccess ManageAccessObj = new ManageSubObjectAccess();
            ManageAccessObj = ManageSubObjectAccessList[0];
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
                        cmd.CommandText = "[AddSubObjectAccess]";
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.Parameters.Add("@ObjectID", SqlDbType.UniqueIdentifier).Value = ManageAccessObj.AppSubObjectObj.ObjectID;
                        cmd.Parameters.Add("@RoleID", SqlDbType.UniqueIdentifier).Value = ManageAccessObj.RoleID;
                        cmd.Parameters.Add("@DetailXml", SqlDbType.NVarChar, -1).Value = ManageAccessObj.DetailXml;
                        cmd.Parameters.Add("@CreatedBy", SqlDbType.NVarChar, 250).Value = ManageAccessObj.commonObj.CreatedBy;
                        cmd.Parameters.Add("@CreatedDate", SqlDbType.DateTime).Value = ManageAccessObj.commonObj.CreatedDate;
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
            return ManageAccessObj;
        }
    }
}