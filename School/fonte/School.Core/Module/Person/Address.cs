using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Core.Module.Person
{
    [Table("Address")]
    public class Address
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdAddress", TypeName = "int")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tipo", AutoGenerateFilter = false)]
        [Column("TypeId", TypeName = "int")]
        public int Type { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Endereço", AutoGenerateFilter = false)]
        [Column("Name", TypeName = "varchar")]
        public string Name { get; set; }

        [Required]
        [MaxLength(6)]
        [Display(Name = "Número", AutoGenerateFilter = false)]
        [Column("Number", TypeName = "varchar")]
        public string Number { get; set; }

        [MaxLength(100)]
        [Display(Name = "Complemento", AutoGenerateFilter = false)]
        [Column("Complement", TypeName = "varchar")]
        public string Complement { get; set; }

        [Required]
        [MaxLength(100)]
        [Display(Name = "Bairro", AutoGenerateFilter = false)]
        [Column("District", TypeName = "varchar")]
        public string District { get; set; }

        [Required]
        [MaxLength(50)]
        [Display(Name = "Cidade", AutoGenerateFilter = false)]
        [Column("City", TypeName = "varchar")]
        public string City { get; set; }

        [Required]
        [MaxLength(2)]
        [Display(Name = "Estado", AutoGenerateFilter = false)]
        [Column("State", TypeName = "varchar")]
        public string State { get; set; }

        [Required]
        [MaxLength(10)]
        [Display(Name = "CEP", AutoGenerateFilter = false)]
        [Column("ZipCode", TypeName = "varchar")]
        public string ZipCode { get; set; }

        [Required]
        [Column("AddDate", TypeName = "datetime")]
        public DateTime AddDate { get; set; }

        [Required]
        [MaxLength(25)]
        [Column("AddUser", TypeName = "varchar")]
        public string AddUser { get; set; }

        [Column("UpdateDate", TypeName = "datetime")]
        public DateTime? EditDate { get; set; }

        [Column("UpdateUser", TypeName = "varchar")]
        public string EditUser { get; set; }

        public Address() { }

    }
}