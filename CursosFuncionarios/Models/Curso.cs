using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CursosFuncionarios.Models
{
    public class Curso
    {
        [Column("id_curso")]
        [Key]
        public int Id { get; set; }
        [Column("nome")]
        [MaxLength(60)]
        [Required]
        public string Nome { get; set; } = string.Empty;
        [Column("descricao")]
        [DisplayName("Descrição")]
        [MaxLength(200)]
        public string? Descricao { get; set; }
        [Column("qtd_hora")]
        [DisplayName("Horas")]
        [Required]
        public int QtdHora { get; set; } = 0;

        public ICollection<CursoAplicacao>? CursoAplicacoes { get; set; }
    }
}
