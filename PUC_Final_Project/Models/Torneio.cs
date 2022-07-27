using System.ComponentModel.DataAnnotations;

namespace PUC_Final_Project.Models
{
    public class Torneio
    {
        [Key]
        public int Id { get; set; }
        public Time TimeParticipante { get; set; }
        public int TimeParticipanteId { get; set; }
        public Partida PartidaJogada { get; set; }
        public int PartidaJogadaId { get; set; }
    }
}
