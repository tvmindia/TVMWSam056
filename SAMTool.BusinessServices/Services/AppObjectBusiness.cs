﻿using SAMTool.BusinessServices.Contracts;
using SAMTool.DataAccessObject.DTO;
using SAMTool.RepositoryServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SAMTool.BusinessServices.Services
{
    public class AppObjectBusiness:IAppObjectBusiness
    {
        private IAppObjectRepository _appObjectRepository;

        public AppObjectBusiness(IAppObjectRepository appObjectRepository)
        {
            _appObjectRepository = appObjectRepository;
        }
        public List<AppObject> GetAllAppObjects(Guid id)
        {
            return _appObjectRepository.GetAllAppObjects(id);
        }
        public AppObject InsertUpdate(AppObject AppObjectObj)
        {
            if(AppObjectObj.ID!=Guid.Empty)
            {
                return _appObjectRepository.UpdateObject(AppObjectObj);
            }
            else
            {
                return _appObjectRepository.InsertObject(AppObjectObj);
            }
        }
        public AppObject DeleteObject(AppObject AppObjectObj)
        {
            return _appObjectRepository.DeleteObject(AppObjectObj);
        }

    }
}