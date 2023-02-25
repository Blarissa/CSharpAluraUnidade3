using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesAPI.Data.Dtos.Sessao;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles
{
    public class SessaoProfile : Profile
    {
        public SessaoProfile()
        {
            CreateMap<Sessao, ReadSessaoDto>();
            CreateMap<CreateSessaoDto, Sessao>();
        }
    }
}
