using AutoMapper;
using FilmesApi.Data.Dtos;
using FilmesAPI.Data.Dtos;
using FilmesAPI.Models;

namespace FilmesAPI.Profiles;

public class FilmeProfile : Profile
{
    public FilmeProfile()
    {
        CreateMap<CreateFilmeDto, Filme>();
        CreateMap<UpdateEnderecoDto, Filme>();
        CreateMap<Filme, UpdateEnderecoDto>();
        CreateMap<Filme, ReadFilmeDto>()
            .ForMember(filmeDto => filmeDto.Sessoes,
                opt => opt.MapFrom(filme => filme.Sessoes));
    }
}
