using System.Collections.Generic;

namespace Bilheteira
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Morada { get; set; }
        public int Telefone { get; set; }
        public ICollection<Bilhete> Bilhetes { get; set; }
    }
}

