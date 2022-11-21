namespace Bilheteira
{
    public class Bilhete
    {
        public int Id { get; set; }
        public int Numero { get; set; }
        public Cliente Cliente { get; set; }
        public int ClienteId { get; set; }
        public Lugar Lugar { get; set; }
        public int LugarId { get; set; }

    }
}

