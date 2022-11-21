using System.Collections.Generic;

namespace Bilheteira
{
    public class SubTipoEvento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Descricao { get; set; }

        public TipoEvento TipoEvento { get; set; }
        public int TipoEventoId { get; set; }

        public ICollection<Evento> Eventos { get; set; }
    }
}

