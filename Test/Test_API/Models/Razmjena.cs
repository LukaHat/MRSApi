using System.ComponentModel.DataAnnotations.Schema;

namespace Test_API.Models
{
    public class Razmjena
    {
        public int Id { get; set; }
        [ForeignKey("Student")]
        public int StudentId { get; set; }
        public Student Student { get; set; }

        public string Drzava { get; set; }
        public string Sveuciliste { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }
    }
}
