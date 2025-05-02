using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace pc_2.Models
{
    [Table("t_adopciones")]
    public class Adopciones
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int IdMascota { get; set; }
        [ForeignKey("MascotaId")]
        public Mascotas Mascota { get; set; }
        public int IdAdoptante { get; set; }
         [ForeignKey("AdoptanteId")]
        public Adoptantes Adoptante { get; set; }

    }
}