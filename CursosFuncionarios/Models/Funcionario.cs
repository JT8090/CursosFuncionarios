using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace CursosFuncionarios.Models
{
    public class Funcionario
    {
        [Column("id_funcionario")]
        [Key]
        public int Id { get; set; }
        [Column("nome")]
        [DisplayName("Nome")]
        [Required]
        [MaxLength(60)]
        public string Nome { get; set; } = string.Empty;
        [Column("email")]
        [DisplayName("E-mail")]
        [Required]
        [MaxLength(200)]
        public string Email { get; set; } = string.Empty;
        public ICollection<FuncionarioCurso>? FuncionarioCursos { get; set; }
    }
}
