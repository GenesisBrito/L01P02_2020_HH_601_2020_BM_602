using System.ComponentModel.DataAnnotations;

namespace L01P02_2020_HH_601_2020_BM_602.Models
{
    public class clientes
    {
        [Key]
        [Display(Name = "ID")]
        public int clientes_id { get; set; }
        [Display(Name = "Nombre de cliente")]
        public String? nombre_cliente { get; set; }
        [Display(Name = "Id de cliente")]
        public string? direccion { get; set; }

    }
}
