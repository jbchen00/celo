using AutoMapper;
using RandomUserApi.Data.Entities;
using RandomUserApi.Domain;

namespace RandomUserApi
{
    public class MapperConfiguration
    {
        public static void Init()
        {
            Mapper.Initialize(cfg
                =>
            {
                CreateTwoWayMap<User, UserEntity>(cfg);
                CreateTwoWayMap<ProfileImage, ProfileImageEntity>(cfg);
            });
        }

        private static void CreateTwoWayMap<TypeA, TypeB>(IMapperConfigurationExpression cfg)
        {
            cfg.CreateMap<TypeA, TypeB>();
            cfg.CreateMap<TypeB, TypeA>();
        }
        
        
    }
}