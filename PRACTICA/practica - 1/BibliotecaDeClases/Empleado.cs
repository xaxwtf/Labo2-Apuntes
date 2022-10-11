using System;
using System.Text.Json.Serialization;// inclurilo en la clase padre evita ciertos errores de volcado

namespace BibliotecaDeClases
{
    //DESARROLLAR 

    public abstract class Empleado : ICompensacion
    {
        protected decimal dni;
        protected string nombreCompleto;
        protected string posicion;
        protected int remuneracionPretendida;

        protected Empleado()
        {
            this.remuneracionPretendida = GeneradorDeDatos.Rnd.Next(100000, 2500000);
        }

        public Empleado(decimal dni, string nombre, string posicion) : this()
        {
            this.dni = dni;
            this.nombreCompleto = nombre;
            this.posicion = posicion;

        }

        public string Posicion
        {
            get { return this.posicion; }
        }

        public decimal Dni { get => this.dni; set => this.dni = value; }
        public string NombreCompleto { get => this.nombreCompleto; set => this.nombreCompleto = value; }
        public abstract float CalcularHonorarios { get; }



    }
}
