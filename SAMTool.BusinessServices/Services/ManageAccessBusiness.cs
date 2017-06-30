using SAMTool.BusinessServices.Contracts;
using SAMTool.DataAccessObject.DTO;
using SAMTool.RepositoryServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;

namespace SAMTool.BusinessServices.Services
{
    public class ManageAccessBusiness:IManageAccessBusiness
    {
        private IManageAccessRepository _manageAccessRepository;

        public ManageAccessBusiness(IManageAccessRepository manageAccessRepository)
        {
            _manageAccessRepository = manageAccessRepository;
        }
        public List<ManageAccess> GetAllObjectAccess(Guid AppID, Guid RoleID)
        {
            return _manageAccessRepository.GetAllObjectAccess(AppID, RoleID);
        }
        public List<ManageSubObjectAccess> GetAllSubObjectAccess(Guid ObjectID, Guid RoleID)
        {
            return _manageAccessRepository.GetAllSubObjectAccess(ObjectID, RoleID);
        }
        public ManageAccess AddAccessChanges(List<ManageAccess> ManageAccessList)
        {
            string result = "<Details>";
            int totalRows = 0;              

                foreach (object some_object in ManageAccessList)
                {
                    XML(some_object, ref result, ref totalRows);

                }
                result = result + "</Details>";
                foreach(ManageAccess ManageAccessObj in ManageAccessList)
                {
                ManageAccessObj.DetailXml = result;
                }
                return _manageAccessRepository.AddAccessChanges(ManageAccessList);
            }

        public ManageSubObjectAccess AddSubObjectAccessChanges(List<ManageSubObjectAccess> ManageSubObjectAccessList)
        {
            string result = "<Details>";
            int totalRows = 0;

            foreach (object some_object in ManageSubObjectAccessList)
            {
                XML(some_object, ref result, ref totalRows);

            }
            result = result + "</Details>";
            foreach (ManageSubObjectAccess ManageAccessObj in ManageSubObjectAccessList)
            {
                ManageAccessObj.DetailXml = result;
            }
            return _manageAccessRepository.AddSubObjectAccessChanges(ManageSubObjectAccessList);
        }
        private void XML(object some_object, ref string result, ref int totalRows)
        {

            var properties = GetProperties(some_object);


            result = result + "<item ";


            foreach (var p in properties)
            {
                string name = p.Name;
                var value = p.GetValue(some_object, null);
                result = result + " " + name + @"=""" + value + @""" ";

            }
            result = result + "></item>";
            totalRows = totalRows + 1;
        }
        private static PropertyInfo[] GetProperties(object obj)
        {
            return obj.GetType().GetProperties();
        }
    }
}