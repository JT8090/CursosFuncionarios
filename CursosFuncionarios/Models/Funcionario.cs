using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CursosFuncionarios.Models
{
    public class Funcionario
    {
        [Column("id_funcionario")]
        [Key]
        public int Id { get; set; }
        [Column("nome")]
        [Required]
        [MaxLength(60)]
        public string Nome { get; set; } = string.Empty;
        [Column("email")]
        [Required]
        [MaxLength(200)]
        public string Email { get; set; }
        public ICollection<FuncionarioCurso>? FuncionarioCursos { get; set; }
    }
}
