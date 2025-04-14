using backend_sc.Configurations;
using backend_sc.Models;
using Microsoft.EntityFrameworkCore;

namespace backend_sc.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<PessoaModel> Pessoas { get; set; }
        public DbSet<AlunoModel> Alunos { get; set; }
        public DbSet<InstrutorModel> Instrutores { get; set; }
        public DbSet<PermissaoModel> Permissoes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configura a estratégia TPT para a hierarquia de Pessoa (tabelas separadas)
            modelBuilder.Entity<PessoaModel>().UseTptMappingStrategy();
            modelBuilder.Entity<AlunoModel>().ToTable("Alunos");
            modelBuilder.Entity<InstrutorModel>().ToTable("Instrutores");


            //Configuração de Pessoa
            modelBuilder.ApplyConfiguration(new PessoaConfiguration());
        }
    }
}