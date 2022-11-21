using System.Collections.Generic;

namespace Bilheteira
{
    public class TipoEvento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public ICollection<SubTipoEvento> SubTipoEventos { get; set; }
    }
}

