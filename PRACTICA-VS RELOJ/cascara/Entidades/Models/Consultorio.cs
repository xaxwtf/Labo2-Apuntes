using Entidades.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Entidades.Models
{
    //    14.	Consultorio, será genérica, solo podrá recibir tipos que implementen la interfaz IPaciente y posean un constructor publico sin parámetros:
    //a.En su constructor publico inicializara un nombre para el consultorio y ademas:
    //i.Inicializar:
    //1.	demoraAtencionTotal en 0 (cero).
    //2.	cantAtendidos en 0 (cero).
    //15.	La propiedad AbrirConsultorio:
    //a.El GET retornara True, si la tares no es nula y estado de la tarea es Running o WaitingToRun o WaitingForActivation.
    //b.En el SET, si el valor recibido es TRUE y la tarea es nula o su estado no es Running o no es WaitingToRun o no es WaitingForActivation, se instanciará un nuevo CancelationTokenSource y se llamará a IniciarIngreso. De lo contrario se llamará al método Cancel de cancellation.
    //16.	El método IniciarIngreso será privado y:
    //a.Ejecutará en un hilo secundario la acción de que:
    //i.Mientras no se requiera cancelación de la tarea invocara a los métodos NotificarNuevoIngreso, EsperarProximoIngreso y luego incrementar en 1 la cantidad de atendidos. 
    //17.	El método NotificarNuevoIngreso, verificara si el evento OnIngreso posee suscriptores y en caso exitoso realizara:
    //a.Instanciar el paciente.
    //b.Anunciará el ingreso del paciente.
    //c.Notificar el paciente instanciado
    //18.	El método EsperarProximoIngreso si posee un suscriptor notificara los segundos transcurridos mientras que el paciente no sea atendido o no se requiera cancelacion (Utilizar Thread.Sleep para dormir el hilo 1 segundo antes de ir incrementando)

    
    public class Consultorio<T> where T: IPaciente  , new()
    {
        private CancellationTokenSource cancellation;
        private int cantAtendidos;
        private double demoraAtencionTotal;
        private string nombre;
        private T paciente;
        private Task tarea; 
        public Consultorio(string nombre)
        {
            this.nombre = nombre;
            this.demoraAtencionTotal = 0;
            this.cantAtendidos = 0;
        }
        public bool AbrirConsultorio { 
            get
            {
                bool r = false;
                if(this.tarea!=null &&  (tarea.Status == TaskStatus.Running || tarea.Status == TaskStatus.WaitingToRun || tarea.Status == TaskStatus.WaitingForActivation))
                {
                    r = true;
                }
                return r;
            }
            set
            {
                if ((this.tarea == null && value == true)|| ( value==true && (tarea.Status != TaskStatus.Running || tarea.Status != TaskStatus.WaitingToRun || tarea.Status != TaskStatus.WaitingForActivation)))
                {
                    this.cancellation = new CancellationTokenSource();
                    this.IniciarIngreso();
                }
                else
                {
                    this.cancellation.Cancel();
                }
            }
        }
        public string Nombre { get => this.nombre; }
        public double TiempoMedioDeAtencion { get; }
        private void IniciarIngreso()
        {
            this.tarea = new Task(() =>
              {
                  while (!this.cancellation.IsCancellationRequested)
                  {
                      NotificarNuevoIngreso();
                      EsperarProximoIngreso();
                      this.cantAtendidos=this.cantAtendidos+1;
                  }
                  
              });
            this.tarea.Start();
        }
        private void NotificarNuevoIngreso()
        {
            if (this.OnIngreso != null)
            {
                this.paciente = new T();
                this.paciente.Anunciarse();
                this.OnIngreso.Invoke(this.paciente);
            }
        }
        private void EsperarProximoIngreso()
        {
            if (OnDemora != null)
            {
                Thread.Sleep(1000);
                this.demoraAtencionTotal=this.demoraAtencionTotal + 1;
                this.OnDemora.Invoke(1);
                
            }
        }
        public event DelegadoDemoraAtencion OnDemora;
        public event DelegadoNuevoIngreso OnIngreso;


    }
}
