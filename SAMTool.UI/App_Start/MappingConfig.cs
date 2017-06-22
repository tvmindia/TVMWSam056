
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
                config.CreateMap<HomeViewModel, Home>().ReverseMap();
                config.CreateMap<RolesViewModel, Roles>().ReverseMap();
                config.CreateMap<UserViewModel, User>().ReverseMap();
                config.CreateMap<ApplicationViewModel, Application>().ReverseMap();

            });
        }
    }
}