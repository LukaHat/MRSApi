using System.ComponentModel.DataAnnotations;

namespace Test_API.Models.Dto
{
    public class RazmjenaDTO
    {
        public int Id { get; set; }
        [Required]
        public int StudentId { get; set; }
        public string Drzava { get; set; }
        public string Sveuciliste { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }
    }
}
