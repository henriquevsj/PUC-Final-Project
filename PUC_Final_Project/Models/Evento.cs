using System.ComponentModel.DataAnnotations;

namespace PUC_Final_Project.Models
{
    public class Evento
    {
        [Key]
        public int Id { get; set; }
        public DateTime? Inicio { get; set; }
        public int? Gol { get; set; }
        public int? Intervalo { get; set; }
        public int? Acrescimo { get; set; }
        public int? Substituicao { get; set; }
        public int? Advertencia { get; set; }
        public DateTime? Fim { get; set; }
        public int PartidaId { get; set; }
        public Partida Partida { get; set; }

    }
}
