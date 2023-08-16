using System.ComponentModel.DataAnnotations;

namespace Test_API.Models.Dto
{
    public class StudentDTO
    {
        public int Id { get; set; }
        [Required]
        public string Ime { get; set; }
        [Required]
        public string Prezime { get; set; }
        [Required]
        [MaxLength(10)]
        public string JMBAG { get; set; }
    }
}
