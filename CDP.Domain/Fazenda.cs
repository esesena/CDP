using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CDP.Domain
{
    [Table("Fazenda")]
    public class Fazenda
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres!")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public string Nome { get; set; }

        [Display(Name = "Localização")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres!")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public string Localizacao { get; set; }

        [Display(Name = "Área")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public double Area { get; set; }

        public ICollection<Talhoes> Talhoes { get; set; } = new List<Talhoes>();
    }
}