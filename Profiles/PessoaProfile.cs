using api_pessoa.Data.Dtos;
using api_pessoa.Models;
using AutoMapper;

namespace api_pessoa.profiles;

public class pessoaprofile : Profile
{
    public pessoaprofile()
    {
        CreateMap<CreatePessoaDto, Pessoa>();
    }
}
