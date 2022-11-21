using System;
using System.Collections.Generic;

namespace Bilheteira
{
    public class Evento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Detalhe { get; set; }
        public DateTime Duracao { get; set; }

        public SubTipoEvento SubTipoEvento { get; set; }
        public int SubTipoEventoId { get; set; }
        public ICollection<Sessao> Sessoes { get; set; }
    }
}