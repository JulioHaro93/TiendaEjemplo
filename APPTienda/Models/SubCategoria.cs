using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPTienda.Models
{
    
    public class SubCategoria
    {
        [Key]
        private uint? Id_SubCategoria { get; set; }
        private uint? SubCategoria_Num { get; set; }
        [ForeignKey("Categoria")]
        private uint? Id_Categoria { get; set; }
        
        [NotMapped]
        private Categoria? Categoria { get; set; }

        
        public SubCategoria() { }

        public SubCategoria (uint id_SubCategoria, uint subCategoria_Num, uint id_Categoria, Categoria categoria)
        {
            Id_SubCategoria = id_SubCategoria;
            SubCategoria_Num = subCategoria_Num;
            Id_Categoria = id_Categoria;
            Categoria = categoria;
        }
    }
}
