using AutoMapper;
using IOT.Models.Entity;
using IOT.ViewModels.Dto;
using System.Collections.Generic;

namespace IOT.ViewModels.AutoMapper
{
    public class AutoMapping : Profile
    {
        public AutoMapping()
        {
            CreateMap<Common, CommonDto>();

            // Model mapping
            CreateMap<Model, ModelDto>();
            CreateMap<ModelDto, Model>();
            CreateMap<IEnumerable<ModelDto>, IEnumerable<Model>>();
        }
    }
}
