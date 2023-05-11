using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPTienda.Models
{
    public class Articulo
    {
        [Key]
        public uint? Sku { get; set; }
        public uint? Atrticulo_Num { get; set; }
        public uint? Inventario { get; set; }
        public string? NumMaterial { get; set; }
        public string? NombreProdcuto { get; set; }
        [RegularExpression(@"[0-9].[0-9].[0-9].[0-9]")]
        public string? Categoria { get; set; }

        [ForeignKey("SubCategoria")]
        private uint?  Id_Subcategoria { get; set; }

        [NotMapped]
        private SubCategoria? SubCategoria { get; set; }

        public Articulo() { }
        public Articulo (uint sku, uint atrticulo_Num, uint inventario, string numMaterial, string nombreProdcuto, string categoria, uint id_Subcategoria, SubCategoria subCategoria)
        {
            Sku = sku;
            Atrticulo_Num = atrticulo_Num;
            Inventario = inventario;
            NumMaterial = numMaterial;
            NombreProdcuto = nombreProdcuto;
            Categoria = categoria;
            Id_Subcategoria = id_Subcategoria;
            SubCategoria = subCategoria;
        }
    }


}
