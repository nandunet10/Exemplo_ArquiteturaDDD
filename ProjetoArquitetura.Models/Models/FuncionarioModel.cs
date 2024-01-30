using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoArquitetura.Models.Models
{
    public class FuncionarioModel: EnderecoModel
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]

        [Required(ErrorMessage = "CPF é obrigatorio.")]
        [StringLength(14, MinimumLength = 14, ErrorMessage = "caracteres mínimos 14")]
        public string CPF { get; set; } = string.Empty;

        [Required(ErrorMessage = "RG é obrigatorio.")]
        [StringLength(30, MinimumLength = 5, ErrorMessage = "caracteres mínimo 5 máximo de 30")]
        public string RG { get; set; } = string.Empty;

        [Required(ErrorMessage = "Nome completo é obrigatorio.")]
        [StringLength(100, MinimumLength = 5, ErrorMessage = "caracteres mínimo 5 máximo de 100")]
        public string Nome { get; set; } = string.Empty;

        [Display(Name = "Data-Nascimento")]
        [Required(ErrorMessage = "Data de Nascimento é obrigatorio.")]
        public DateTime DataNascimento { get; set; }

        [StringLength(15, MinimumLength = 0, ErrorMessage = "caracteres mínimo 0 máximo de 15")]
        public string? Telefone { get; set; }
        [Required(ErrorMessage = "Celular é obrigatorio.")]
        [StringLength(15, MinimumLength = 15, ErrorMessage = "caracteres mínimo 15 máximo de 15")]
        public string Celular { get; set; } = string.Empty;

        [Display(Name = "Data-Inclusão")]
        [Required(ErrorMessage = "Data de Inclusão é obrigatoria.")]
        public DateTime DataInclusao { get; set; }

        [Display(Name = "Data-Alteração")]
        public DateTime? DataAlteracao { get; set; }
        public bool Ativo { get; set; } = true;
    }
}
