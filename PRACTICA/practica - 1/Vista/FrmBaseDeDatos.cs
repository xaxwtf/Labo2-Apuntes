using BibliotecaDeClases;
using System;
using System.Windows.Forms;

namespace Vista
{


    public partial class FrmBaseDeDatos : Form
    {
        SqlManejador manejador;
        public FrmBaseDeDatos()
        {
            InitializeComponent();
            manejador = new SqlManejador();
        }


        // DESARROLLAR
        private void btn_aceptar_Click(object sender, EventArgs e)
        {
            int r;
            try
            {
                EmpleadoFreelance nuevo = new EmpleadoFreelance( decimal.Parse(this.tb_dni.Text), this.tb_nombre.Text, this.tb_puestoACubrir.Text, true);
                SqlManejador db = new SqlManejador();
                r=db.Insertar(nuevo);
                if (r > 0)
                {
                    MessageBox.Show("el Usuario ha sido Creado con exito");
                    this.tb_dni.Text = "";
                    this.tb_nombre.Text = "";
                    this.tb_puestoACubrir.Text = "";
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }


    }
}
