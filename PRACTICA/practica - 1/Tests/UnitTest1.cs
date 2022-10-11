using Microsoft.VisualStudio.TestTools.UnitTesting;
using BibliotecaDeClases;


namespace Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        [ExpectedException(typeof(DatoErroneoException))]///se pregutna si esta reciendo esa exepcion
        public void Test_InsertarEmpleadoError_DeberiaLanzarDatoErroneoExeption()
        {
            //arrange
            SqlManejador db = new SqlManejador();
            EmpleadoFreelance unEmpleado = new EmpleadoFreelance(1,"equivocado","ninguno",false);

            //act
            db.Insertar(unEmpleado);


            //asert   
        }
        [TestMethod]
        public void Test_InsertarEmpleadoExitoso_deberiaserOk()
        {
            SqlManejador db = new SqlManejador();
            EmpleadoFreelance unEmpleado = new EmpleadoFreelance(44400410, "esOK", "no se que poner", true);
            int respuesta;

            respuesta=db.Insertar(unEmpleado);


            Assert.IsTrue(respuesta > 0);

        }

        [TestMethod]
        public void Test_GeneradorDatos_deberiaRetornarDatosOk()
        {
            Empleado unEmpleadoValido = GeneradorDeDatos.GetEmpleadoAleatorio;
            Puesto unPuestoValido = GeneradorDeDatos.GetUnPuesto;

            Assert.IsNotNull(unEmpleadoValido);
            Assert.IsNotNull(unPuestoValido);
            Assert.IsTrue(unPuestoValido.Posicion != "" && unPuestoValido.CalcularHonorarios != 0);
            Assert.IsTrue(unEmpleadoValido.Dni > 10000000 && unEmpleadoValido.Dni < 45000000 && unEmpleadoValido.NombreCompleto != "" && unEmpleadoValido.CalcularHonorarios > 0);
        }

    }
}
