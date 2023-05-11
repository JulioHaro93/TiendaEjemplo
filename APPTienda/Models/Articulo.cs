using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPTienda.Models
{
    public class Articulo
    {
        [Key]
        private uint? Sku { get; set; }
        private uint? Atrticulo_Num { get; set; }
        private uint? Inventario { get; set; }
        private string? NumMaterial { get; set; }
        private string? NombreProdcuto { get; set; }
        private string? Categoria { get; set; }
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
