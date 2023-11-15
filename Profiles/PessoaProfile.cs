using api_pessoa.Data.Dtos;
using api_pessoa.Models;
using AutoMapper;

namespace api_pessoa.profiles;

public class PessoaProfile : Profile
{
    public PessoaProfile()
    {
        CreateMap<CreatePessoaDto, Pessoa>();
    }
}
