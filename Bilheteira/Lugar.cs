using System.Collections.Generic;

namespace Bilheteira
{
    public class Lugar
    {
        public int Id { get; set; }
        public string Fila { get; set; }
        public int Numero { get; set; }
        public bool Estado { get; set; }
        public Sector Sector { get; set; }
        public int SectorId { get; set; }
        public Bilhete Bilhete { get; set; }
    }
}

