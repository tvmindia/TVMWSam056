
using SAMTool.DataAccessObject.DTO;
using SAMTool.UI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace SAMTool.UI.App_Start
{
    public class MappingConfig
    {
        public static void RegisterMaps()
        {
            AutoMapper.Mapper.Initialize(config =>
            {
                //domain <===== viewmodel
                //viewmodel =====> domain
                //ReverseMap() makes it possible to map both ways.

                // config.CreateMap<TempVM, Temp>().ReverseMap();
                config.CreateMap<LoginViewModel, User>().ReverseMap();
                config.CreateMap<SysMenuViewModel, SysMenu>().ReverseMap();
                config.CreateMap<RolesViewModel, Roles>().ReverseMap();
                config.CreateMap<UserViewModel, User>().ReverseMap();
                config.CreateMap<ApplicationViewModel, Application>().ReverseMap();
                config.CreateMap<AppObjectViewModel, AppObject>().ReverseMap();
                config.CreateMap<CommonViewModel, Common>().ReverseMap();
                config.CreateMap<PrivilegesViewModel, Privileges>().ReverseMap();
                config.CreateMap<AppSubobjectViewmodel, AppSubobject>().ReverseMap();
                config.CreateMap<ManageAccessViewModel, ManageAccess>().ReverseMap();
                config.CreateMap<ManageSubObjectAccessViewModel, ManageSubObjectAccess>().ReverseMap();

            });
        }
    }
}