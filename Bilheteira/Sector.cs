using System.Collections.Generic;

namespace Bilheteira
{
    public class Sector
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int QuantidadeLugares { get; set; }
        public bool Estado { get; set; }
        public double Preco { get; set; }
        public Sessao Sessao { get; set; }
        public int SessaoId { get; set; }
        public ICollection<Lugar> Lugares { get; set; }
    }
}

