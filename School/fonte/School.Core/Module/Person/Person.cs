using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace School.Core.Module.Person
{
    [Table("Person")]
    public class Person
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column("IdPerson", TypeName = "int")]
        public int Id { get; set; }

        [Required]
        [Display(Name = "Tipo", AutoGenerateFilter = false)]
        [Column("TypeId", TypeName = "int")]
        public int Type { get; set; }

        [Required]
        [MaxLength(75)]
        [Display(Name = "Nome", AutoGenerateFilter = false)]
        [Column("Name", TypeName = "varchar")]
        public string Name { get; set; }

        [MaxLength(150)]
        [Display(Name = "Razão Social", AutoGenerateFilter = false)]
        [Column("SocialName", TypeName = "varchar")]
        public string SocialName { get; set; }

        [Display(Name = "Gênero", AutoGenerateFilter = false)]
        [Column("Gender", TypeName = "int")]
        public int Gender { get; set; }

        //[DataType(DataType.Date)]
        [Display(Name = "Data Nascimento", AutoGenerateFilter = false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        [Column("BirthDate", TypeName = "date")]
        public DateTime? Birthdate { get; set; }

        [Required]
        [MaxLength(25)]
        [Display(Name = "CPF/CNPJ", AutoGenerateFilter = false)]
        [Column("Document1", TypeName = "varchar")]
        public string Document1 { get; set; }

        [MaxLength(25)]
        [Display(Name = "RG / Insc.Est.", AutoGenerateFilter = false)]
        [Column("Document2", TypeName = "varchar")]
        public string Document2 { get; set; }

        [MaxLength(25)]
        [Display(Name = "Insc.Municipal", AutoGenerateFilter = false)]
        [Column("Document3", TypeName = "varchar")]
        public string Document3 { get; set; }

        [MaxLength(75)]
        [Display(Name = "Nome da Mãe", AutoGenerateFilter = false)]
        [Column("MotherName", TypeName = "varchar")]
        public string MotherName { get; set; }

        [MaxLength(75)]
        [Display(Name = "Nome do Pai", AutoGenerateFilter = false)]
        [Column("FatherName", TypeName = "varchar")]
        public string FatherName { get; set; }

        [ForeignKey("AddressId")]
        public virtual Address Address { get; set; }

        [Required]
        [Column("AddressId", TypeName = "int")]
        public int AddressId { get; set; }

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

        public virtual List<Contact> Contacts { get; set; }

        public PersonType PersonType = new PersonType();

        public Person() { }
        
    }
}