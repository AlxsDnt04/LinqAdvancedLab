using LinqAdvancedLab.Data.Context;
using LinqAdvancedLab.Domain.DTOs;
using LinqAdvancedLab.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.IO;
using System.Linq;

namespace LinqAdvancedLab.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // 1. Configuración de inicio (Leer appsettings.json)
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);
            IConfiguration config = builder.Build();

            // 2. Configurar opciones del DbContext (Conexión a SQL)
            var connectionString = config.GetConnectionString("NorthwindConnection");
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseSqlServer(connectionString);

            // 3. Menú Interactivo
            using (var context = new AppDbContext(optionsBuilder.Options))
            {
                bool exit = false;
                while (!exit)
                {
                    Console.Clear();
                    Console.WriteLine("========================================");
                    Console.WriteLine("   LINQ ADVANCED LAB - NORTHWIND   ");
                    Console.WriteLine("========================================");
                    Console.WriteLine("1. Verificar Conexión (Test Básico)");
                    Console.WriteLine("2. HU1: Productos Críticos (Query 1)");
                    Console.WriteLine("3. Salir");
                    Console.Write("\nSelecciona una opción: ");

                    switch (Console.ReadLine())
                    {
                        case "1":
                            VerificarConexion(context);
                            break;
                        case "2":
                            Console.WriteLine("Aquí iría la lógica de Galo/Jorge...");
                            break;
                        case "3":
                            exit = true;
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }

                    if (!exit)
                    {
                        Console.WriteLine("\nPresiona ENTER para volver al menú...");
                        Console.ReadLine();
                    }
                }
            }
        }

        static void VerificarConexion(AppDbContext context)
        {
            try
            {
                Console.WriteLine("Conectando a la base de datos...");
                // Intentamos traer el primer producto solo para ver si funciona
                var productCount = context.Products.Count();
                Console.WriteLine($"¡ÉXITO! Conexión establecida.");
                Console.WriteLine($"Hay {productCount} productos en la base de datos Northwind.");
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"ERROR FATAL: No se pudo conectar.");
                Console.WriteLine(ex.Message);
                Console.ResetColor();
            }
        }
    }
}