using SAMTool.DataAccessObject.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAMTool.BusinessServices.Contracts
{
    public interface IAppObjectBusiness
    {
        List<AppObject> GetAllAppObjects(Guid id);
        AppObject InsertUpdate(AppObject AppObjList);
        AppObject DeleteObject(AppObject AppObjList);

        List<AppSubobject> GetAllAppSubObjects(string ID);
        AppSubobject DeleteSubObject(AppSubobject AppObjList);
        AppSubobject InsertUpdateSubObject(AppSubobject AppObjList);
    }
}