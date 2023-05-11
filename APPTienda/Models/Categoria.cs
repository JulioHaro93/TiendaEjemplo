using System.ComponentModel.DataAnnotations;

namespace APPTienda.Models
{
    public class Categoria
    {
        [Key]
        public uint Id_Categoria { get; set; }
        public uint Category_Num { get; set; }
        public string Ticket_Num { get; set; }

        [Required]
        [Display(Name = "Nombre de la Categoría")]
        public string Nombre { get; set; }

        List<SubCategoria> SubCategorias { get; set; }



        public Categoria () 
        {

        }

        public Categoria (uint id_Categoria, uint category_Num, string ticket_Num, string nombre)
        {
            this.Id_Categoria = id_Categoria;
            this.Category_Num = category_Num;
            this.Ticket_Num = ticket_Num;
            this.Nombre = nombre;
        }
    }
}
