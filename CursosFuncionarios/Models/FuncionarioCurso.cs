using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CursosFuncionarios.Models
{
    public enum AndamentoCurso
    {
        [Display(Name = "Inscrito")]
        Inscrito  = 1,
        Cursando  = 2,
        Cancelado = 3,
        Aprovado  = 4,
        Reprovado = 5
    }

    public class FuncionarioCurso
    {
        [Column("id_funcionario_curso")]
        [Key]
        public int Id { get; set; }
        [Column("id_funcionario")]
        public int IdFuncionario{ get; set; }
        [Column("id_curso_aplicacao")]
        public int IdCursoAplicacao { get; set; }
        [Column("observacao")]
        [MaxLength(200)]
        public string? Observacao { get; set; }
        [Column("nota")]
        public int? Nota { get; set; }
        public AndamentoCurso Andamento { get; set; } = AndamentoCurso.Inscrito;
    }
}
