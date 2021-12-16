using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JuhMesquitaViagens.Models
{
    [Table("Package")]
    public class Package
    {
        [Key]
        public int id { get; set; }
        [Required(ErrorMessage = "Informe origem! ")]
        public string origin { get; set; }
        [Required(ErrorMessage = "Informe destino! ")]
        public Destiny destiny { get; set; }
        public User user { get; set; }
        public int kids { get; set; }
        public int adults { get; set; }
        public double payment { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Informe Data da Ida! ")]
        public DateTime dateGoing { get; set; }
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "Informe Data da Volta! ")]
        public DateTime dateReturn { get; set; }
    }
}
