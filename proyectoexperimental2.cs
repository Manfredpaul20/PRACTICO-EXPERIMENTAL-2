using System;
using System.Collections.Generic;

namespace AsignacionAsientosParque
{
    // Clase Persona
    public class Persona
    {
        public int Id { get; set; }
        public string Nombre { get; set; }

        public Persona(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
        }

        public override string ToString()
        {
            return $"ID: {Id} - Nombre: {Nombre}";
        }
    }

    // Clase Atraccion
    public class Atraccion
    {
        private Queue<Persona> colaPersonas;
        private int capacidadMaxima;
        private int contadorId;

        public Atraccion(int capacidad)
        {
            capacidadMaxima = capacidad;
            colaPersonas = new Queue<Persona>();
            contadorId = 1;
        }

        public void AgregarPersona(string nombre)
        {
            if (colaPersonas.Count < capacidadMaxima)
            {
                Persona persona = new Persona(contadorId, nombre);
                colaPersonas.Enqueue(persona);
                contadorId++;
                Console.WriteLine("✅ Persona agregada a la cola correctamente.");
            }
            else
            {
                Console.WriteLine("❌ No se pueden agregar más personas. Asientos agotados.");
            }
        }

        public void AsignarAsiento()
        {
            if (colaPersonas.Count > 0)
            {
                Persona persona = colaPersonas.Dequeue();
                Console.WriteLine($"🎟 Asiento asignado a: {persona}");
            }
            else
            {
                Console.WriteLine("⚠ No hay personas en la cola.");
            }
        }

        public void MostrarCola()
        {
            if (colaPersonas.Count > 0)
            {
                Console.WriteLine("\n📋 Personas en la cola:");
                foreach (Persona persona in colaPersonas)
                {
                    Console.WriteLine(persona);
                }
            }
            else
            {
                Console.WriteLine("La cola está vacía.");
            }
        }

        public void MostrarDisponibilidad()
        {
            Console.WriteLine($"\nAsientos ocupados: {colaPersonas.Count}");
            Console.WriteLine($"Asientos disponibles: {capacidadMaxima - colaPersonas.Count}");
        }
    }

    // Clase principal
    class Program
    {
        static void Main(string[] args)
        {
            Atraccion atraccion = new Atraccion(30);
            int opcion;

            do
            {
                Console.WriteLine("\n=== SISTEMA DE ASIGNACIÓN DE ASIENTOS ===");
                Console.WriteLine("1. Agregar persona a la cola");
                Console.WriteLine("2. Asignar asiento");
                Console.WriteLine("3. Mostrar cola");
                Console.WriteLine("4. Mostrar disponibilidad");
                Console.WriteLine("0. Salir");
                Console.Write("Seleccione una opción: ");

                try
                {
                    opcion = int.Parse(Console.ReadLine());

                    switch (opcion)
                    {
                        case 1:
                            Console.Write("Ingrese el nombre de la persona: ");
                            string nombre = Console.ReadLine();
                            atraccion.AgregarPersona(nombre);
                            break;

                        case 2:
                            atraccion.AsignarAsiento();
                            break;

                        case 3:
                            atraccion.MostrarCola();
                            break;

                        case 4:
                            atraccion.MostrarDisponibilidad();
                            break;

                        case 0:
                            Console.WriteLine("Saliendo del sistema...");
                            break;

                        default:
                            Console.WriteLine("❌ Opción no válida.");
                            break;
                    }
                }
                catch
                {
                    Console.WriteLine("⚠ Error: Ingrese un número válido.");
                    opcion = -1;
                }

            } while (opcion != 0);
        }
    }
}

