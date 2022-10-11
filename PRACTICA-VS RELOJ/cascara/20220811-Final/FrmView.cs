﻿using Entidades.DataBase;
using Entidades.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades.Interfaces;
using Entidades.Files;

namespace _20220811_FINAL
{
    public partial class FrmView : Form
    {
        private Queue<IPaciente> pacientes;
        Consultorio<Paciente> consultorio;
        public FrmView()
        {
            InitializeComponent();
            this.pacientes = new Queue<IPaciente>();
            this.consultorio = new Consultorio<Paciente>("24 Hs");
        }
        private void FrmView_Load(object sender, EventArgs e)
        {
            //Alumno agregar manejadores
            this.consultorio.OnIngreso += MostrarPaciente;
            this.consultorio.OnDemora += MostrarConteo;

        }


        //Alumno: Realizar los cambios necesarios sobre MostrarPaciente
        //de manera que en lblNombrePaciente se refleje el indentificador del paciente y
        //se agregue el paciente a la Queue

        private void MostrarPaciente(IPaciente paciente)
        {

            if (this.lblNombrePaciente.InvokeRequired)
            {
                this.pacientes.Enqueue(paciente);
                //pregunta si se quiere invocar al componente(si no es propio del la tarea se requerira);
                this.lblNombrePaciente.BeginInvoke((MethodInvoker)delegate ()
                {
                    this.lblNombrePaciente.Text = paciente.Identificador;
                    

                });
            }
            
            

        }

        //Alumno: Realizar los cambios necesarios sobre Mostrar conteo de manera que se refleje
        //en el fomrulario el tiempo transcurrido de cada iteracion con el paciente
        private void MostrarConteo(double tiempo)
        {
            if (this.lblTiempo.InvokeRequired)
            {
                //pregunta si se quiere invocar al componente(si no es propio del la tarea se requerira);
                this.lblTiempo.BeginInvoke((MethodInvoker)delegate ()
                {
                    this.lblTiempo.Text = $"{tiempo} segundos";
                    this.lblTma.Text = $"{this.consultorio.TiempoMedioDeAtencion.ToString("00.0")} segundos";
                });
            }

            

        }

        private void btnAbrir_Click(object sender, EventArgs e)
        {
            if (!this.consultorio.AbrirConsultorio)
            {
                try {
                    this.consultorio.AbrirConsultorio = true;
                    this.btnAbrir.Image = global::_20220811_Final.Properties.Resources.close;
                }
                catch (Exception x)
                {
                    MessageBox.Show(x.Message);
                }
            }
            else
            {
                this.consultorio.AbrirConsultorio = false;
                this.btnAbrir.Image = global::_20220811_Final.Properties.Resources.open;

                //Alumno serializar this.lstAtendidos.Item en ListadoDeAtendidos.json

            }
        }

        private void btnSiguiente_Click(object sender, EventArgs e)
        {
            if (this.pacientes.Count > 0)
            {
                IPaciente paciente = this.pacientes.Dequeue();
                paciente.Atender();
                this.ActualizarAtendidos(paciente);
            }
            else
            {
                MessageBox.Show("El consultorio no posee pacientes", "Atencion", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }

        }

        private void ActualizarAtendidos(IPaciente paciente)
        {
            this.lstAtendidos.Items.Add(paciente);
        }


    }
}
