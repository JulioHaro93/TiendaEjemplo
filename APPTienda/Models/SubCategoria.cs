using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace APPTienda.Models
{
    
    public class SubCategoria
    {

        [Key]
        public uint Id_SubCategoria { get; set; }
        public uint? SubCategoria_Num { get; set; }

        //[RegularExpression(@"[0-9].[0-9].[0-9]", ErrorMessage = "Ingrese una ticket de producto correcto")]
        [ForeignKey("Categoria")]
        public uint? Id_Categoria { get; set; }
        
        [NotMapped]
        public Categoria? Categoria { get; set; }

        public string? Ticket_Num { get; set; }
        public string Ticket_NumSub { get; set; }

        public string Nombre { get; set; }
        

        public SubCategoria() { }

        public SubCategoria (uint id_SubCategoria, uint? subCategoria_Num, uint? id_Categoria, Categoria categoria, string ticket_Num, string ticket_NumSub, string nombre)
        {
            Id_SubCategoria = id_SubCategoria;
            SubCategoria_Num = subCategoria_Num;
            Id_Categoria = id_Categoria;
            Categoria = categoria;
            Ticket_Num = ticket_Num;
            Ticket_NumSub = ticket_NumSub;
            Nombre = nombre;
        }
    }
}
