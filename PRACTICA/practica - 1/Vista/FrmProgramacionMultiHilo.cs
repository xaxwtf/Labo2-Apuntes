using BibliotecaDeClases;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vista
{

    // DESARROLLAR
    public partial class FrmProgramacionMultiHilo : Form
    {
     
        CancellationTokenSource cts;
        List<Empleado> listaEmpleados;

        public FrmProgramacionMultiHilo()
        {
            InitializeComponent();

            cts = new CancellationTokenSource();
         
            listaEmpleados = new List<Empleado>();

        }

        private void ComenzarCarga()
        {
            float sueldosDolarizados = 0;
            float sueldosPesificados = 0;
            float montoTotalAguinaldos = 0;

            while (sueldosDolarizados <= 10000 && sueldosPesificados <= 10000000 && montoTotalAguinaldos <= 20000000)
            {

                Empleado unEmpleado = GeneradorDeDatos.GetEmpleadoAleatorio;

                this.listaEmpleados.Add(unEmpleado);
                if(unEmpleado is EmpleadoFreelance)
                {
                    sueldosDolarizados = sueldosDolarizados + unEmpleado.CalcularHonorarios;
                }
                else
                {
                    sueldosPesificados= sueldosPesificados+ unEmpleado.CalcularHonorarios;
                    montoTotalAguinaldos = montoTotalAguinaldos + ((EmpleadoRelacionDependencia)unEmpleado).SueldoConAguinaldoActualizado;
                }
                if(this.dtg_ListadoPuestosEncontrados.InvokeRequired)
                {
                    this.dtg_ListadoPuestosEncontrados.BeginInvoke((MethodInvoker)delegate ()
                    {
                        this.dtg_ListadoPuestosEncontrados.DataSource = null;
                        this.dtg_ListadoPuestosEncontrados.DataSource = listaEmpleados;

                        lb_SueldoDolarizado.Text = "Sueldos Dolarizados a Liquidar mensualmente: " + sueldosDolarizados;
                        lb_MontoAguinaldo.Text = "Monto a liquidar en Aguinaldos: " + montoTotalAguinaldos;
                        lb_SueldoPesificado.Text = "Sueldos Pesificados a Liquidar mensualmente:  " + sueldosPesificados;
                    });
                }

                

                Thread.Sleep(2000);
            }
            this.CancelarProceso();


        }


        private void CancelarProceso()
        {
            this.btn_comenzarCarga.BeginInvoke((MethodInvoker)delegate ()
            {
                cts.Cancel();
                MessageBox.Show($"Hasta aqui dan las finanzas: Se les pagará a {listaEmpleados.Count} empleados");
                btn_comenzarCarga.Enabled = true;
            });
        }


        private void btn_comenzarCarga_Click(object sender, EventArgs e)
        {
            this.listaEmpleados.Clear();
            btn_comenzarCarga.Enabled = false;
            Task cargaEmpleados = new Task(ComenzarCarga);
            cargaEmpleados.Start();
        }
    }
}
