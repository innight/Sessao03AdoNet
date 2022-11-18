using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Correção do exercício");

            //EXERCÍCIO: Criar a relação entre as tabelas de Quartos, Tipologias e Reservas - ConsoleApp1
            //      1 Quarto tem 1 Tipologia
            //      1 Tipologia tem Muitos Quartos

            //      1 Reserva é reserva para 1 TipologiaDeQuarto
            //      1 Tipologia de Quarto poderá ter Muitas Reservas
        }
    }
    class MeuContexto : DbContext
    {
        public DbSet<Quarto> Quartos { get; set; }
        public DbSet<Tipologia> Tipologias { get; set; }
        public DbSet<Reserva> Reservas { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"SERVER=(localdb)\mssqllocaldb; DATABASE=Hotel2; TRUSTED_CONNECTION=TRUE;");

            base.OnConfiguring(optionsBuilder);
        }
    }

    public class Quarto
    {
        public int Id { get; set; }
        public int Piso { get; set; }
        public int Numero { get; set; }
        public int Area { get; set; }
        public bool AC { get; set; }
        public string Descricao { get; set; }
        //Implementação da realação com Tipologia: 1 Quarto tem 1 Tipologia
        public Tipologia Tipologia { get; set; }
        public int TipologiaId { get; set; } //FK - de facto criada na BD!!! Esta prop. não é obrigatória aqui em C# - mas é sempre criada a coluna na BD!
        //Nota: Se esta propriedade FK não tiver o nome NomeDaClasseModeloId mas sim IdNomeDaClasseModelo então teremos que usar a Data Annotation ForeignKey:
        //[ForeignKey("IdTipologia")]
        //public Tipologia Tipologia { get; set; }
        //public int IdTipologia { get; set; } //FK - de facto criada na BD!!!

    }
    public class Tipologia
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        //Implementação da realação com Quarto: 1 Tipologia tem Muitos Quartos
        public ICollection<Quarto> Quartos { get; set; }
        //Implementação da relação com Reserva: 1 Tipologia de Quarto poderá ter Muitas Reservas
        public ICollection<Reserva> Reservas { get; set; }
    }
    public class Reserva
    {
        public int Id { get; set; }
        public DateTime DataInicio { get; set; }
        public DateTime DataFim { get; set; }
        //Implementação da relação com Tipologia: 1 Reserva é reserva para 1 Tipologia de Quarto
        public Tipologia Tipologia { get; set; }
        public int TipologiaId { get; set; } //FK - de facto criada na BD!!! Esta prop. não é obrigatória aqui em C# - mas é sempre criada a coluna na BD!

    }
}
