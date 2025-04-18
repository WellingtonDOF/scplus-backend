namespace backend_sc.Profile
{
    using AutoMapper;
    using backend_sc.DTOs.PessoaDTO;
    using backend_sc.Mapping;
    using backend_sc.Models;

    public class ProfileAutoMapper : Profile
    {
        public ProfileAutoMapper()
        {
            CreateMap<PessoaModel, PessoaCreateDTO>()
                .ReverseMap()
                .ForMember(dest => dest.PermissaoId, opt => opt.ConvertUsing<TipoParaPermissaoIdConverter, string>(src => src.TipoUsuario));

            CreateMap<PessoaModel, PessoaResponseDTO>()
               .ForMember(dest => dest.TipoUsuario, opt => opt.MapFrom(src => src.Permissao.TipoPermissao.ToString()));
        }
    }
}
