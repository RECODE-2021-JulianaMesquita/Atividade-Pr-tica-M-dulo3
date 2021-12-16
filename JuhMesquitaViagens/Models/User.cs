using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JuhMesquitaViagens.Models
{
    [Table("User")]
    public class User
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Informe seu nome! ")]
        public string name { get; set; }
        [Required(ErrorMessage = "Informe seu CPF! ")]
        [StringLength(11)]
        public string CPF { get; set; }
        public string phone { get; set; }
        [Required(ErrorMessage = "Informe seu E-mail! ")]
        public string email { get; set; }
        [Required(ErrorMessage = "Informe sua senha : ")]
        public string password { get; set; }
        public bool administrator { get; set; }
        public ICollection<Package> package { get; set; }
    }
}
