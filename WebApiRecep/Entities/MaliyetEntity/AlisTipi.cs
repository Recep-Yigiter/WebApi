using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApiRecep.Entities.MaliyetEntity
{
    [Table("ALIS_TIPI", Schema = "MALIYET")]
    [Index(nameof(TipAdi), IsUnique = true)]
    public class AlisTipi : IEntity
    {
       

        [Key]
        public int Id { get; set; }

        [Required]
        [RegularExpression(@"^[^<>.,?;:'()!~%\-_@#/*]+$")]
        public string? TipAdi { get; set; }

        public string? SonDegisiklikYapan { get; set; }

    }
}
