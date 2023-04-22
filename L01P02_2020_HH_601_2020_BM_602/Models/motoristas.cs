using System.ComponentModel.DataAnnotations;

namespace L01P02_2020_HH_601_2020_BM_602.Models
{
    public class motoristas
    {

        [Key]
        [Display(Name = "ID")]
        public int motoristas_id { get; set; }
        [Display(Name = "Nombre de motorista")]
        public String? nombre_motorista { get; set; }
        
    }
}
