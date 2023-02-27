using Alura.Filmes.App.Dados;
using Alura.Filmes.App.Extensions;
using Alura.Filmes.App.Negocio;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace Alura.Filmes.App
{
    public class Program
    {
        public static void Main(string[] args)
        {
            using (var contexto = new AluraFilmesContexto())
            {
                contexto.LogSQLToConsole();

                var atores = contexto.Atores
                    .OrderByDescending(a => EF.Property<DateTime>(a ,"last_update"))
                    .Take(10).ToList();

                var ator = new Ator();

                atores.ForEach(a => 
                    Console.WriteLine(a 
                        + " - " 
                        + contexto.Entry(ator)
                            .Property("last_update")
                            .CurrentValue));                                                
            }

            Console.ReadLine();
        }
    }
}