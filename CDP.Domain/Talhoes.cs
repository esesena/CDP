using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDP.Domain
{
    [Table("Talhoes")]
    public class Talhoes
    {

        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres!")]
        [Required(ErrorMessage = "Nome é obrigatório!")]
        public string Nome { get; set; }

        [Display(Name = "Localização")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres!")]
        [Required(ErrorMessage = "Localização é obrigatório!")]
        public string Localizacao { get; set; }

        [Display(Name = "Área")]
        [Required(ErrorMessage = "Área é obrigatório!")]
        public double Area { get; set; }

        [Display(Name = "Tipo de Solo")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres!")]
        [Required(ErrorMessage = "Tipo de solo é obrigatório!")]
        public string TipoSolo { get; set; }

        [Display(Name = "Fazenda")]
        [Required(ErrorMessage = "Fazenda é obrigatório!")]
        public int FazendaId { get; set; }
        public virtual Fazenda Fazenda { get; set; }

        public virtual ICollection<PlantioTalhoes> PlantioTalhoes { get; set; }
    }
}