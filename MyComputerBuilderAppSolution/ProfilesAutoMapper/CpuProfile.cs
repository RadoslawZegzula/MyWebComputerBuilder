
using AutoMapper;

namespace MyOnlineShop.ProfilesAutoMapper
{
    public class CpuProfile : Profile
    {
        public CpuProfile()
        {
            CreateMap<Models.Entities.CpuEntity, Models.ModelsToDisplay.Cpu>();
        }       
    }
}