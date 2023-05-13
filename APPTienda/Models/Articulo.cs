using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPTienda.Models
{
    public class Articulo
    {
        [Key]
        public uint? Sku { get; set; }
        public uint? ArticuloNum { get; set; }
        public uint? Inventario { get; set; }
        public string? NumMaterial { get; set; }
        public string? NombreProducto { get; set; }
        [RegularExpression(@"[0-9].[0-9].[0-9].[0-9]")]
        public string? Categoria { get; set; }

        [ForeignKey("SubCategoria")]
        public uint?  Id_SubCategoria { get; set; }

        [NotMapped]
        public SubCategoria? SubCategoria { get; set; }

        public Articulo() { }
        public Articulo (uint sku, uint articuloNum, uint inventario, string numMaterial, string nombreProducto, string categoria, uint id_SubCategoria, SubCategoria subCategoria)
        {
            Sku = sku;
            ArticuloNum = articuloNum;
            Inventario = inventario;
            NumMaterial = numMaterial;
            NombreProducto = nombreProducto;
            Categoria = categoria;
            Id_SubCategoria = id_SubCategoria;
            SubCategoria = subCategoria;
        }
    }


}
