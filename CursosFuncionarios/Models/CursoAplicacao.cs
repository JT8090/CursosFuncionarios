using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CursosFuncionarios.Models
{
    public enum EstadoCurso
    {
        [Display(Name = "Previsto")]
        Previsto = 1, 
        Iniciado  = 2, 
        Encerrado = 3, 
        Cancelado = 4
    }

    public enum TipoCurso
    {
        Presencial = 1, 
        EAD = 2,
        [Display(Name = "Híbrido")]
        Hibrido = 3
    }

    public class CursoAplicacao
    {
        [Column("id_curso_aplicacao")] 
        [Key]
        public int Id { get; set; }
        [Column("id_curso")]
        [DisplayName("Curso")]
        public int IdCurso{ get; set; }
        [Column("dt_inico")]
        [DisplayName("Início")]
        public DateTime? DtInicio { get; set; }
        [Column("dt_fim")]
        [DisplayName("Término")]
        public DateTime? DtFim { get; set; }
        [DisplayName("Estado")]
        [Column("estado")]             
        public EstadoCurso Estado { get; set; } = EstadoCurso.Previsto;
        [Column("tipo")]
        [DisplayName("Tipo")]
        public TipoCurso Tipo { get; set; } = TipoCurso.EAD;

        public ICollection<FuncionarioCurso>? FuncionarioCursos { get; set; }
        public Curso Curso { get; set; }
    }
}
