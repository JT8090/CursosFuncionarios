using System.ComponentModel;
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
        [DisplayName("Funcionário")]
        public int IdFuncionario{ get; set; }
        [Column("id_curso_aplicacao")]
        [DisplayName("Curso")]
        public int IdCursoAplicacao { get; set; }
        [Column("observacao")]
        [DisplayName("Observação")]
        [MaxLength(200)]
        public string? Observacao { get; set; }
        [Column("nota")]
        [DisplayName("Nota")]
        public int? Nota { get; set; }
        [Column("andamento")]
        [DisplayName("Situação")]
        public AndamentoCurso Andamento { get; set; } = AndamentoCurso.Inscrito;

        [ForeignKey("IdFuncionario")]
        public virtual Funcionario Funcionario { get; set; }
        [ForeignKey("IdCursoAplicacao")]
        public virtual CursoAplicacao CursoAplicacao { get; set; }
    }
}
