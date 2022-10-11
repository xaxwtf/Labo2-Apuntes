using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BibliotecaDeClases
{

    public enum EBono
    {
        Basico = 15000,
        Medio = 25000,
        Alto = 40000
    }


    // DESARROLLAR
    public class EmpleadoRelacionDependencia: Empleado
    {

        EBono bono;

        public EmpleadoRelacionDependencia(decimal dni, string nombreCompleto, string posicion, EBono bono):base(dni,nombreCompleto,posicion)
        {
            this.bono = bono;
        }
        public override float CalcularHonorarios{ 
            get {
                if (this.remuneracionPretendida > 250000)
                {
                    return (float)this.remuneracionPretendida - (float)(this.remuneracionPretendida  *  0.3);
                }
                else
                {
                    return this.remuneracionPretendida;
                }
            } 
        }
        public float SueldoConAguinaldoActualizado {
            get {
                return this.remuneracionPretendida+(float)(this.remuneracionPretendida*0.5)+(float)this.bono;
            } 
        }

    }
}
