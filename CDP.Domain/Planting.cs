﻿using CDP.Domain.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CDP.Domain
{
    public class Planting
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Data do Plantio")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime PlantingDate { get; set; }

        [Display(Name = "Cultura")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public Cultivation Cultivation { get; set; }

        [Display(Name = "Safra")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres!")]
        public string Harvest { get; set; }

        [Display(Name = "Quantidade de Chuva")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal RainAmount { get; set; }

        [Display(Name = "Tipo de Plantio")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public TypePlanting TypePlanting { get; set; }

        [Display(Name = "Tempo durante o plantio")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres!")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public string WeatherPlanting{ get; set; }

        [Display(Name = "Umidade do Ar")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal AirMoisture { get; set; }

        [Display(Name = "Tipo de Semente")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        public int SeedId { get; set; }
        public virtual Seed Seed { get; set; }

        [Display(Name = "Quantidade de Sementes")]
        public decimal SeedAmount { get; set; }

        [Display(Name = "Distribuição de Sementes")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        [Column(TypeName = "decimal(10,2)")]
        public decimal SeetDistance { get; set; }

        [Display(Name = "Tipo de Abubação")]
        [Required(ErrorMessage = "{0} é obrigatório!")]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "{0} deve ter entre {2} e {1} caracteres!")]
        public string Fertilizing { get; set; }

        [Display(Name = "Talhões")]
        //public int TalhoesId { get; set; }
        public virtual ICollection<PlantingPlot> PlantingPlot { get; set; }

    }
}
