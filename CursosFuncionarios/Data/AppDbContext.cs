using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace CursosFuncionarios.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Models.Curso> Curso { get; set; } = default!;
        public DbSet<Models.Funcionario> Funcionario { get; set; }
        public DbSet<Models.CursoAplicacao> CursoAplicacao { get; set; }
        public DbSet<Models.FuncionarioCurso> FuncionarioCurso { get; set; }

    }
}