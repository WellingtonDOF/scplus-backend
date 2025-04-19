namespace backend_sc.Profile
{
    using AutoMapper;
    using backend_sc.DTOs.AlunoDTO;
    using backend_sc.DTOs.PessoaDTO;
    using backend_sc.Mapping;
    using backend_sc.Models;

    public class ProfileAutoMapper : Profile
    {
        public ProfileAutoMapper()
        {
            //Mapper Pessoa
            CreateMap<PessoaModel, PessoaCreateDTO>()
                .ReverseMap()
                .ForMember(dest => dest.PermissaoId, opt => opt.ConvertUsing<TipoParaPermissaoIdConverter, string>(src => src.TipoUsuario));

            CreateMap<PessoaModel, PessoaResponseDTO>()
                .ForMember(dest => dest.TipoUsuario, opt => opt.MapFrom(src => src.Permissao.TipoPermissao.ToString()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status ? "Ativo" : "Inativo"));


            //Mapper Aluno
            CreateMap<AlunoModel, AlunoCreateDTO>();

            CreateMap<AlunoModel, AlunoResponseDTO>()
                .ForMember(dest => dest.TipoUsuario, opt => opt.MapFrom(src => src.Permissao.TipoPermissao.ToString()))
                .ForMember(dest => dest.StatusCurso, opt => opt.MapFrom(src => src.StatusCurso ? "Ativo" : "Inativo")); 
        }
    }
}
