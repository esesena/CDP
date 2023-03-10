using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using CDP.Domain.Enums;
using CDP.Domain.Identity;

namespace CDP.Domain
{
    public class Employee
    {
        //[Key]
        public int Id { get; set; }

        //[Display(Name = "Nome")]
        //[StringLength(100, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres!")]
        //[Required(ErrorMessage = "Nome do funcionário é obrigatório!")]
        public string Name { get; set; }

        //[Display(Name = "CPF")]
        //[StringLength(11, ErrorMessage = "{0} deve ter {1} caracteres!")]
        //[Required(ErrorMessage = "{0} é obrigatório!")]
        //[DisplayFormat(DataFormatString = "{0:###.###.###-##}")]
        public string Cpf { get; set; }

        //[Display(Name = "Cargo")]
        public Function Function { get; set; }

        //[Display(Name = "Carga Horária")]
        //[Required(ErrorMessage = "{0} é obrigatório!")]
        public int Workload { get; set; }

        //[Display(Name = "Data de Nascimento")]
        //[Required(ErrorMessage = "{0} é obrigatório!")]
        //[DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        //[Display(Name = "Endereço")]
        //[StringLength(100, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres!")]
        //[Required(ErrorMessage = "{0} é obrigatório!")]
        public string Address { get; set; }

        //[Display(Name = "CEP")]
        //[StringLength(10, ErrorMessage = "{0} deve ter {1} caracteres!")]
        //[Required(ErrorMessage = "{0} é obrigatório!")]
        public string Cep { get; set; }

        //[Display(Name = "Cidade")]
        //[StringLength(100, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres!")]
        //[Required(ErrorMessage = "{0} é obrigatório!")]
        public string City { get; set; }

        //[Display(Name = "UF")]
        //[StringLength(2, MinimumLength = 2, ErrorMessage = "{0} deve conter {1} caracteres!")]
        //[Required(ErrorMessage = "{0} é obrigatório!")]
        public string State { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }
        public IEnumerable<EmployeesFarms> EmployeesFarms { get; set; }
    }
}