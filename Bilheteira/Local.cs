using System.Collections.Generic;

namespace Bilheteira
{
    public class Local
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Morada { get; set; }
        public string CodPostal { get; set; }
        public int Telefone { get; set; }
        public ICollection<Sessao> Sessoes { get; set; }
    }
}

