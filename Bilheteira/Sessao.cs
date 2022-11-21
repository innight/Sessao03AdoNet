using System;
using System.Collections.Generic;

namespace Bilheteira
{
    public class Sessao
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Detalhe { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        public DateTime HoraInicio { get; set; }
        public bool Estado { get; set; }
        public Evento Evento { get; set; }
        public int EventoId { get; set; }
        public Local Local { get; set; }
        public int LocalId { get; set; }
        public ICollection<Sector> Sectores { get; set; }
    }
}

