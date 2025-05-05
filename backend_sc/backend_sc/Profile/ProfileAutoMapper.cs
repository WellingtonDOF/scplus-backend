namespace backend_sc.Profile
{
    using AutoMapper;
    using backend_sc.Configurations;
    using backend_sc.DTOs.AlunoDTO;
    using backend_sc.DTOs.AulaDTO;
    using backend_sc.DTOs.InstrutorDTO;
    using backend_sc.DTOs.MatriculaDTO;
    using backend_sc.DTOs.PessoaDTO;
    using backend_sc.DTOs.VeiculoDTO;
    using backend_sc.Mapping;
    using backend_sc.Models;
    using System.Reflection;

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

            // ALUNO MAPEAMENTO
            CreateMap<AlunoCreateDTO, AlunoModel>()
                .ForMember(dest => dest.Senha, opt => opt.Ignore()) // Ignora a senha plain text
                .ForMember(dest => dest.PermissaoId, opt => opt.ConvertUsing<TipoParaPermissaoIdConverter, string>(src => src.TipoUsuario))
                // Mapeia outras propriedades específicas do aluno
                .ForMember(dest => dest.CategoriaCnh, opt => opt.MapFrom(src => src.CategoriaCnh));
           
            CreateMap<AlunoUpdateDTO, AlunoModel>()
                .ForMember(dest => dest.Senha, opt => opt.Ignore()) // Ignora a propriedade Senha na atualização
                .ReverseMap();

            CreateMap<AlunoModel, AlunoResponseDTO>()
                .ForMember(dest => dest.TipoUsuario, opt => opt.MapFrom(src => src.Permissao.TipoPermissao.ToString()))
                .ForMember(dest => dest.StatusCurso, opt => opt.MapFrom(src => src.StatusCurso ? "Ativo" : "Inativo"))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status? "Ativo" : "Inativo"));

            // INSTRUTOR MAPEAMENTO
            CreateMap<InstrutorCreateDTO, InstrutorModel>()
                .ForMember(dest => dest.Senha, opt => opt.Ignore()) // Ignora a senha plain text
                .ForMember(dest => dest.PermissaoId, opt => opt.ConvertUsing<TipoParaPermissaoIdConverter, string>(src => src.TipoUsuario))
                // Mapeia outras propriedades específicas do instrutor
                .ForMember(dest => dest.CategoriaCnh, opt => opt.MapFrom(src => src.CategoriaCnh));

            CreateMap<InstrutorUpdateDTO, InstrutorModel>()
                .ForMember(dest => dest.Senha, opt => opt.Ignore()) // Ignora a propriedade Senha na atualização
                .ReverseMap();

            CreateMap<InstrutorModel, InstrutorResponseDTO>()
                .ForMember(dest => dest.TipoUsuario, opt => opt.MapFrom(src => src.Permissao.TipoPermissao.ToString()))
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => src.Status? "Ativo" : "Inativo"));

            // AULA MAPEAMENTO
            CreateMap<AulaCreateDTO, AulaModel>();

            CreateMap<AulaUpdateDTO, AulaModel>()
                .ReverseMap();

            CreateMap<AulaModel, AulaResponseDTO>()
                .ForMember(dest => dest.TipoAula, opt => opt.MapFrom(src => src.TipoAula.GetDescription()));

            //VEICULO MAPEAMENTO
            CreateMap<VeiculoCreateDTO, VeiculoModel>();

            CreateMap<VeiculoUpdateDTO, VeiculoModel>()
                .ReverseMap();

            CreateMap<VeiculoModel, VeiculoResponseDTO>()
                .ForMember(dest => dest.StatusVeiculo, opt => opt.MapFrom(src => src.StatusVeiculo ? "Ativo" : "Inativo"));

            //MATRICULA MAPEAMENTO
            CreateMap<MatriculaCreateDTO, MatriculaModel>();

            CreateMap<MatriculaUpdateDTO, MatriculaModel>()
                .ReverseMap();

            CreateMap<MatriculaModel, MatriculaResponseDTO>()
                .ForMember(dest => dest.StatusMatricula, opt => opt.MapFrom(src => src.StatusMatricula ? "Ativo" : "Inativo"))
                .ForMember(dest => dest.AlunoCpf, opt => opt.MapFrom(src => src.Aluno.Cpf));

        }
    }
}
