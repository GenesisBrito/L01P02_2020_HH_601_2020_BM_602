using System.ComponentModel.DataAnnotations;

namespace L01P02_2020_HH_601_2020_BM_602.Models
{
    public class pedidos
    {
        [Key]
        [Display(Name = "ID")]
        public int pedido_id { get; set; }
        public int motorista_id{ get; set; }
        public int cliente_id { get; set; }
        public int plato_id { get; set; }
        public int cantidad { get; set; }   
        public int? precio { get; set; }
    }
}
