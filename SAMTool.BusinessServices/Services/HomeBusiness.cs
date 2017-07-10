using SAMTool.DataAccessObject.DTO;
using SAMTool.BusinessServices.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SAMTool.RepositoryServices.Contracts;

namespace SAMTool.BusinessServices.Services
{
    public class HomeBusiness:IHomeBusiness
    {
        private IHomeRepository _homeRepository;

        public HomeBusiness(IHomeRepository homeRepository)
        {
            _homeRepository = homeRepository;
        }
        public List<SysMenu> GetAllSysLinks()
        {
            return _homeRepository.GetAllSysLinks();
        }

       
    }
}