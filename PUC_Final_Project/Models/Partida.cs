using System.ComponentModel.DataAnnotations;

namespace PUC_Final_Project.Models
{
    public class Partida
    {
        [Key]
        public int Id { get; set; }
        public Time TimeCasa { get; set; }
        public int TimeCasaId { get; set; }
        public Time TimeVisitante { get; set; }
        public int TimeVisitanteId { get; set; }
        public List<Evento> EventoOcorrido { get; set; }
    }
}
