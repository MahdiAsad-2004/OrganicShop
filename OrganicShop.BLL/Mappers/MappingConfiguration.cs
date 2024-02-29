using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrganicShop.BLL.Mappers
{
    public static class MappingConfiguration
    {
        public static MapperConfiguration GetConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.ValueTransformers.Add<string>(a => a.Trim());
                cfg.AddMaps(typeof(UserProfile).Assembly);
            });
        }



    }


    
}


