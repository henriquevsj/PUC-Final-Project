using System.ComponentModel.DataAnnotations;

namespace PUC_Final_Project.Models
{
    public class Transferencia
    {
        [Key]
        public int Id { get; set; }
        public Time TimeOrigem { get; set; }
        public int TimeOrigemId { get; set; }
        public Time TimeDestino { get; set; }
        public int TimeDestinoId { get; set; }
        public Jogador JogadorTransferido { get; set; }
        public int JogadorTransferidoId { get; set; }
        public DateTime Data { get; set; }
        public int Valor { get; set; }

    }
}
