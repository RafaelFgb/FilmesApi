using AutoMapper;
using FilmesApi.Data.DTO_s;
using FilmesApi.Data.Dtos;
using FilmesApi.Models;

namespace FilmesApi.Profiles;

public class FilmeProfile : Profile
{
	public FilmeProfile()
	{
		CreateMap<CreateFilmeDTO, Filme>();
        CreateMap<UpdateFilmeDTO, Filme>();
        CreateMap<Filme, UpdateFilmeDTO>();
        CreateMap<Filme, ReadFilmeDTO>()
            .ForMember(filmeDTO => filmeDTO.Sessoes,
            opt => opt.MapFrom(filme => filme.Sessoes));
    }
}
