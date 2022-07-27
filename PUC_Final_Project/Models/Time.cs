using System.ComponentModel.DataAnnotations;

namespace PUC_Final_Project.Models
{
    public class Time
    {
        [Key]
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Localidade { get; set; }

    }
}
