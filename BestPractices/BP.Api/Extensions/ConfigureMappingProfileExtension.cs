using AutoMapper;
using BP.Api.Data.Models;
using BP.Models;
using System.Runtime.CompilerServices;

namespace BP.Api.Extensions
{
    public static class ConfigureMappingProfileExtension
    {
        public static IServiceCollection ConfigureMapping(this IServiceCollection service)
        {
            var mappingConfig = new MapperConfiguration(i => i.AddProfile(new AutoMappingProfile()));

            IMapper mapper = mappingConfig.CreateMapper();

            service.AddSingleton(mapper);

            return service;
        }
    }

    public class AutoMappingProfile : Profile
    {
        public AutoMappingProfile()
        {
            CreateMap<Contact, ContactDVO>()
                .ForMember(x=>x.FullName, y => y.MapFrom(z => $"{z.FirstName} {z.LastName}"))
                //.ForMember(x=>x.Id, y => y.MapFrom(z => z.Id))
                .ReverseMap();
        }
    }
}
