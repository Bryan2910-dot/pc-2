using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pc_2.Models
{
    [Table("t_mascotas")]
    public class Mascotas
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Edad { get; set; }
        public string? Tipo { get; set; }
        [Required]
        public EstadoMascota Estado { get; set; } = EstadoMascota.Disponible; // Valor por defecto
    }

    public enum EstadoMascota
    {
        Disponible,
        Adoptada
    }
}
