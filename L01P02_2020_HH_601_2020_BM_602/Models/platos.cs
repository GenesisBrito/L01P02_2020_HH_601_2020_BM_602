using System.ComponentModel.DataAnnotations;

namespace L01P02_2020_HH_601_2020_BM_602.Models
{
    public class platos
    {
        [Key]
        [Display(Name = "ID")]
        public int plato_id { get; set; }
        [Display(Name = "id de plato")]
        public String? nombre_plato { get; set; }
        [Display(Name = "plato")]
        public int? precio { get; set; }
    }

}
