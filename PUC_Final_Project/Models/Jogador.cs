using System.ComponentModel.DataAnnotations;

namespace PUC_Final_Project.Models
{
    public class Jogador
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Pais { get; set; }
        public Time TimeDono { get; set; }
        public int TimeDonoId { get; set; }

    }
}
