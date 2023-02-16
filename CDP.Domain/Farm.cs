using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Xml.Linq;

namespace CDP.Domain
{
    public class Farm
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Nome")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres!")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public string Name { get; set; }

        [Display(Name = "Localização")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres!")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public string Location { get; set; }

        [Display(Name = "Área")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public double Size { get; set; }

        public IEnumerable<Plot> Plots { get; set; } = new List<Plot>();
    }
}