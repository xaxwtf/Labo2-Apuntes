using System;
using System.Collections.Generic;

namespace BibliotecaDeClases
{

    //DESARROLLAR

    public class Empresa
    {
        private List<Puesto> posicionesAbiertas;
        private int cantPuestosACubrir;

        public List<Puesto> Posiciones { get => this.posicionesAbiertas; }

        public Empresa(int puestosACubrir)
        {
            this.cantPuestosACubrir = puestosACubrir;
            this.posicionesAbiertas = new List<Puesto>();

        }

        public List<Puesto> AbrirBusqueda()
        {
            if (this.posicionesAbiertas.Count <= this.cantPuestosACubrir)
            {
                posicionesAbiertas.Add(GeneradorDeDatos.GetUnPuesto);
            }
            else
            {
                BusquedasRealizadasConExito.Invoke(true);
            }
            return this.posicionesAbiertas;

        }
        public event Action<bool> BusquedasRealizadasConExito;

    }

}
