using AutoMapper;
using VariacaoAtivos.Domain.Entity;
using VariacaoAtivos.Utility.DTOs;

namespace VariacaoAtivos.Application.Mapping
{
    public class EntityMapping : Profile
    {
        public EntityMapping() 
        {
            CreateMap<VariacaoAtivo, VariacaoAtivoDTO>().ReverseMap();
        }
    }
}
