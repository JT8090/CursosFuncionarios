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
        public int IdCurso{ get; set; }
        [Column("dt_inico")]           
        public DateTime? DtInicio { get; set; }
        [Column("dt_fim")]             
        public DateTime? DtFim { get; set; }
        [Column("estado")]             
        public EstadoCurso Estado { get; set; } = EstadoCurso.Previsto;
        [Column("tipo")]               
        public TipoCurso Tipo { get; set; } = TipoCurso.EAD;

        public ICollection<FuncionarioCurso>? FuncionarioCursos { get; set; }
    }
}
